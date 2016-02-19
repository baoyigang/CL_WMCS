using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDAL;

namespace App.View.Task
{
    public partial class frmInStockTask : Form
    {
        BLL.BLLBase bll = new BLL.BLLBase();
        string CraneNo = "01";
        public frmInStockTask()
        {
            InitializeComponent();
        }

        private void frmInStockTask_Load(object sender, EventArgs e)
        {

            DataTable dt = bll.FillDataTable("WCS.SelectStationNo");
            this.cmbStationNo.DataSource = dt.DefaultView;
            this.cmbStationNo.ValueMember = "StationNo";
            this.cmbStationNo.DisplayMember = "StationNo";
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
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
            DataParameter[] param = new DataParameter[] 
            { 
                new DataParameter("{0}", string.Format("StationNo='{0}'", this.cmbStationNo.Text))
            };
            DataTable dt = bll.FillDataTable("CMD.SelectCellShelf", param);
            this.cbRow.DataSource = dt.DefaultView;
            this.cbRow.ValueMember = "shelfcode";
            this.cbRow.DisplayMember = "shelfcode";
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
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataParameter[] param;

            param = new DataParameter[] 
            { 
                new DataParameter("@StationNo", this.cmbStationNo.Text), 
                new DataParameter("@AreaCode", this.txtAreaCode.Text) 
            };
            

                if (this.radioButton1.Checked)
                {
                    dt = bll.FillDataTable("WCS.sp_GetCell", param);
                    if (dt.Rows.Count > 0)
                        this.txtCellCode.Text = dt.Rows[0][0].ToString();
                    else
                        this.txtCellCode.Text = "";
                }
                else
                {
                    this.txtCellCode.Text = this.cbRow.Text.Substring(3, 3) + (1000 + int.Parse(this.cbColumn.Text)).ToString().Substring(1, 3) + (1000 + int.Parse(this.cbHeight.Text)).ToString().Substring(1, 3);
                }
                

                //判断货位是否为空
                param = new DataParameter[] 
                { 
                    new DataParameter("{0}", string.Format("CellCode='{0}' and ProductCode='' and IsActive='1' and IsLock='0' and AreaCode='{1}'", this.txtCellCode.Text,this.txtAreaCode.Text))
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
                    new DataParameter("@TaskNo", this.txtTaskNo.Text),
                    new DataParameter("@Station", this.cmbStationNo.Text)
                };
                bll.ExecNonQueryTran("WCS.Sp_ExecuteInStockTask", param);
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            //根据熔次卷号获取任务
            DataTable dt = bll.FillDataTable("WCS.GetTaskByBarcode", new DataParameter[] { new DataParameter("@Barcode", this.txtBarcode.Text.Trim()) });
            if (dt.Rows.Count > 0)
            {
                this.txtTaskNo.Text = dt.Rows[0]["TaskNo"].ToString();
                this.txtBillID.Text = dt.Rows[0]["BillID"].ToString();
                this.txtProductCode.Text = dt.Rows[0]["ProductCode"].ToString();
                this.txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                this.txtAreaCode.Text = dt.Rows[0]["AreaCode"].ToString();
            }
            else
            {
                this.txtTaskNo.Text = "";
                this.txtBillID.Text = "";
                this.txtProductCode.Text = "";
                this.txtProductName.Text = "";
                this.txtAreaCode.Text = "";
            }
        }
    }
}
