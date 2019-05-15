using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeApp.Statistics
{
    class MonthData
    {
        public double Worked;
        public int NumberOfBreaks;
        public double TotalBreakTime;
        public List<ProcessedProcessData> Processes;

        public MonthData()
        {
            Worked = TotalBreakTime = 0;
            NumberOfBreaks = 0;
            Processes = new List<ProcessedProcessData>();
        }

        public void AddSession(SessionData session)
        {
            Worked += session.ElapsedTime;
            foreach (ProcessData item in session.Processes)
            {
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
            foreach (BreakData item in session.Breaks)
            {
                NumberOfBreaks++;
                TotalBreakTime += item.BreakSecondsDuration;
            }
        }
    }
}
