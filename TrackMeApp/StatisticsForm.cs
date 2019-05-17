using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrackMeApp.Statistics;

namespace TrackMeApp
{
    public partial class StatisticsForm : MaterialForm
    {
        class LegendListBoxItem
        {
            public Color Color;
            public string Name;

            public LegendListBoxItem(Color color, string name)
            {
                Color = color;
                Name = name;
            }
        }

        private SolidBrush arrowBrush;
        private Dictionary<string, string> ProcessNameRelationship = new Dictionary<string, string>()
        {
            {"POWERPNT.EXE", "PowerPoint" },
            {"DEVENV.EXE", "Visual studio" }
        };

        private MonthData[] sortedData;
        private MonthData selectedMonth;
        private ProcessedTaskData selectedTask;

        public StatisticsForm(List<SessionData> sessions)
        {
            InitializeComponent();

            arrowBrush = new SolidBrush(Color.LightBlue);
            SortData(sessions);
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(arrowBrush, new[] { new Point(0, 0), new Point(p.Width, p.Height / 2), new Point(0, p.Height), new Point(0, 0) });
        }

        private void SortData(List<SessionData> sessions)
        {
            sortedData = new MonthData[12];
            foreach (SessionData session in sessions)
            {
                int month = session.SessionStart.Month - 1;
                if (sortedData[month] == null)
                    sortedData[month] = new MonthData();
                sortedData[month].AddSession(session);
            }
        }

        private void PopulateTaskChart()
        {
            selectedMonth = sortedData[dummyTabControl.SelectedIndex];
            processesListBox.Items.Clear();
            appsChart.Series.Clear();
            windowsListBox.Items.Clear();
            windowsChart.Series.Clear();
            if (selectedMonth == null)
            {
                dataPanel.Hide();
                return;
            }
            else
            {
                dataPanel.Show();
            }

            tasksChart.Series.Clear();
            tasksListBox.Items.Clear();
            Series series = new Series();

            foreach (var task in selectedMonth.Tasks)
            {
                var color = Extensions.PalleteColors[windowsChart.Palette][tasksListBox.Items.Count % Extensions.PalleteColors[windowsChart.Palette].Count];
                tasksListBox.Items.Add(new LegendListBoxItem(color, task.Title));
                series.Points.AddXY(task.Title, task.ActiveTime);
            }


            series.ChartType = SeriesChartType.Doughnut;
            series.Label = "#PERCENT{0 %}";
            series.LegendText = "#VALX";

            tasksChart.Series.Add(series);
        }

        private void PopulateAppChart()
        {
            selectedTask = selectedMonth.Tasks[tasksListBox.SelectedIndex];
            workedTimeLabel.Text = TimeSpan.FromSeconds(selectedMonth.Worked).ToString(@"hh\:mm\:ss");
            breaksLabel.Text = selectedMonth.NumberOfBreaks + " / " + TimeSpan.FromSeconds(selectedMonth.TotalBreakTime).ToString(@"hh\:mm\:ss");

            appsChart.Series.Clear();
            processesListBox.Items.Clear();
            Series series = new Series();

            foreach (var process in selectedTask.Processes)
            {
                var color = Extensions.PalleteColors[appsChart.Palette][processesListBox.Items.Count % Extensions.PalleteColors[appsChart.Palette].Count];
                string name;
                if (ProcessNameRelationship.ContainsKey(process.ProcessName.ToUpper()))
                    name = ProcessNameRelationship[process.ProcessName.ToUpper()];
                else
                    name = Path.GetFileNameWithoutExtension(process.ProcessName);
                processesListBox.Items.Add(new LegendListBoxItem(color, name));
                series.Points.AddXY(process.ProcessName, process.FocusedSeconds);
            }

            series.ChartType = SeriesChartType.Doughnut;
            series.Label = "#PERCENT{0 %}";
            series.LegendText = "#VALX";

            appsChart.Titles[0].Text = selectedTask.Title;
            appsChart.Titles[1].Text = TimeSpan.FromSeconds(selectedTask.ActiveTime).ToString(@"hh\:mm\:ss");
            appsChart.Series.Add(series);
        }

        internal void RefreshData(List<SessionData> sessions)
        {
            SortData(sessions);
        }

        private void PopulateWindowsChart()
        {
            var selectedProcess = selectedTask.Processes[processesListBox.SelectedIndex];

            windowsChart.Series.Clear();
            windowsListBox.Items.Clear();
            Series series = new Series();

            foreach (var window in selectedProcess.Windows)
            {
                var color = Extensions.PalleteColors[windowsChart.Palette][windowsListBox.Items.Count % Extensions.PalleteColors[windowsChart.Palette].Count];
                windowsListBox.Items.Add(new LegendListBoxItem(color, window.Title));
                series.Points.AddXY(window.Title, window.ActiveTime);
            }

            series.ChartType = SeriesChartType.Doughnut;
            series.Label = "#PERCENT{0 %}";
            series.LegendText = "#VALX";

            windowsChart.Titles[0].Text = selectedProcess.ProcessName;
            windowsChart.Titles[1].Text = TimeSpan.FromSeconds(selectedProcess.FocusedSeconds).ToString(@"hh\:mm\:ss");
            windowsChart.Series.Add(series);
        }

        private void ProcessesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateWindowsChart();
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            ListBox listBox = (ListBox)sender;
            LegendListBoxItem lbi = listBox.Items[e.Index] as LegendListBoxItem;

            Graphics g = e.Graphics;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.LightBlue);//Choose the color

            g.FillRectangle(new SolidBrush(lbi.Color), e.Bounds.X + 3, e.Bounds.Y, 20, e.Bounds.Height - 3);
            g.DrawString(lbi.Name, e.Font, new SolidBrush(Color.Black), new PointF(e.Bounds.X + 20, e.Bounds.Y));
            e.DrawFocusRectangle();
        }

        private void DummyTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTaskChart();
        }

        private void StatisticsForm_Shown(object sender, EventArgs e)
        {
            dummyTabControl.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void TasksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateAppChart();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
