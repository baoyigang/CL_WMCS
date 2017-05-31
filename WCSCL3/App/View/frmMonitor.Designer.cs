namespace App.View
{
    partial class frmMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitor));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.picCrane1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userControl11 = new App.TranLineControl();
            this.userControl12 = new App.TranLineControl();
            this.userControl13 = new App.TranLineControl();
            this.userControl14 = new App.TranLineControl();
            this.userControl15 = new App.TranLineControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClearAlarm = new System.Windows.Forms.Button();
            this.txtCraneAction1 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtTaskNo1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRow1 = new System.Windows.Forms.TextBox();
            this.txtState1 = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtColumn1 = new System.Windows.Forms.TextBox();
            this.txtErrorNo1 = new System.Windows.Forms.TextBox();
            this.txtErrorDesc1 = new System.Windows.Forms.TextBox();
            this.txtHeight1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtForkStatus1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCrane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer_Main);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1813, 812);
            this.pnlMain.TabIndex = 3;
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.picCrane1);
            this.splitContainer_Main.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer_Main.Panel1.Controls.Add(this.userControl11);
            this.splitContainer_Main.Panel1.Controls.Add(this.userControl12);
            this.splitContainer_Main.Panel1.Controls.Add(this.userControl13);
            this.splitContainer_Main.Panel1.Controls.Add(this.userControl14);
            this.splitContainer_Main.Panel1.Controls.Add(this.userControl15);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.tabControl);
            this.splitContainer_Main.Size = new System.Drawing.Size(1813, 812);
            this.splitContainer_Main.SplitterDistance = 1457;
            this.splitContainer_Main.TabIndex = 0;
            // 
            // picCrane1
            // 
            this.picCrane1.Image = global::App.Properties.Resources.Crane11;
            this.picCrane1.Location = new System.Drawing.Point(26, 300);
            this.picCrane1.Margin = new System.Windows.Forms.Padding(2);
            this.picCrane1.Name = "picCrane1";
            this.picCrane1.Size = new System.Drawing.Size(73, 30);
            this.picCrane1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCrane1.TabIndex = 1;
            this.picCrane1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::App.Properties.Resources._67库;
            this.pictureBox1.Location = new System.Drawing.Point(165, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1260, 559);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // userControl11
            // 
            this.userControl11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl11.BackgroundImage")));
            this.userControl11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userControl11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userControl11.Location = new System.Drawing.Point(110, 56);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(55, 74);
            this.userControl11.TabIndex = 3;
            this.userControl11.MouseEnter += new System.EventHandler(this.userControl11_MouseEnter);
            this.userControl11.MouseHover += new System.EventHandler(this.userControl11_MouseHover);
            // 
            // userControl12
            // 
            this.userControl12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl12.BackgroundImage")));
            this.userControl12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userControl12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userControl12.Location = new System.Drawing.Point(110, 128);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(55, 74);
            this.userControl12.TabIndex = 4;
            this.userControl12.MouseHover += new System.EventHandler(this.userControl11_MouseHover);
            // 
            // userControl13
            // 
            this.userControl13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl13.BackgroundImage")));
            this.userControl13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userControl13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userControl13.Location = new System.Drawing.Point(110, 200);
            this.userControl13.Name = "userControl13";
            this.userControl13.Size = new System.Drawing.Size(55, 74);
            this.userControl13.TabIndex = 5;
            this.userControl13.MouseHover += new System.EventHandler(this.userControl11_MouseHover);
            // 
            // userControl14
            // 
            this.userControl14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl14.BackgroundImage")));
            this.userControl14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userControl14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userControl14.Location = new System.Drawing.Point(110, 272);
            this.userControl14.Name = "userControl14";
            this.userControl14.Size = new System.Drawing.Size(55, 74);
            this.userControl14.TabIndex = 6;
            this.userControl14.MouseHover += new System.EventHandler(this.userControl11_MouseHover);
            // 
            // userControl15
            // 
            this.userControl15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl15.BackgroundImage")));
            this.userControl15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userControl15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userControl15.Location = new System.Drawing.Point(110, 344);
            this.userControl15.Name = "userControl15";
            this.userControl15.Size = new System.Drawing.Size(55, 74);
            this.userControl15.TabIndex = 7;
            this.userControl15.MouseHover += new System.EventHandler(this.userControl11_MouseHover);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(352, 812);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnClearAlarm);
            this.tabPage2.Controls.Add(this.txtCraneAction1);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.txtTaskNo1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtRow1);
            this.tabPage2.Controls.Add(this.txtState1);
            this.tabPage2.Controls.Add(this.btnBack);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.btnStop);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txtColumn1);
            this.tabPage2.Controls.Add(this.txtErrorNo1);
            this.tabPage2.Controls.Add(this.txtErrorDesc1);
            this.tabPage2.Controls.Add(this.txtHeight1);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtForkStatus1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(344, 786);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "弯道堆垛机";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnClearAlarm
            // 
            this.btnClearAlarm.BackColor = System.Drawing.Color.Lime;
            this.btnClearAlarm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearAlarm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearAlarm.Location = new System.Drawing.Point(127, 278);
            this.btnClearAlarm.Name = "btnClearAlarm";
            this.btnClearAlarm.Size = new System.Drawing.Size(75, 30);
            this.btnClearAlarm.TabIndex = 44;
            this.btnClearAlarm.Text = "解警";
            this.btnClearAlarm.UseVisualStyleBackColor = false;
            this.btnClearAlarm.Click += new System.EventHandler(this.btnClearAlarm2_Click);
            // 
            // txtCraneAction1
            // 
            this.txtCraneAction1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCraneAction1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCraneAction1.Location = new System.Drawing.Point(81, 65);
            this.txtCraneAction1.Name = "txtCraneAction1";
            this.txtCraneAction1.ReadOnly = true;
            this.txtCraneAction1.Size = new System.Drawing.Size(122, 26);
            this.txtCraneAction1.TabIndex = 24;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Snow;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(127, 312);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "复位";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset2_Click);
            // 
            // txtTaskNo1
            // 
            this.txtTaskNo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskNo1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTaskNo1.Location = new System.Drawing.Point(80, 8);
            this.txtTaskNo1.Name = "txtTaskNo1";
            this.txtTaskNo1.ReadOnly = true;
            this.txtTaskNo1.Size = new System.Drawing.Size(122, 26);
            this.txtTaskNo1.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(14, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "当  前  排";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(14, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "工作状态";
            // 
            // txtRow1
            // 
            this.txtRow1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRow1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRow1.Location = new System.Drawing.Point(81, 94);
            this.txtRow1.Name = "txtRow1";
            this.txtRow1.ReadOnly = true;
            this.txtRow1.Size = new System.Drawing.Size(121, 26);
            this.txtRow1.TabIndex = 41;
            // 
            // txtState1
            // 
            this.txtState1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtState1.Location = new System.Drawing.Point(81, 37);
            this.txtState1.Name = "txtState1";
            this.txtState1.ReadOnly = true;
            this.txtState1.Size = new System.Drawing.Size(122, 26);
            this.txtState1.TabIndex = 32;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Lime;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(29, 312);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 38;
            this.btnBack.Text = "召回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(14, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "工作方式";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStop.Location = new System.Drawing.Point(29, 278);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 31;
            this.btnStop.Text = "急停";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(14, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "任务编号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(14, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "错误代码";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(14, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 20);
            this.label14.TabIndex = 40;
            this.label14.Text = "当  前  层";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(14, 186);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "货叉位置";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(14, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "错误描述";
            // 
            // txtColumn1
            // 
            this.txtColumn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumn1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtColumn1.Location = new System.Drawing.Point(81, 124);
            this.txtColumn1.Name = "txtColumn1";
            this.txtColumn1.ReadOnly = true;
            this.txtColumn1.Size = new System.Drawing.Size(121, 26);
            this.txtColumn1.TabIndex = 36;
            // 
            // txtErrorNo1
            // 
            this.txtErrorNo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorNo1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtErrorNo1.Location = new System.Drawing.Point(81, 212);
            this.txtErrorNo1.Name = "txtErrorNo1";
            this.txtErrorNo1.ReadOnly = true;
            this.txtErrorNo1.Size = new System.Drawing.Size(122, 26);
            this.txtErrorNo1.TabIndex = 26;
            // 
            // txtErrorDesc1
            // 
            this.txtErrorDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorDesc1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtErrorDesc1.Location = new System.Drawing.Point(81, 241);
            this.txtErrorDesc1.Name = "txtErrorDesc1";
            this.txtErrorDesc1.ReadOnly = true;
            this.txtErrorDesc1.Size = new System.Drawing.Size(122, 26);
            this.txtErrorDesc1.TabIndex = 34;
            // 
            // txtHeight1
            // 
            this.txtHeight1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeight1.Location = new System.Drawing.Point(81, 154);
            this.txtHeight1.Name = "txtHeight1";
            this.txtHeight1.ReadOnly = true;
            this.txtHeight1.Size = new System.Drawing.Size(121, 26);
            this.txtHeight1.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(14, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 20);
            this.label17.TabIndex = 37;
            this.label17.Text = "当  前  列";
            // 
            // txtForkStatus1
            // 
            this.txtForkStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtForkStatus1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtForkStatus1.Location = new System.Drawing.Point(81, 182);
            this.txtForkStatus1.Name = "txtForkStatus1";
            this.txtForkStatus1.ReadOnly = true;
            this.txtForkStatus1.Size = new System.Drawing.Size(122, 26);
            this.txtForkStatus1.TabIndex = 25;
            // 
            // frmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1813, 812);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMonitor";
            this.Text = "监控";
            this.Load += new System.EventHandler(this.frmMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCrane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCraneAction1;
        private System.Windows.Forms.TextBox txtTaskNo1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRow1;
        private System.Windows.Forms.TextBox txtState1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtColumn1;
        private System.Windows.Forms.TextBox txtErrorNo1;
        private System.Windows.Forms.TextBox txtErrorDesc1;
        private System.Windows.Forms.TextBox txtHeight1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtForkStatus1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCrane1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClearAlarm;
        private TranLineControl userControl11;
        private TranLineControl userControl12;
        private TranLineControl userControl13;
        private TranLineControl userControl14;
        private TranLineControl userControl15;
        private System.Windows.Forms.Button btnReset;
    }
}