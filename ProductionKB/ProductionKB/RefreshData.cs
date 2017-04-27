using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionKB
{
    [Serializable]
    public class RefreshData
    {
        private string todayOutFinish;
        private string todayInFinish;
        private string todayFinish;

        private string todayOutWait;
        private string todayInWait;
        private string todayWait;

        private string todayOutRun;
        private string todayInRun;
        private string todayRun;

        public string TodayOutFinish
        {
            get { return todayOutFinish; }
            set { todayOutFinish = value; }
        }

        public string TodayInFinish
        {
            get { return todayInFinish; }
            set { todayInFinish = value; }
        }

        public string TodayFinish
        {
            get { return todayFinish; }
            set { todayFinish = value; }
        }

        public string TodayOutWait
        {
            get { return todayOutWait; }
            set { todayOutWait = value; }
        }

        public string TodayInWait
        {
            get { return todayInWait; }
            set { todayInWait = value; }
        }
        public string TodayWait
        {
            get { return todayWait; }
            set { todayWait = value; }
        }

        public string TodayOutRun
        {
            get { return todayOutRun; }
            set { todayOutRun = value; }
        }

        public string TodayInRun
        {
            get { return todayInRun; }
            set { todayInRun = value; }
        }
        public string TodayRun
        {
            get { return todayRun; }
            set { todayRun = value; }
        }
    }
}

