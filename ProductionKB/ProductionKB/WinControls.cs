using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
namespace ProductionKB
{
    public partial class WinControls : UserControl
    {
        public WinControls()
        {
            InitializeComponent();
        }
        private System.Timers.Timer tmWorkTimer = new System.Timers.Timer();
        BLL.BLLBase bll = new BLL.BLLBase();
        DataTable dt;
        private delegate void RefreshDelegate(RefreshData refreshData);

        private void WinControls_Load(object sender, EventArgs e)
        {
            tmWorkTimer.Interval = 1000;
            tmWorkTimer.Elapsed += new System.Timers.ElapsedEventHandler(tmWorkTimerWorker);
            tmWorkTimer.Start();
        }
        private void tmWorkTimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                tmWorkTimer.Stop();
                string date = DateTime.Now.ToString("yyMMdd");
                RefreshData refresh = new RefreshData();
                DataParameter[] param;
                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State=7 and TaskType=12 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask",param);
                refresh.TodayOutFinish = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State=7 and TaskType=11 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayInFinish = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State=7 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayFinish = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State=0 and TaskType=12 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayOutWait = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State=0 and TaskType=11 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayInWait = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State=0 and AreaCode='002' ") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayWait = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State!=0 and State!=7 and TaskType=12 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayOutRun = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State!=0 and State!=7 and TaskType=11 and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayInRun = dt.Rows[0][0].ToString();

                param = new DataParameter[] { new DataParameter("{0}", date), new DataParameter("{1}", "State!=0 and State!=7  and AreaCode='002'") };
                dt = bll.FillDataTable("WCS.SelectTodayTask", param);
                refresh.TodayRun = dt.Rows[0][0].ToString();

                Refresh(refresh);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                tmWorkTimer.Start();
            }
        }
        private void Refresh(RefreshData refreshData)
        {
            if (InvokeRequired)
            {
                RefreshDelegate refreshDelegate = new RefreshDelegate(Refresh);
                Invoke(refreshDelegate, refreshData);
            }
            else
            {
                //lblTodayOutFinish.Text = refreshData.TodayOutFinish;
                //lblTodayOutWait.Text = refreshData.TodayOutWait;
                //lblTodayOutRun.Text = refreshData.TodayOutRun;

                //lblTodayInFinish.Text = refreshData.TodayInFinish;
                //lblTodayInWait.Text = refreshData.TodayInWait;
                //lblTodayInRun.Text = refreshData.TodayInRun;

                //lblTodayFinish.Text = refreshData.TodayFinish;
                //lblTodayWait.Text = refreshData.TodayWait;
                //lblTotalRun.Text = refreshData.TodayRun;

            }
        }
    }
}
