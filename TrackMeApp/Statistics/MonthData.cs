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
        public List<ProcessedTaskData> Tasks;

        public MonthData()
        {
            Worked = TotalBreakTime = 0;
            NumberOfBreaks = 0;
            Tasks = new List<ProcessedTaskData>();
        }

        public void AddSession(SessionData session)
        {
            Worked += session.ElapsedTime;
            var index = Tasks.FindIndex(p => p.Title == session.TaskData.Title);
            if (index > -1)
            {
                Tasks[index].AddSession(session);
            }
            else
            {
                var task = new ProcessedTaskData(session.TaskData.Title);
                task.AddSession(session);
                Tasks.Add(task);
            }
            foreach (BreakData item in session.Breaks)
            {
                NumberOfBreaks++;
                TotalBreakTime += item.BreakSecondsDuration;
            }
        }
    }
}
