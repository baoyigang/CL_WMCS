namespace ProductionKB
{
    partial class TdTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.TaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdcutCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromCellCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToCellCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CraneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AisleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1660, 759);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(1660, 364);
            this.splitContainer2.SplitterDistance = 116;
            this.splitContainer2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(744, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前执行入库任务";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 56;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskNo,
            this.State,
            this.ProdcutCode,
            this.Spec,
            this.ProductName,
            this.BarCode,
            this.FromCellCode,
            this.ToCellCode,
            this.CraneNo,
            this.AisleNo,
            this.BillNo,
            this.ErrorFlag,
            this.ErrorDesc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1660, 244);
            this.dataGridView1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Size = new System.Drawing.Size(1660, 391);
            this.splitContainer3.SplitterDistance = 118;
            this.splitContainer3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(556, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(549, 86);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前执行出库任务";
            // 
            // TaskNo
            // 
            this.TaskNo.HeaderText = "任务号";
            this.TaskNo.Name = "TaskNo";
            this.TaskNo.Width = 200;
            // 
            // State
            // 
            this.State.HeaderText = "状态";
            this.State.Name = "State";
            // 
            // ProdcutCode
            // 
            this.ProdcutCode.HeaderText = "产品编码";
            this.ProdcutCode.Name = "ProdcutCode";
            // 
            // Spec
            // 
            this.Spec.HeaderText = "产品规格";
            this.Spec.Name = "Spec";
            this.Spec.Width = 250;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "产品名称";
            this.ProductName.Name = "ProductName";
            // 
            // BarCode
            // 
            this.BarCode.HeaderText = "熔次卷号";
            this.BarCode.Name = "BarCode";
            this.BarCode.Width = 215;
            // 
            // FromCellCode
            // 
            this.FromCellCode.HeaderText = "起始地址";
            this.FromCellCode.Name = "FromCellCode";
            this.FromCellCode.Width = 150;
            // 
            // ToCellCode
            // 
            this.ToCellCode.HeaderText = "目标地址";
            this.ToCellCode.Name = "ToCellCode";
            this.ToCellCode.Width = 150;
            // 
            // CraneNo
            // 
            this.CraneNo.HeaderText = "堆垛机";
            this.CraneNo.Name = "CraneNo";
            // 
            // AisleNo
            // 
            this.AisleNo.HeaderText = "巷道号";
            this.AisleNo.Name = "AisleNo";
            // 
            // BillNo
            // 
            this.BillNo.HeaderText = "单据号码";
            this.BillNo.Name = "BillNo";
            this.BillNo.Width = 200;
            // 
            // ErrorFlag
            // 
            this.ErrorFlag.HeaderText = "错误代码";
            this.ErrorFlag.Name = "ErrorFlag";
            // 
            // ErrorDesc
            // 
            this.ErrorDesc.HeaderText = "错误描述";
            this.ErrorDesc.Name = "ErrorDesc";
            this.ErrorDesc.Width = 150;
            // 
            // TdTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1660, 759);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TdTask";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdcutCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromCellCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToCellCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CraneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AisleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorDesc;
    }
}