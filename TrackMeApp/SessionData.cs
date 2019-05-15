using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace TrackMeApp
{
    public class SessionData
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll")]
        public static extern string GetWindowText(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength", SetLastError = true)]
        internal static extern int GetWindowTextLength(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hwnd, StringBuilder wndTxt, int MaxCount);

        public class SessionStateChangedEventArgs : EventArgs
        {
            public SessionStates PreviousSessionState, CurrentSessionState;

            public SessionStateChangedEventArgs()
            {
            }

            public SessionStateChangedEventArgs(SessionStates previousSessionState, SessionStates currentSessionState)
            {
                PreviousSessionState = previousSessionState;
                CurrentSessionState = currentSessionState;
            }
        }

        public enum SessionStates
        {
            Idle,
            Active,
            Paused,
            Stopped
        }
        [JsonIgnore]
        public SessionStates SessionState;

        public TaskData TaskData;
        public DateTime SessionStart;
        public DateTime SessionStop;
        public double ElapsedTime;

        public List<BreakData> Breaks;
        public List<ProcessData> Processes;

        public event EventHandler<SessionStateChangedEventArgs> StateChanged;

        private BreakData currentBreak;
        private ProcessData currentProcess;
        private DateTime lastPooledTime;

        public SessionData()
        {
            ElapsedTime = 0;
            SessionState = SessionStates.Idle;
            Breaks = new List<BreakData>();
            Processes = new List<ProcessData>();
            TaskData = new TaskData("pew", "pow");
        }

        public SessionData(System.Windows.Forms.Timer timer) : this()
        {
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(PoolData);
        }

        private void PoolData(object state)
        {
            if (SessionState == SessionStates.Active)
            {
                IntPtr hwnd = GetForegroundWindow();
                uint pid;
                GetWindowThreadProcessId(hwnd, out pid);
                string processName;
                Process proc = Process.GetProcessById((int)pid);
                try
                {
                   processName = Path.GetFileName(proc.MainModule.FileName);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    processName = Properties.Resources.unknown;
                }
               
                if (currentProcess == null)
                {
                    currentProcess = new ProcessData(processName);
                    Processes.Add(currentProcess);
                }
                else if (currentProcess.ProcessName != processName)
                {
                    var foundIndex = Processes.FindIndex(p => p.ProcessName == processName);
                    if (foundIndex > -1)
                    {
                        currentProcess = Processes[foundIndex];
                    }
                    else
                    {
                        currentProcess = new ProcessData(processName);
                        Processes.Add(currentProcess);
                    }
                }
                string windowtitle;
                if (IsBrowser(processName))
                {
                    //windowtitle = GetWindowTitle(hwnd);
                    var url = GetChromeUrl();
                    if (String.IsNullOrWhiteSpace(url))
                    {
                        windowtitle = Properties.Resources.unknown;
                        //windowtitle = GetWindowTitle(hwnd);
                    }
                    else
                    {
                        if (!url.StartsWith("http"))
                        {
                            windowtitle = Properties.Resources.unknown;
                            //url = url.Insert(0, "http://");
                        }
                        else
                        {
                            Uri uri = new Uri(url, UriKind.Absolute);
                            windowtitle = uri.Host;
                        }
                    }
                }
                else
                {
                    windowtitle = GetWindowTitle(hwnd);
                }
                if (lastPooledTime != null)
                {
                    var now = DateTime.Now;
                    double secondsPassedBetweenPools = (now - lastPooledTime).TotalSeconds;
                    //Debug.WriteLine(secondsPassedBetweenPools + " ================ " + windowtitle);
                    if (secondsPassedBetweenPools > 100)
                        secondsPassedBetweenPools = 1;
                    currentProcess.IncrementFocusedSeconds(secondsPassedBetweenPools, windowtitle);
                    ElapsedTime += secondsPassedBetweenPools;
                    lastPooledTime = now;
                }
            }
        }

        private bool IsBrowser(string pName)
        {
            if (pName == "chrome.exe")
                return true;
            return false;
        }

        private string GetChromeUrl()
        {
            var value = "";
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                if (chrome.MainWindowHandle == IntPtr.Zero)
                    continue;
                AutomationElement element = AutomationElement.FromHandle(chrome.MainWindowHandle);
                if (element == null)
                    value = null;
                Condition conditions = new AndCondition(
                    new PropertyCondition(AutomationElement.ProcessIdProperty, chrome.Id),
                    new PropertyCondition(AutomationElement.IsControlElementProperty, true),
                    new PropertyCondition(AutomationElement.IsContentElementProperty, true),
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                AutomationElement elementx = element.FindFirst(TreeScope.Descendants, conditions);
                if (elementx == null)
                    return String.Empty;
                value = ((ValuePattern)elementx.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            }
            return value;
        }

        public void Start()
        {
            if (SessionState == SessionStates.Stopped)
            {
                Reset();
                SessionState = SessionStates.Active;
                SessionStart = DateTime.UtcNow;
                return;
            }

            if (SessionState == SessionStates.Idle)
            {
                SessionState = SessionStates.Active;
                SessionStart = DateTime.UtcNow;
            }
            else
                throw new InvalidOperationException("Can not start from a non idle state");
        }

        public void Pause()
        {
            if (SessionState == SessionStates.Active)
            {
                currentBreak = new BreakData();
                OnStateChanged(SessionStates.Paused);
            }
            else
                throw new InvalidOperationException("Can not pause in an inactive state");
        }

        public void Resume()
        {
            if (SessionState == SessionStates.Paused)
            {
                currentBreak.EndBreak();
                Breaks.Add(currentBreak);
                currentBreak = null;
                OnStateChanged(SessionStates.Active);
            }
            else
                throw new InvalidOperationException("Can not resume from a non paused state");
        }

        public void Stop()
        {
            if (SessionState == SessionStates.Active)
            {
                SessionStop = DateTime.UtcNow;
                OnStateChanged(SessionStates.Stopped);
            }
            else if (SessionState == SessionStates.Paused)
            {
                Breaks.Add(currentBreak);
                currentBreak = null;
                SessionStop = DateTime.UtcNow;
                OnStateChanged(SessionStates.Stopped);
            }
        }

        private void Reset()
        {
            Processes.Clear();
            Breaks.Clear();
            currentBreak = null;
            currentProcess = null;
            ElapsedTime = 0d;
        }

        protected virtual void OnStateChanged(SessionStates targetSessionState)
        {
            var sessionState = SessionState;
            SessionState = targetSessionState;
            StateChanged?.Invoke(this, new SessionStateChangedEventArgs(sessionState, targetSessionState));
        }


        public static string GetWindowTitle(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
