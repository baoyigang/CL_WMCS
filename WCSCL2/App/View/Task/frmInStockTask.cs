using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using MCP;
using OPC;

namespace App.View.Task
{
    public partial class frmInStockTask :BaseForm
    {
        BLL.BLLBase bll = new BLL.BLLBase();
        string CraneNo = "02";
        string AreaCode = "";
        private DataTable dtSource = null;
        public frmInStockTask()
        {
            InitializeComponent();
        }

        private void frmInStockTask_Load(object sender, EventArgs e)
        {

            AreaCode = BLL.Server.GetAreaCode();
            DataTable dt = bll.FillDataTable("WCS.SelectInStationByArea", new DataParameter("{0}", "AreaCode=" + this.AreaCode));
            this.cmbStationNo.DataSource = dt.DefaultView;
            this.cmbStationNo.ValueMember = "InStation";
            this.cmbStationNo.DisplayMember = "InStation";
            
           
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked || radioButton3.Checked)
            {
                this.cbRow.Enabled = false;
                this.cbColumn.Enabled = false;
                this.cbHeight.Enabled = false;
            }
            else
            {
                this.cbRow.Enabled = true;
                this.cbColumn.Enabled = true;
                this.cbHeight.Enabled = true;
            }
        }

        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAisleNo();
        }
        private void BindAisleNo()
        {
            if (this.cmbStationNo.SelectedIndex==0)
            {
                CraneNo = "02";
            }
            else
            {
                CraneNo = "03";
            }

            DataParameter[] param = new DataParameter[] 
            { 
                new DataParameter("{0}", string.Format("CraneNo='{0}' and InStation='{1}' and AreaCode={2}",CraneNo, this.cmbStationNo.Text,this.AreaCode))
            };

            DataTable dt = bll.FillDataTable("CMD.SelectAisle", param);
            this.cmbAisleNo.DataSource = dt.DefaultView;
            this.cmbAisleNo.ValueMember = "AisleNo";
            this.cmbAisleNo.DisplayMember = "AisleNo";
            if (CraneNo=="03")
            {
                try
                {
                    object[] objRow = ObjectUtil.GetObjects(Context.ProcessDispatcher.WriteToService("CranePLC3", "CraneAlarmCode"));
                    int CraneAisle = int.Parse(objRow[4].ToString());
                    DataTable dtAisleCell = bll.FillDataTable("CMD.SelectCraneAisleCell", new DataParameter("{0}", CraneAisle.ToString()));
                    if (int.Parse(dtAisleCell.Rows[0][0].ToString()) > 0)
                    {
                        this.cmbAisleNo.SelectedIndex = CraneAisle - 2;
                    }
                    else
                    {
                        dtAisleCell = bll.FillDataTable("CMD.SelectAllAisleCell");
                        this.cmbAisleNo.SelectedIndex = int.Parse(dtAisleCell.Rows[0][0].ToString().Substring(1));
                    }
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);                
                }
            }
            
          
            
        }   

        private void cbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbRow.Text == "System.Data.DataRowView")
                return;

            DataParameter[] param = new DataParameter[] 
            { 
                new DataParameter("{0}", string.Format("ShelfCode='{0}'",this.cbRow.Text))
            };
            DataTable dt = bll.FillDataTable("CMD.SelectColumn", param);

            this.cbColumn.DataSource = dt.DefaultView;
            this.cbColumn.ValueMember = "CellColumn";
            this.cbColumn.DisplayMember = "CellColumn";
        }

        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbRow.Text == "System.Data.DataRowView")
                return;
            if (this.cbColumn.Text == "System.Data.DataRowView")
                return;

            DataParameter[] param = new DataParameter[] 
            { 
                new DataParameter("{0}", string.Format("ShelfCode='{0}' and CellColumn={1}",this.cbRow.Text,this.cbColumn.Text))
            };
            DataTable dt = bll.FillDataTable("CMD.SelectCell", param);
            DataView dv = dt.DefaultView;
            dv.Sort = "CellRow";
            this.cbHeight.DataSource = dv;
            this.cbHeight.ValueMember = "CellRow";
            this.cbHeight.DisplayMember = "CellRow";
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtState = bll.FillDataTable("WCS.SelcetWcsState", new DataParameter[] { new DataParameter("{0}", "0"+(this.cmbStationNo.SelectedIndex + 2).ToString()), new DataParameter("{1}", 10), new DataParameter("{2}", "(WCS_TASK.State='3' and (WCS_TASK.TaskType='12' or WCS_TASK.TaskType='14')) or Wcs_Task.State='13'") });
                if (dtState.Rows.Count == 0)
                {
                    DataTable dtState1 = new DataTable();
                     dtState1 = bll.FillDataTable("WCS.SelcetWcsState", new DataParameter[] { new DataParameter("{0}", "0" + (this.cmbStationNo.SelectedIndex + 2).ToString()), new DataParameter("{1}", 1), new DataParameter("{2}", "(WCS_TASK.State='10')") });
                    
                    
                    if (dtState1.Rows.Count == 0)
                    {
                        if (dtSource == null || dtSource.Rows.Count == 0)
                        {
                            MessageBox.Show("熔次卷号不能为空,请扫码或输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtBarcode.Focus();
                            return;
                        }

                        DataTable dt;
                        DataParameter[] param;


                        param = new DataParameter[] 
                    { 
                      new DataParameter("@AreaCode", AreaCode) ,
                      new DataParameter("@AisleNo",this.cmbAisleNo.Text)
                    };
                        string strTaskNo = "";
                        for (int i = 0; i < dtSource.Rows.Count; i++)
                        {
                            strTaskNo += "'" + dtSource.Rows[i]["TaskNo"] + "'";
                            if (i < dtSource.Rows.Count - 1)
                                strTaskNo += ",";

                        }
                        bll.ExecNonQuery("WCS.updateCrane", new DataParameter[] { new DataParameter("{0}", this.CraneNo), new DataParameter("{1}","(" + strTaskNo + ")") });

                        if (this.radioButton1.Checked)
                        {
                            dt = bll.FillDataTable("WCS.sp_GetCellByAisle", param);
                            if (dt.Rows.Count > 0)
                                this.txtCellCode.Text = dt.Rows[0][0].ToString();
                            else
                                this.txtCellCode.Text = "";
                        }
                        else if (this.radioButton2.Checked)
                        {
                            this.txtCellCode.Text = this.cbRow.Text.Substring(2, 4) + (1000 + int.Parse(this.cbColumn.Text)).ToString().Substring(1, 3) + (1000 + int.Parse(this.cbHeight.Text)).ToString().Substring(1, 3);
                        }
                        else
                        {
                            if (dtSource.Rows.Count > 1)
                            {
                                MCP.Logger.Info("缓存区只能处理单个熔次卷号！");
                                return;
                            }

                            strTaskNo = dtSource.Rows[0]["TaskNo"].ToString();
                            bll.ExecNonQuery("WCS.UpdateTaskAreaCodeByTaskNo", new DataParameter[] { new DataParameter("@AreaCode", AreaCode), new DataParameter("@TaskNo", strTaskNo) });
                            param = new DataParameter[] { new DataParameter("@TaskNo", strTaskNo) };

                            DataTable dtXml = bll.FillDataTable("WCS.Sp_TaskProcessNoShelf", param);
                            if (dtXml.Rows.Count > 0)
                            {
                                string BillNo = dtXml.Rows[0][0].ToString();
                                if (BillNo.Trim().Length > 0)
                                {
                                    string xml = Util.ConvertObj.ConvertDataTableToXmlOperation(dtXml, "BatchInStock");
                                    Context.ProcessDispatcher.WriteToService("ERP", "ACK", xml);
                                    MCP.Logger.Info("单号" + dtXml.Rows[0][0].ToString() + "已完成，开始上报ERP系统");
                                }
                            }
                            SetControlEmpty();
                            this.txtBarcode.Focus();
                            return;

                        }


                        //判断货位是否为空
                        param = new DataParameter[] 
                    { 
                      new DataParameter("{0}", string.Format("CellCode='{0}' and ProductCode='' and IsActive='1' and IsLock='0' and AreaCode='{1}'", this.txtCellCode.Text,AreaCode))
                    };
                        dt = bll.FillDataTable("CMD.SelectCell", param);
                        if (dt.Rows.Count <= 0)
                        {
                            MessageBox.Show("自动获取的货位或指定的货位非空货位,请确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //锁定货位



                        param = new DataParameter[] 
                    {             
                        new DataParameter("@CellCode", this.txtCellCode.Text),                    
                        new DataParameter("@TaskNo", strTaskNo),
                        new DataParameter("@StationNo", this.cmbAisleNo.Text)
                    };

                        bll.ExecNonQueryTran("WCS.Sp_ExecuteInStockTask", param);

                        int SlideNum = 2;
                        string StationNo = "02";
                        DataParameter[] paramStock = new DataParameter[] { new DataParameter("{0}", string.Format("(TaskNo={0} and ((WCS_TASK.TaskType in  ('11','16') and  WCS_TASK.State='1') or (WCS_TASK.TaskType='14' and  WCS_TASK.State='11'))) and WCS_TASK.AreaCode='{1}'", strTaskNo.Substring(0,12), AreaCode)) };
                        DataTable dtTask = bll.FillDataTable("WCS.SelectTask", paramStock);
                        string sTaskNo = "";
                        if (dtTask.Rows.Count > 0)
                        {
                            sTaskNo = dtTask.Rows[0]["TaskNo"].ToString();
                            SlideNum = int.Parse(dtTask.Rows[0]["AisleNo"].ToString());
                            StationNo = dtTask.Rows[0]["StationNo"].ToString();

                        }
                        else
                        {
                            //if (BarcodeIsExist(taskNo, staskNo))
                            return;
                            //产生空托盘入库任务

                        }
                        int staskNo = int.Parse(sTaskNo);
                        //SlideNum = int.Parse(dt.Rows[0]["AisleNo"].ToString());
                        //StationNo = dt.Rows[0]["StationNo"].ToString(); 
                        if (StationNo == "01")
                        {
                           
                            Context.ProcessDispatcher.WriteToService("TranLine", "TaskNo", staskNo);
                            Context.ProcessDispatcher.WriteToService("TranLine", "SlideNum", SlideNum);

                            Context.ProcessDispatcher.WriteToService("TranLine", "TaskType", 1);
                            Context.ProcessDispatcher.WriteToService("TranLine", "NewTask", 1);
                        }
                        else
                        {
                            
                            Context.ProcessDispatcher.WriteToService("TranLine", "TaskNo1", staskNo);
                            Context.ProcessDispatcher.WriteToService("TranLine", "SlideNum1", SlideNum);

                            Context.ProcessDispatcher.WriteToService("TranLine", "TaskType1", 1);
                            Context.ProcessDispatcher.WriteToService("TranLine", "NewTask1", 1);
                        }
       

                        this.dtSource = null;
                        this.bsMain.DataSource = null;
                        SetControlEmpty();
                        this.txtBarcode.Focus();

                    }
                    else
                    {
                        MessageBox.Show("已有任务在执行,请稍后点击入库执行");
                    }
                }
                else
                    MessageBox.Show("此站台有货物正在出库,请稍后入库");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void SetControlEmpty()
        {
            this.txtBarcode.Text = "";
            this.txtCellCode.Text = "";

        }
        private void SetDataSource(DataTable dt)
        {
            if (dtSource == null)
            {
                dtSource = dt.Clone();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] drs = dtSource.Select("TaskNo='" + dt.Rows[i]["TaskNo"].ToString() + "'");
                if (drs.Length > 0)
                    continue;

                drs = dtSource.Select("ProductCode<>'" + dt.Rows[i]["ProductCode"].ToString() + "'");
                if (drs.Length > 0)
                {
                    MCP.Logger.Info("不同物料，不能同时存放同一个货位！");
                    continue;
                }


                DataRow dr = dt.Rows[i];
                dtSource.Rows.Add(dr.ItemArray);
            }
            this.txtBarcode.Text = "";
            this.bsMain.DataSource = dtSource;
        }

        

        private void frmInStockTask_Activated(object sender, EventArgs e)
        {
            this.txtBarcode.Focus();
        }

        private void cmbAisleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbAisleNo.Text == "System.Data.DataRowView")
                return;

            DataParameter[] param = new DataParameter[] 
            { 
                new DataParameter("{0}", string.Format("CraneNo='{0}' and  StationNo='{1}' and AisleNo='{2}' and AreaCode='{3}'",this.CraneNo, this.cmbAisleNo.Text,this.cmbAisleNo.Text,this.AreaCode))
            };
            DataTable dt = bll.FillDataTable("CMD.SelectCellShelf", param);
            this.cbRow.DataSource = dt.DefaultView;
            this.cbRow.ValueMember = "shelfcode";
            this.cbRow.DisplayMember = "shelfcode";
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.CurrentRow == null)
                return;
            if (this.dgvMain.CurrentRow.Index >= 0)
            {
                DataRow[] drs = dtSource.Select("TaskNo='" + this.dgvMain.CurrentRow.Cells["colTaskNo"].Value.ToString() + "'");
                if (drs.Length > 0)
                    dtSource.Rows.Remove(drs[0]);
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtBarcode.Text.Trim().Length == 0)
                    return;
                //根据熔次卷号获取任务
                DataTable dt = bll.FillDataTable("WCS.GetTaskByBarcode", new DataParameter[] { new DataParameter("@Barcode", this.txtBarcode.Text.Trim()) });

                //bll.ExecNonQuery("WCS.updateCrane", new DataParameter[] { new DataParameter("{0}", this.CraneNo), new DataParameter("{1}", this.txtBarcode.Text.Trim()) });
                

                if (dt.Rows.Count > 0)
                {
                    SetDataSource(dt);
                }
                else
                {
                    MCP.Logger.Error("此熔次卷号 " + this.txtBarcode.Text.Trim() + " 不存在，或已经扫描入库！");
                    this.txtBarcode.Text = "";
                }
 
            }

        }       
    }
}
