using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;

namespace TrackMeApp
{
    public partial class MainForm : MaterialForm
    {

        SessionData sessionData;
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private List<SessionData> sessions;
        private StatisticsForm statisticsForm;

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void SessionData_StateChanged(object sender, SessionData.SessionStateChangedEventArgs e)
        {
            if (e.CurrentSessionState == SessionData.SessionStates.Stopped)
            {
                poolStatusTimer.Stop();
                toggleStateBtn.Text = Properties.Resources.start;
            }
        }

        private void toggleStateBtn_Click(object sender, System.EventArgs e)
        {
            if (sessionData == null)
            {
                string taskTitle = "Unknown";
                if (Globals.UserId > -1 && tasksComboBox.SelectedIndex >= 0)
                    taskTitle = tasksComboBox.Text;
                sessionData = new SessionData(poolStatusTimer, taskTitle, String.Empty);
                sessionData.StateChanged += SessionData_StateChanged;
            }

            if (sessionData.SessionState == SessionData.SessionStates.Idle || sessionData.SessionState == SessionData.SessionStates.Stopped)
            {
                sessionData.Start();
                poolStatusTimer.Start();
                toggleStateBtn.Text = Properties.Resources.pause;
            }
            else if (sessionData.SessionState == SessionData.SessionStates.Paused)
            {
                poolStatusTimer.Start();
                sessionData.Resume();
                toggleStateBtn.Text = Properties.Resources.pause;
            }
            else if (sessionData.SessionState == SessionData.SessionStates.Active)
            {
                poolStatusTimer.Stop();
                sessionData.Pause();
                toggleStateBtn.Text = Properties.Resources.start;
            }
        }

        private void poolStatusTimer_Tick(object sender, System.EventArgs e)
        {
            var elapsed = TimeSpan.FromSeconds((int)sessionData.ElapsedTime);
            elapsedTimerLabel.Text = elapsed.ToString(@"hh\:mm\:ss");
        }

        private void stopBtn_Click(object sender, System.EventArgs e)
        {
            if (sessionData != null && sessionData.SessionState != SessionData.SessionStates.Stopped)
            {
                sessionData.Stop();
                sessions.Add(sessionData);
                if (Globals.UserId > -1)
                {
                    _ = Extensions.HttpPostAsync(Properties.Settings.Default.logSessionRequestUri, new Dictionary<string, string>()
                    {
                        { "userId", Globals.UserId.ToString() },
                        { "session", JsonConvert.SerializeObject(sessionData) }
                    });
                }
                if (statisticsForm != null)
                    statisticsForm.RefreshData(sessions);
            }
        }

        private void statistics_Click(object sender, EventArgs e)
        {
            if (statisticsForm.IsDisposed)
                statisticsForm = new StatisticsForm(sessions);
            statisticsForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSessions();
        }

        private void LoadSessions()
        {
            if (File.Exists(Properties.Settings.Default.filename))
                sessions = JsonConvert.DeserializeObject<List<SessionData>>(File.ReadAllText(Properties.Settings.Default.filename));
            else
                sessions = new List<SessionData>();
            statisticsForm = new StatisticsForm(sessions);
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            File.WriteAllText(Properties.Settings.Default.filename, JsonConvert.SerializeObject(sessions));
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            using (var form = new LoginForm())
            {
                var result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    loginBtn.Hide();
                    tasksComboBox.Show();
                    Globals.UserId = form.UserId;
                    var responseJson = await Extensions.HttpPostAsync(Properties.Settings.Default.getTasksRequestUri, new Dictionary<string, string>()
                    {
                        { "userId", Globals.UserId.ToString() }
                    });
                    if (!String.IsNullOrWhiteSpace(responseJson))
                    {
                        var tasks = JsonConvert.DeserializeObject<List<HttpResponses.TaskResponse>>(responseJson);
                        foreach (var task in tasks)
                        {
                            tasksComboBox.Items.Add(task.title);
                        }
                        if (tasksComboBox.Items.Count > 0)
                            tasksComboBox.SelectedIndex = 0;
                    }

                    responseJson = await Extensions.HttpPostAsync(Properties.Settings.Default.getSessionsRequestUri, new Dictionary<string, string>()
                    {
                        { "userId", Globals.UserId.ToString() }
                    });
                    if (!String.IsNullOrWhiteSpace(responseJson))
                    {
                        sessions = JsonConvert.DeserializeObject<List<SessionData>>(responseJson);
                        statisticsForm?.RefreshData(sessions);
                    }
                }
            }
        }

        private void TopMostBtn_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }
    }
}
