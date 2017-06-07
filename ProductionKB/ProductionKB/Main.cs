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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            x = this.label6.Left;
        }
        int x;
        byte[] buffer = new byte[3];
        BLL.BLLBase bll = new BLL.BLLBase();
        private System.Timers.Timer tmWorkTimer = new System.Timers.Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            //WinControls w = new WinControls();
            //w.Parent = this.splitContainer1.Panel1;
            //w.Size = this.splitContainer1.Panel1.Size;
            this.pictureBox2.Controls.Add(this.label6);
            this.label6.BackColor = Color.Transparent;
            MainData.OnTask += Data_OnTask;
            bsMain.DataSource = GetMonitorData();
            tmWorkTimer.Interval = 10000;
            tmWorkTimer.Elapsed += new System.Timers.ElapsedEventHandler(tmWorker);
            timer1.Start();
            tmWorkTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

                if (this.label6.Left >= 1920)
                {
                    this.label6.Left = 0 - label6.Size.Width;
                }
                else
                {
                    this.label6.Left = this.label6.Left + 10;
                }

               
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Visible)
            {
                this.textBox1.Visible = true;
            }
            else
            {
                this.textBox1.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.textBox1.Text.Trim().Length == 0)
                    return;

                this.label6.Text = this.textBox1.Text;
                this.textBox1.Visible = false;
            }
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            this.label6.Left = x;
        }

        private DataTable GetMonitorData()
        {
            DataTable dt = bll.FillDataTable("WCS.SelectTaskGL", new DataParameter[] { new DataParameter("{0}", "WCS_TASK.state!='7' and WCS_TASK.State!='9' and ((WCS_TASK.TaskType=12 and WCS_TASK.AreaCode='002') or (WCS_TASK.TaskType=11 and WCS_TASK.State=0) or (WCS_TASK.TaskType=11 and WCS_TASK.state!=0 and WCS_TASK.AreaCode='002'))") });
            return dt;
        }

        private void tmWorker(object sender, System.Timers.ElapsedEventArgs e)
        {

            try
            {
                tmWorkTimer.Stop();
                DataTable dt = GetMonitorData();
                MainData.TaskInfo(dt);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                tmWorkTimer.Start();
            }

        }
        void Data_OnTask(TaskEventArgs args)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<TaskEventArgs>(Data_OnTask), args);
            }
            else
            {
                lock (this.dataGridView2)
                {
                    DataTable dt = args.datatTable;
                    this.bsMain.DataSource = dt;          
                }
            }
        }

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TdTask td1 = new TdTask();
                td1.Show();
            }
        }
    }
}
