using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;

namespace ProductionKB
{
    public partial class TdTask : Form
    {
        public TdTask()
        {
            InitializeComponent();
        }
        BLL.BLLBase bll = new BLL.BLLBase();
        private System.Timers.Timer tmWorkTimer = new System.Timers.Timer();
        private void TdTask_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Focus();
            InStockData.InTask += new Action<InStockArgs>(Data_InTask);
            OutStockDate.OutTask += new OutStockEventHandler(Data_OutTask);
            bsMain1.DataSource = GetMonitorData();
            bsMain2.DataSource = GetMonitorData1();
            tmWorkTimer.Interval = 10000;
            tmWorkTimer.Elapsed += new System.Timers.ElapsedEventHandler(tmWorker);
            tmWorkTimer.Start();
        }
        private DataTable GetMonitorData()
        {
            DataTable dt = bll.FillDataTable("WCS.SelectTask", new DataParameter[] { new DataParameter("{0}", "WCS_TASK.state!='7' and WCS_TASK.State!='9' and WCS_TASK.state!=0 and WCS_TASK.TaskType='11' and WCS_TASK.AreaCode='002'") });
            return dt;
        }
        private DataTable GetMonitorData1()
        {
            DataTable dt = bll.FillDataTable("WCS.SelectTask", new DataParameter[] { new DataParameter("{0}", "WCS_TASK.state!='7' and WCS_TASK.State!='9' and WCS_TASK.TaskType='12' and WCS_TASK.AreaCode='002'") });
            return dt;
        }
        private void tmWorker(object sender, System.Timers.ElapsedEventArgs e)
        {

            try
            {
                tmWorkTimer.Stop();
                DataTable dt = GetMonitorData();
                DataTable dt1 = GetMonitorData1();
                InStockData.InStockInfo(dt);
                OutStockDate.OutStockInfo(dt1);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                tmWorkTimer.Start();
            }

        }
        void Data_InTask(InStockArgs args)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<InStockArgs>(Data_InTask), args);
            }
            else
            {
                lock (this.dataGridView2)
                {
                    DataTable dt = args.datatTable;
                    this.bsMain1.DataSource = dt;
                }
            }
        }
        void Data_OutTask(OutStockArgs args)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new OutStockEventHandler(Data_OutTask), args);
            }
            else
            {
                lock (this.dataGridView2)
                {
                    DataTable dt = args.datatTable;
                    this.bsMain2.DataSource = dt;
                }
            }
        }
        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

    }
}
