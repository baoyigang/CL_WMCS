using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProductionKB
{
    public delegate void OutStockEventHandler(OutStockArgs args);
    public class TaskEventArgs
    {
        private DataTable datatable;

        public DataTable datatTable
        {
            get
            {
                return datatable;
            }
        }

        public TaskEventArgs(DataTable dt)
        {
            this.datatable = dt;
        }
    }
    public class MainData
    {
        public static event Action<TaskEventArgs> OnTask = null;

        public static void TaskInfo(DataTable dt)
        {
            if (OnTask != null)
            {
                OnTask(new TaskEventArgs(dt));
            }
        }
    }
    public class InStockArgs
    {
        private DataTable datatable;

        public DataTable datatTable
        {
            get
            {
                return datatable;
            }
        }

        public InStockArgs(DataTable dt)
        {
            this.datatable = dt;
        }
    }
    public class InStockData
    {
        public static event Action<InStockArgs> InTask = null;

        public static void InStockInfo(DataTable dt)
        {
            if (InTask != null)
            {
                InTask(new InStockArgs(dt));
            }
        }
    }
    public class OutStockArgs
    {
        private DataTable datatable;

        public DataTable datatTable
        {
            get
            {
                return datatable;
            }
        }

        public OutStockArgs(DataTable dt)
        {
            this.datatable = dt;
        }
    }
    public class OutStockDate
    {
        public static event OutStockEventHandler OutTask = null;

        public static void OutStockInfo(DataTable dt)
        {
            if (OutTask != null)
            {
                OutTask(new OutStockArgs(dt));
            }
        }
    }

}