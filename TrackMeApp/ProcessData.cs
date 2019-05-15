using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeApp
{
    public class ProcessData
    {
        public string ProcessName;
        public double FocusedSeconds;
        public List<WindowData> Windows;

        private WindowData focusedWindow;

        public ProcessData(string pName)
        {
            Windows = new List<WindowData>();
            ProcessName = pName;
            FocusedSeconds = 0;
        }

        public void IncrementFocusedSeconds(double value, string windowTitle)
        {
            FocusedSeconds += value;
            if (focusedWindow == null)
            {
                focusedWindow = new WindowData(windowTitle);
                Windows.Add(focusedWindow);
            }
            else if (focusedWindow.Title != windowTitle)
            {
                var index = Windows.FindIndex(p => p.Title == windowTitle);
                if (index > -1)
                {
                    focusedWindow = Windows[index];
                }
                else
                {
                    focusedWindow = new WindowData(windowTitle);
                    Windows.Add(focusedWindow);
                }
            }
            focusedWindow.ActiveTime += value;
        }
    }
}
