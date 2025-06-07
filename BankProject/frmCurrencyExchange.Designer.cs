namespace BankProject
{
    partial class frmCurrencyExchange
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblCurrentUserName = new System.Windows.Forms.Label();
            this.tpCurrencyExchange = new System.Windows.Forms.TabControl();
            this.tpShowAllCurrency = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSortDesc = new System.Windows.Forms.RadioButton();
            this.rbSortAsc = new System.Windows.Forms.RadioButton();
            this.lvShowAllCurremcies = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblCountCurrency = new System.Windows.Forms.Label();
            this.tpUpdateRate = new System.Windows.Forms.TabPage();
            this.btnToRetreatInUpdateCurrency = new System.Windows.Forms.Button();
            this.btnUpdateRate = new System.Windows.Forms.Button();
            this.pUpdateCurrency = new System.Windows.Forms.Panel();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.nudNewRate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tpCurrencyCalculator = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.pConvert = new System.Windows.Forms.Panel();
            this.lblConvertTo = new System.Windows.Forms.Label();
            this.lblConvert = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.nudAmountToExchange = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.pConvertTo = new System.Windows.Forms.Panel();
            this.lblTCountry = new System.Windows.Forms.Label();
            this.lblTCode = new System.Windows.Forms.Label();
            this.lblTName = new System.Windows.Forms.Label();
            this.lblTRate = new System.Windows.Forms.Label();
            this.pConvertFrom = new System.Windows.Forms.Panel();
            this.lblFCountry = new System.Windows.Forms.Label();
            this.lblFCode = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblFRate = new System.Windows.Forms.Label();
            this.cbConvertTo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbConvretFrom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrencyTimer = new System.Windows.Forms.Timer(this.components);
            this.txtSearchCurrency = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.updateCurrencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currencyFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tpCurrencyExchange.SuspendLayout();
            this.tpShowAllCurrency.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tpUpdateRate.SuspendLayout();
            this.pUpdateCurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewRate)).BeginInit();
            this.tpCurrencyCalculator.SuspendLayout();
            this.pConvert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountToExchange)).BeginInit();
            this.pConvertTo.SuspendLayout();
            this.pConvertFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblCurrentUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 530);
            this.panel1.TabIndex = 1;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe Print", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Gray;
            this.lblDateTime.Location = new System.Drawing.Point(38, 270);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(39, 28);
            this.lblDateTime.TabIndex = 41;
            this.lblDateTime.Text = "asd";
            // 
            // lblCurrentUserName
            // 
            this.lblCurrentUserName.AutoSize = true;
            this.lblCurrentUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentUserName.Font = new System.Drawing.Font("Segoe Print", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUserName.ForeColor = System.Drawing.Color.Gray;
            this.lblCurrentUserName.Location = new System.Drawing.Point(38, 226);
            this.lblCurrentUserName.Name = "lblCurrentUserName";
            this.lblCurrentUserName.Size = new System.Drawing.Size(39, 28);
            this.lblCurrentUserName.TabIndex = 40;
            this.lblCurrentUserName.Text = "asd";
            // 
            // tpCurrencyExchange
            // 
            this.tpCurrencyExchange.Controls.Add(this.tpShowAllCurrency);
            this.tpCurrencyExchange.Controls.Add(this.tpUpdateRate);
            this.tpCurrencyExchange.Controls.Add(this.tpCurrencyCalculator);
            this.tpCurrencyExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpCurrencyExchange.Location = new System.Drawing.Point(300, 0);
            this.tpCurrencyExchange.Name = "tpCurrencyExchange";
            this.tpCurrencyExchange.SelectedIndex = 0;
            this.tpCurrencyExchange.Size = new System.Drawing.Size(1006, 530);
            this.tpCurrencyExchange.TabIndex = 2;
            // 
            // tpShowAllCurrency
            // 
            this.tpShowAllCurrency.Controls.Add(this.txtSearchCurrency);
            this.tpShowAllCurrency.Controls.Add(this.pictureBox7);
            this.tpShowAllCurrency.Controls.Add(this.label1);
            this.tpShowAllCurrency.Controls.Add(this.label19);
            this.tpShowAllCurrency.Controls.Add(this.lblUserName);
            this.tpShowAllCurrency.Controls.Add(this.groupBox1);
            this.tpShowAllCurrency.Controls.Add(this.lvShowAllCurremcies);
            this.tpShowAllCurrency.Controls.Add(this.lblCountCurrency);
            this.tpShowAllCurrency.Location = new System.Drawing.Point(4, 22);
            this.tpShowAllCurrency.Name = "tpShowAllCurrency";
            this.tpShowAllCurrency.Padding = new System.Windows.Forms.Padding(3);
            this.tpShowAllCurrency.Size = new System.Drawing.Size(998, 504);
            this.tpShowAllCurrency.TabIndex = 0;
            this.tpShowAllCurrency.Text = "Show Currency";
            this.tpShowAllCurrency.UseVisualStyleBackColor = true;
            this.tpShowAllCurrency.Enter += new System.EventHandler(this.tpShowAllCurrency_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 55;
            this.label1.Text = "Code/Country";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Segoe Print", 20.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(375, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(294, 47);
            this.label19.TabIndex = 54;
            this.label19.Text = "Show All Currencies";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserName.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Red;
            this.lblUserName.Location = new System.Drawing.Point(27, 56);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(136, 22);
            this.lblUserName.TabIndex = 49;
            this.lblUserName.Text = "Search Currency";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSortDesc);
            this.groupBox1.Controls.Add(this.rbSortAsc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(830, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 51);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorting";
            // 
            // rbSortDesc
            // 
            this.rbSortDesc.AutoSize = true;
            this.rbSortDesc.Location = new System.Drawing.Point(92, 24);
            this.rbSortDesc.Name = "rbSortDesc";
            this.rbSortDesc.Size = new System.Drawing.Size(50, 17);
            this.rbSortDesc.TabIndex = 9;
            this.rbSortDesc.TabStop = true;
            this.rbSortDesc.Text = "Desc";
            this.rbSortDesc.UseVisualStyleBackColor = true;
            this.rbSortDesc.Click += new System.EventHandler(this.rbSortAsc_Click);
            // 
            // rbSortAsc
            // 
            this.rbSortAsc.AutoSize = true;
            this.rbSortAsc.Location = new System.Drawing.Point(24, 24);
            this.rbSortAsc.Name = "rbSortAsc";
            this.rbSortAsc.Size = new System.Drawing.Size(43, 17);
            this.rbSortAsc.TabIndex = 8;
            this.rbSortAsc.TabStop = true;
            this.rbSortAsc.Text = "Asc";
            this.rbSortAsc.UseVisualStyleBackColor = true;
            this.rbSortAsc.Click += new System.EventHandler(this.rbSortAsc_Click);
            // 
            // lvShowAllCurremcies
            // 
            this.lvShowAllCurremcies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lvShowAllCurremcies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvShowAllCurremcies.ContextMenuStrip = this.contextMenuStrip1;
            this.lvShowAllCurremcies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lvShowAllCurremcies.ForeColor = System.Drawing.Color.Black;
            this.lvShowAllCurremcies.GridLines = true;
            this.lvShowAllCurremcies.HideSelection = false;
            this.lvShowAllCurremcies.Location = new System.Drawing.Point(155, 192);
            this.lvShowAllCurremcies.Name = "lvShowAllCurremcies";
            this.lvShowAllCurremcies.Size = new System.Drawing.Size(687, 287);
            this.lvShowAllCurremcies.TabIndex = 52;
            this.lvShowAllCurremcies.UseCompatibleStateImageBehavior = false;
            this.lvShowAllCurremcies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Code";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Country";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rate/(1$)";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateCurrencyToolStripMenuItem,
            this.currencyFromToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // lblCountCurrency
            // 
            this.lblCountCurrency.AutoSize = true;
            this.lblCountCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCountCurrency.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountCurrency.ForeColor = System.Drawing.Color.Red;
            this.lblCountCurrency.Location = new System.Drawing.Point(27, 153);
            this.lblCountCurrency.Name = "lblCountCurrency";
            this.lblCountCurrency.Size = new System.Drawing.Size(151, 22);
            this.lblCountCurrency.TabIndex = 51;
            this.lblCountCurrency.Text = "Search User Name";
            // 
            // tpUpdateRate
            // 
            this.tpUpdateRate.BackColor = System.Drawing.Color.White;
            this.tpUpdateRate.Controls.Add(this.pictureBox2);
            this.tpUpdateRate.Controls.Add(this.btnToRetreatInUpdateCurrency);
            this.tpUpdateRate.Controls.Add(this.btnUpdateRate);
            this.tpUpdateRate.Controls.Add(this.pUpdateCurrency);
            this.tpUpdateRate.Controls.Add(this.nudNewRate);
            this.tpUpdateRate.Controls.Add(this.label6);
            this.tpUpdateRate.Controls.Add(this.label2);
            this.tpUpdateRate.Controls.Add(this.cbCode);
            this.tpUpdateRate.Controls.Add(this.label16);
            this.tpUpdateRate.Location = new System.Drawing.Point(4, 22);
            this.tpUpdateRate.Name = "tpUpdateRate";
            this.tpUpdateRate.Padding = new System.Windows.Forms.Padding(3);
            this.tpUpdateRate.Size = new System.Drawing.Size(998, 504);
            this.tpUpdateRate.TabIndex = 1;
            this.tpUpdateRate.Text = "Update Rate";
            // 
            // btnToRetreatInUpdateCurrency
            // 
            this.btnToRetreatInUpdateCurrency.BackColor = System.Drawing.Color.White;
            this.btnToRetreatInUpdateCurrency.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnToRetreatInUpdateCurrency.FlatAppearance.BorderSize = 2;
            this.btnToRetreatInUpdateCurrency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnToRetreatInUpdateCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnToRetreatInUpdateCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToRetreatInUpdateCurrency.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToRetreatInUpdateCurrency.ForeColor = System.Drawing.Color.Red;
            this.btnToRetreatInUpdateCurrency.Location = new System.Drawing.Point(299, 412);
            this.btnToRetreatInUpdateCurrency.Name = "btnToRetreatInUpdateCurrency";
            this.btnToRetreatInUpdateCurrency.Size = new System.Drawing.Size(228, 52);
            this.btnToRetreatInUpdateCurrency.TabIndex = 79;
            this.btnToRetreatInUpdateCurrency.Text = "To Retreat";
            this.btnToRetreatInUpdateCurrency.UseVisualStyleBackColor = false;
            this.btnToRetreatInUpdateCurrency.Visible = false;
            this.btnToRetreatInUpdateCurrency.Click += new System.EventHandler(this.btnToRetreat_Click);
            // 
            // btnUpdateRate
            // 
            this.btnUpdateRate.BackColor = System.Drawing.Color.White;
            this.btnUpdateRate.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnUpdateRate.FlatAppearance.BorderSize = 2;
            this.btnUpdateRate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnUpdateRate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnUpdateRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRate.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRate.ForeColor = System.Drawing.Color.Red;
            this.btnUpdateRate.Location = new System.Drawing.Point(38, 412);
            this.btnUpdateRate.Name = "btnUpdateRate";
            this.btnUpdateRate.Size = new System.Drawing.Size(228, 52);
            this.btnUpdateRate.TabIndex = 78;
            this.btnUpdateRate.Text = "Update Rate";
            this.btnUpdateRate.UseVisualStyleBackColor = false;
            this.btnUpdateRate.Click += new System.EventHandler(this.btnUpdateRate_Click);
            // 
            // pUpdateCurrency
            // 
            this.pUpdateCurrency.BackColor = System.Drawing.Color.LightGray;
            this.pUpdateCurrency.Controls.Add(this.lblCountry);
            this.pUpdateCurrency.Controls.Add(this.lblCode);
            this.pUpdateCurrency.Controls.Add(this.lblName);
            this.pUpdateCurrency.Controls.Add(this.lblRate);
            this.pUpdateCurrency.Location = new System.Drawing.Point(299, 116);
            this.pUpdateCurrency.Name = "pUpdateCurrency";
            this.pUpdateCurrency.Size = new System.Drawing.Size(303, 202);
            this.pUpdateCurrency.TabIndex = 77;
            this.pUpdateCurrency.Tag = "1";
            this.pUpdateCurrency.Visible = false;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCountry.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCountry.Location = new System.Drawing.Point(15, 22);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(86, 22);
            this.lblCountry.TabIndex = 69;
            this.lblCountry.Text = "Country : ";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCode.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCode.Location = new System.Drawing.Point(15, 68);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(64, 22);
            this.lblCode.TabIndex = 72;
            this.lblCode.Text = "Code : ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(15, 114);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 22);
            this.lblName.TabIndex = 73;
            this.lblName.Text = "Name : ";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRate.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRate.Location = new System.Drawing.Point(15, 160);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(59, 22);
            this.lblRate.TabIndex = 74;
            this.lblRate.Text = "Rate : ";
            // 
            // nudNewRate
            // 
            this.nudNewRate.BackColor = System.Drawing.Color.Maroon;
            this.nudNewRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.nudNewRate.Location = new System.Drawing.Point(38, 345);
            this.nudNewRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudNewRate.Name = "nudNewRate";
            this.nudNewRate.Size = new System.Drawing.Size(188, 29);
            this.nudNewRate.TabIndex = 76;
            this.nudNewRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(38, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 22);
            this.label6.TabIndex = 75;
            this.label6.Text = "New Rate ($)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 20.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(403, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 47);
            this.label2.TabIndex = 71;
            this.label2.Text = "Update Rate";
            // 
            // cbCode
            // 
            this.cbCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Location = new System.Drawing.Point(38, 157);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(188, 29);
            this.cbCode.Sorted = true;
            this.cbCode.TabIndex = 68;
            this.cbCode.TextChanged += new System.EventHandler(this.cbCode_TextChanged);
            this.cbCode.Enter += new System.EventHandler(this.cbCode_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(38, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 22);
            this.label16.TabIndex = 67;
            this.label16.Text = "Currency Code : ";
            // 
            // tpCurrencyCalculator
            // 
            this.tpCurrencyCalculator.Controls.Add(this.pictureBox3);
            this.tpCurrencyCalculator.Controls.Add(this.btnReset);
            this.tpCurrencyCalculator.Controls.Add(this.pConvert);
            this.tpCurrencyCalculator.Controls.Add(this.btnConvert);
            this.tpCurrencyCalculator.Controls.Add(this.nudAmountToExchange);
            this.tpCurrencyCalculator.Controls.Add(this.label15);
            this.tpCurrencyCalculator.Controls.Add(this.pConvertTo);
            this.tpCurrencyCalculator.Controls.Add(this.pConvertFrom);
            this.tpCurrencyCalculator.Controls.Add(this.cbConvertTo);
            this.tpCurrencyCalculator.Controls.Add(this.label14);
            this.tpCurrencyCalculator.Controls.Add(this.cbConvretFrom);
            this.tpCurrencyCalculator.Controls.Add(this.label4);
            this.tpCurrencyCalculator.Controls.Add(this.label3);
            this.tpCurrencyCalculator.Location = new System.Drawing.Point(4, 22);
            this.tpCurrencyCalculator.Name = "tpCurrencyCalculator";
            this.tpCurrencyCalculator.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrencyCalculator.Size = new System.Drawing.Size(998, 504);
            this.tpCurrencyCalculator.TabIndex = 2;
            this.tpCurrencyCalculator.Text = "Currency Calculator";
            this.tpCurrencyCalculator.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnReset.FlatAppearance.BorderSize = 2;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(187, 405);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(142, 52);
            this.btnReset.TabIndex = 85;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pConvert
            // 
            this.pConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pConvert.Controls.Add(this.lblConvertTo);
            this.pConvert.Controls.Add(this.lblConvert);
            this.pConvert.Location = new System.Drawing.Point(349, 353);
            this.pConvert.Name = "pConvert";
            this.pConvert.Size = new System.Drawing.Size(633, 128);
            this.pConvert.TabIndex = 82;
            this.pConvert.Visible = false;
            // 
            // lblConvertTo
            // 
            this.lblConvertTo.AutoSize = true;
            this.lblConvertTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConvertTo.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConvertTo.Location = new System.Drawing.Point(24, 55);
            this.lblConvertTo.Name = "lblConvertTo";
            this.lblConvertTo.Size = new System.Drawing.Size(86, 22);
            this.lblConvertTo.TabIndex = 70;
            this.lblConvertTo.Text = "Country : ";
            // 
            // lblConvert
            // 
            this.lblConvert.AutoSize = true;
            this.lblConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConvert.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConvert.Location = new System.Drawing.Point(24, 24);
            this.lblConvert.Name = "lblConvert";
            this.lblConvert.Size = new System.Drawing.Size(86, 22);
            this.lblConvert.TabIndex = 69;
            this.lblConvert.Text = "Country : ";
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.White;
            this.btnConvert.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnConvert.FlatAppearance.BorderSize = 2;
            this.btnConvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnConvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.Red;
            this.btnConvert.Location = new System.Drawing.Point(27, 405);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(142, 52);
            this.btnConvert.TabIndex = 84;
            this.btnConvert.Text = "Convert ";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // nudAmountToExchange
            // 
            this.nudAmountToExchange.BackColor = System.Drawing.Color.Maroon;
            this.nudAmountToExchange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.nudAmountToExchange.Location = new System.Drawing.Point(27, 370);
            this.nudAmountToExchange.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAmountToExchange.Name = "nudAmountToExchange";
            this.nudAmountToExchange.Size = new System.Drawing.Size(188, 29);
            this.nudAmountToExchange.TabIndex = 83;
            this.nudAmountToExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(23, 336);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(185, 22);
            this.label15.TabIndex = 82;
            this.label15.Text = "Amount to Exchange : ";
            // 
            // pConvertTo
            // 
            this.pConvertTo.BackColor = System.Drawing.Color.LightGray;
            this.pConvertTo.Controls.Add(this.lblTCountry);
            this.pConvertTo.Controls.Add(this.lblTCode);
            this.pConvertTo.Controls.Add(this.lblTName);
            this.pConvertTo.Controls.Add(this.lblTRate);
            this.pConvertTo.Location = new System.Drawing.Point(705, 182);
            this.pConvertTo.Name = "pConvertTo";
            this.pConvertTo.Size = new System.Drawing.Size(277, 139);
            this.pConvertTo.TabIndex = 81;
            this.pConvertTo.Visible = false;
            // 
            // lblTCountry
            // 
            this.lblTCountry.AutoSize = true;
            this.lblTCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTCountry.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTCountry.Location = new System.Drawing.Point(20, 10);
            this.lblTCountry.Name = "lblTCountry";
            this.lblTCountry.Size = new System.Drawing.Size(70, 18);
            this.lblTCountry.TabIndex = 69;
            this.lblTCountry.Text = "Country : ";
            // 
            // lblTCode
            // 
            this.lblTCode.AutoSize = true;
            this.lblTCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTCode.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTCode.Location = new System.Drawing.Point(20, 41);
            this.lblTCode.Name = "lblTCode";
            this.lblTCode.Size = new System.Drawing.Size(51, 18);
            this.lblTCode.TabIndex = 72;
            this.lblTCode.Text = "Code : ";
            // 
            // lblTName
            // 
            this.lblTName.AutoSize = true;
            this.lblTName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTName.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTName.Location = new System.Drawing.Point(20, 72);
            this.lblTName.Name = "lblTName";
            this.lblTName.Size = new System.Drawing.Size(55, 18);
            this.lblTName.TabIndex = 73;
            this.lblTName.Text = "Name : ";
            // 
            // lblTRate
            // 
            this.lblTRate.AutoSize = true;
            this.lblTRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTRate.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTRate.Location = new System.Drawing.Point(20, 103);
            this.lblTRate.Name = "lblTRate";
            this.lblTRate.Size = new System.Drawing.Size(47, 18);
            this.lblTRate.TabIndex = 74;
            this.lblTRate.Text = "Rate : ";
            // 
            // pConvertFrom
            // 
            this.pConvertFrom.BackColor = System.Drawing.Color.LightGray;
            this.pConvertFrom.Controls.Add(this.lblFCountry);
            this.pConvertFrom.Controls.Add(this.lblFCode);
            this.pConvertFrom.Controls.Add(this.lblFName);
            this.pConvertFrom.Controls.Add(this.lblFRate);
            this.pConvertFrom.Location = new System.Drawing.Point(27, 182);
            this.pConvertFrom.Name = "pConvertFrom";
            this.pConvertFrom.Size = new System.Drawing.Size(277, 139);
            this.pConvertFrom.TabIndex = 78;
            this.pConvertFrom.Visible = false;
            // 
            // lblFCountry
            // 
            this.lblFCountry.AutoSize = true;
            this.lblFCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFCountry.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFCountry.Location = new System.Drawing.Point(20, 10);
            this.lblFCountry.Name = "lblFCountry";
            this.lblFCountry.Size = new System.Drawing.Size(70, 18);
            this.lblFCountry.TabIndex = 69;
            this.lblFCountry.Text = "Country : ";
            // 
            // lblFCode
            // 
            this.lblFCode.AutoSize = true;
            this.lblFCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFCode.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFCode.Location = new System.Drawing.Point(20, 41);
            this.lblFCode.Name = "lblFCode";
            this.lblFCode.Size = new System.Drawing.Size(51, 18);
            this.lblFCode.TabIndex = 72;
            this.lblFCode.Text = "Code : ";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFName.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFName.Location = new System.Drawing.Point(20, 72);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(55, 18);
            this.lblFName.TabIndex = 73;
            this.lblFName.Text = "Name : ";
            // 
            // lblFRate
            // 
            this.lblFRate.AutoSize = true;
            this.lblFRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFRate.Font = new System.Drawing.Font("Segoe Marker", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFRate.Location = new System.Drawing.Point(20, 103);
            this.lblFRate.Name = "lblFRate";
            this.lblFRate.Size = new System.Drawing.Size(47, 18);
            this.lblFRate.TabIndex = 74;
            this.lblFRate.Text = "Rate : ";
            // 
            // cbConvertTo
            // 
            this.cbConvertTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConvertTo.FormattingEnabled = true;
            this.cbConvertTo.Location = new System.Drawing.Point(705, 122);
            this.cbConvertTo.Name = "cbConvertTo";
            this.cbConvertTo.Size = new System.Drawing.Size(188, 29);
            this.cbConvertTo.Sorted = true;
            this.cbConvertTo.TabIndex = 80;
            this.cbConvertTo.TextChanged += new System.EventHandler(this.cbConvertTo_TextChanged);
            this.cbConvertTo.Enter += new System.EventHandler(this.cbConvertTo_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(705, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 22);
            this.label14.TabIndex = 79;
            this.label14.Text = "Convert To : ";
            // 
            // cbConvretFrom
            // 
            this.cbConvretFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConvretFrom.FormattingEnabled = true;
            this.cbConvretFrom.Location = new System.Drawing.Point(27, 122);
            this.cbConvretFrom.Name = "cbConvretFrom";
            this.cbConvretFrom.Size = new System.Drawing.Size(188, 29);
            this.cbConvretFrom.Sorted = true;
            this.cbConvretFrom.TabIndex = 74;
            this.cbConvretFrom.TextChanged += new System.EventHandler(this.cbConvretFrom_TextChanged);
            this.cbConvretFrom.Enter += new System.EventHandler(this.cbConvretFrom_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(27, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 22);
            this.label4.TabIndex = 73;
            this.label4.Text = "Convert From : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 20.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(361, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 47);
            this.label3.TabIndex = 72;
            this.label3.Text = "Currency Calculator";
            // 
            // CurrencyTimer
            // 
            this.CurrencyTimer.Enabled = true;
            this.CurrencyTimer.Tick += new System.EventHandler(this.CurrencyTimer_Tick);
            // 
            // txtSearchCurrency
            // 
            this.txtSearchCurrency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchCurrency.DefaultText = "";
            this.txtSearchCurrency.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchCurrency.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchCurrency.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchCurrency.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchCurrency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchCurrency.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtSearchCurrency.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchCurrency.IconRight = global::BankProject.Properties.Resources.SearchIcon;
            this.txtSearchCurrency.Location = new System.Drawing.Point(31, 104);
            this.txtSearchCurrency.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.txtSearchCurrency.Name = "txtSearchCurrency";
            this.txtSearchCurrency.PlaceholderText = "";
            this.txtSearchCurrency.SelectedText = "";
            this.txtSearchCurrency.Size = new System.Drawing.Size(169, 36);
            this.txtSearchCurrency.TabIndex = 91;
            this.txtSearchCurrency.TextChanged += new System.EventHandler(this.txtSearchCurrency_TextChanged_1);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BankProject.Properties.Resources.allcurrency;
            this.pictureBox7.Location = new System.Drawing.Point(425, 67);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(184, 119);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 88;
            this.pictureBox7.TabStop = false;
            // 
            // updateCurrencyToolStripMenuItem
            // 
            this.updateCurrencyToolStripMenuItem.Image = global::BankProject.Properties.Resources.updaterate;
            this.updateCurrencyToolStripMenuItem.Name = "updateCurrencyToolStripMenuItem";
            this.updateCurrencyToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.updateCurrencyToolStripMenuItem.Text = "Update Currency";
            this.updateCurrencyToolStripMenuItem.Click += new System.EventHandler(this.updateCurrencyToolStripMenuItem_Click);
            // 
            // currencyFromToolStripMenuItem
            // 
            this.currencyFromToolStripMenuItem.Image = global::BankProject.Properties.Resources.currencyexchange;
            this.currencyFromToolStripMenuItem.Name = "currencyFromToolStripMenuItem";
            this.currencyFromToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.currencyFromToolStripMenuItem.Text = "Currency From";
            this.currencyFromToolStripMenuItem.Click += new System.EventHandler(this.currencyFromToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankProject.Properties.Resources.updaterate;
            this.pictureBox2.Location = new System.Drawing.Point(732, 123);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(212, 188);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BankProject.Properties.Resources.currencyexchange;
            this.pictureBox3.Location = new System.Drawing.Point(416, 104);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(197, 168);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 88;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankProject.Properties.Resources.BankPhoto;
            this.pictureBox1.Location = new System.Drawing.Point(43, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmCurrencyExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 530);
            this.Controls.Add(this.tpCurrencyExchange);
            this.Controls.Add(this.panel1);
            this.Name = "frmCurrencyExchange";
            this.Text = "Currency Exchange";
            this.Load += new System.EventHandler(this.frmCurrencyExchange_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpCurrencyExchange.ResumeLayout(false);
            this.tpShowAllCurrency.ResumeLayout(false);
            this.tpShowAllCurrency.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpUpdateRate.ResumeLayout(false);
            this.tpUpdateRate.PerformLayout();
            this.pUpdateCurrency.ResumeLayout(false);
            this.pUpdateCurrency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewRate)).EndInit();
            this.tpCurrencyCalculator.ResumeLayout(false);
            this.tpCurrencyCalculator.PerformLayout();
            this.pConvert.ResumeLayout(false);
            this.pConvert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountToExchange)).EndInit();
            this.pConvertTo.ResumeLayout(false);
            this.pConvertTo.PerformLayout();
            this.pConvertFrom.ResumeLayout(false);
            this.pConvertFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCurrentUserName;
        private System.Windows.Forms.TabControl tpCurrencyExchange;
        private System.Windows.Forms.TabPage tpShowAllCurrency;
        private System.Windows.Forms.TabPage tpUpdateRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSortDesc;
        private System.Windows.Forms.RadioButton rbSortAsc;
        private System.Windows.Forms.ListView lvShowAllCurremcies;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblCountCurrency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudNewRate;
        private System.Windows.Forms.Panel pUpdateCurrency;
        private System.Windows.Forms.Button btnUpdateRate;
        private System.Windows.Forms.Button btnToRetreatInUpdateCurrency;
        private System.Windows.Forms.TabPage tpCurrencyCalculator;
        private System.Windows.Forms.Panel pConvertTo;
        private System.Windows.Forms.Label lblTCountry;
        private System.Windows.Forms.Label lblTCode;
        private System.Windows.Forms.Label lblTName;
        private System.Windows.Forms.Label lblTRate;
        private System.Windows.Forms.Panel pConvertFrom;
        private System.Windows.Forms.Label lblFCountry;
        private System.Windows.Forms.Label lblFCode;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblFRate;
        private System.Windows.Forms.ComboBox cbConvertTo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbConvretFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pConvert;
        private System.Windows.Forms.Label lblConvert;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.NumericUpDown nudAmountToExchange;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblConvertTo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer CurrencyTimer;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchCurrency;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateCurrencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currencyFromToolStripMenuItem;
    }
}