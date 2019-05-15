using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMeApp
{
    public class WindowData
    {
        public string Title;
        public double ActiveTime;

        public WindowData()
        {
            Title = "";
            ActiveTime = 0d;
        }

        public WindowData(string title)
        {
            Title = title;
            ActiveTime = 0d;
        }
    }
}
