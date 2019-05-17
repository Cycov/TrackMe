using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeApp.Statistics
{
    class ProcessedTaskData
    {
        public string Title;
        public double ActiveTime;
        public List<ProcessedProcessData> Processes;

        public ProcessedTaskData(string name)
        {
            Processes = new List<ProcessedProcessData>();
            Title = name;
            ActiveTime = 0;
        }

        public void AddSession(SessionData session)
        {
            foreach (ProcessData item in session.Processes)
            {
                ActiveTime += item.FocusedSeconds;
                var index = Processes.FindIndex(p => p.ProcessName == item.ProcessName);
                if (index > -1)
                {
                    Processes[index].Merge(item);
                }
                else
                {
                    Processes.Add(new ProcessedProcessData(item));
                }
            }
        }
    }
}
