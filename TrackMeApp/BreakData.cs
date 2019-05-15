using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeApp
{
    public class BreakData
    {
        public double BreakSecondsDuration;
        public DateTime BreakStart;
        public DateTime BreakStop;
        public string Comment;

        public BreakData()
        {
            BreakStart = DateTime.Now;
        }

        public void EndBreak(string comment = "")
        {
            BreakStop = DateTime.Now;
            BreakSecondsDuration = (BreakStop - BreakStart).TotalSeconds;
            Comment = comment;
        }
    }
}
