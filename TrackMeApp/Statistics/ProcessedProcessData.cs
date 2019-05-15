using System;

namespace TrackMeApp.Statistics
{
    internal class ProcessedProcessData : ProcessData
    {
        public ProcessedProcessData(ProcessData processData) : base("")
        {
            ProcessName = processData.ProcessName;
            FocusedSeconds = processData.FocusedSeconds;
            Windows = processData.Windows;
        }

        public void Merge(ProcessData process)
        {
            if (ProcessName != process.ProcessName)
                throw new ArgumentException("Can not merge different processes");

            FocusedSeconds += process.FocusedSeconds;
            foreach (var item in process.Windows)
            {
                var index = Windows.FindIndex(p => p.Title == item.Title);
                if (index > -1)
                {
                    Windows[index].ActiveTime += item.ActiveTime;
                }
                else
                {
                    Windows.Add(item);
                }
            }
        }
    }
}
