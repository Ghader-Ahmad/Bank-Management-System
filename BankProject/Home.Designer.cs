namespace BankProject
{
    partial class Home
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnManageClients = new System.Windows.Forms.Button();
            this.btnClientsTransactions = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnCurrencyExchange = new System.Windows.Forms.Button();
            this.btnRecordTheExist = new System.Windows.Forms.Button();
            this.HomeTime = new System.Windows.Forms.Timer(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 530);
            this.panel1.TabIndex = 0;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe Print", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDateTime.ForeColor = System.Drawing.Color.Gray;
            this.lblDateTime.Location = new System.Drawing.Point(29, 301);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(52, 37);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "asd";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserName.Font = new System.Drawing.Font("Segoe Print", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblUserName.ForeColor = System.Drawing.Color.Gray;
            this.lblUserName.Location = new System.Drawing.Point(29, 257);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(52, 37);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "asd";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankProject.Properties.Resources.BankPhoto;
            this.pictureBox1.Location = new System.Drawing.Point(25, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 223);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnManageClients
            // 
            this.btnManageClients.BackColor = System.Drawing.Color.White;
            this.btnManageClients.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnManageClients.FlatAppearance.BorderSize = 2;
            this.btnManageClients.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnManageClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.btnManageClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageClients.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageClients.ForeColor = System.Drawing.Color.Red;
            this.btnManageClients.Location = new System.Drawing.Point(543, 97);
            this.btnManageClients.Name = "btnManageClients";
            this.btnManageClients.Size = new System.Drawing.Size(403, 62);
            this.btnManageClients.TabIndex = 1;
            this.btnManageClients.Text = "Manage Clients";
            this.btnManageClients.UseVisualStyleBackColor = false;
            this.btnManageClients.Click += new System.EventHandler(this.btnManageClients_Click);
            // 
            // btnClientsTransactions
            // 
            this.btnClientsTransactions.BackColor = System.Drawing.Color.White;
            this.btnClientsTransactions.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnClientsTransactions.FlatAppearance.BorderSize = 2;
            this.btnClientsTransactions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClientsTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnClientsTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientsTransactions.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientsTransactions.ForeColor = System.Drawing.Color.Red;
            this.btnClientsTransactions.Location = new System.Drawing.Point(543, 186);
            this.btnClientsTransactions.Name = "btnClientsTransactions";
            this.btnClientsTransactions.Size = new System.Drawing.Size(403, 62);
            this.btnClientsTransactions.TabIndex = 2;
            this.btnClientsTransactions.Text = "Clients Transactions";
            this.btnClientsTransactions.UseVisualStyleBackColor = false;
            this.btnClientsTransactions.Click += new System.EventHandler(this.btnClientsTransactions_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.BackColor = System.Drawing.Color.White;
            this.btnManageUsers.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnManageUsers.FlatAppearance.BorderSize = 2;
            this.btnManageUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnManageUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.ForeColor = System.Drawing.Color.Red;
            this.btnManageUsers.Location = new System.Drawing.Point(543, 273);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(403, 62);
            this.btnManageUsers.TabIndex = 3;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = false;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnCurrencyExchange
            // 
            this.btnCurrencyExchange.BackColor = System.Drawing.Color.White;
            this.btnCurrencyExchange.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnCurrencyExchange.FlatAppearance.BorderSize = 2;
            this.btnCurrencyExchange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCurrencyExchange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnCurrencyExchange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrencyExchange.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrencyExchange.ForeColor = System.Drawing.Color.Red;
            this.btnCurrencyExchange.Location = new System.Drawing.Point(543, 369);
            this.btnCurrencyExchange.Name = "btnCurrencyExchange";
            this.btnCurrencyExchange.Size = new System.Drawing.Size(403, 62);
            this.btnCurrencyExchange.TabIndex = 4;
            this.btnCurrencyExchange.Text = "Currency Exchange";
            this.btnCurrencyExchange.UseVisualStyleBackColor = false;
            this.btnCurrencyExchange.Click += new System.EventHandler(this.btnCurrencyExchange_Click);
            // 
            // btnRecordTheExist
            // 
            this.btnRecordTheExist.BackColor = System.Drawing.Color.White;
            this.btnRecordTheExist.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnRecordTheExist.FlatAppearance.BorderSize = 2;
            this.btnRecordTheExist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRecordTheExist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnRecordTheExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordTheExist.Font = new System.Drawing.Font("Segoe Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordTheExist.ForeColor = System.Drawing.Color.Red;
            this.btnRecordTheExist.Location = new System.Drawing.Point(543, 456);
            this.btnRecordTheExist.Name = "btnRecordTheExist";
            this.btnRecordTheExist.Size = new System.Drawing.Size(403, 62);
            this.btnRecordTheExist.TabIndex = 5;
            this.btnRecordTheExist.Text = "Record The Exit";
            this.btnRecordTheExist.UseVisualStyleBackColor = false;
            this.btnRecordTheExist.Click += new System.EventHandler(this.btnRecordTheExist_Click);
            // 
            // HomeTime
            // 
            this.HomeTime.Enabled = true;
            this.HomeTime.Tick += new System.EventHandler(this.HomeTime_Tick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Segoe Print", 20.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(647, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(200, 47);
            this.label19.TabIndex = 47;
            this.label19.Text = "Home Screen";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankProject.Properties.Resources.Bank;
            this.pictureBox2.Location = new System.Drawing.Point(969, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 147);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 89;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BankProject.Properties.Resources.Bank;
            this.pictureBox7.Location = new System.Drawing.Point(369, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(140, 147);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 88;
            this.pictureBox7.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1121, 530);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnRecordTheExist);
            this.Controls.Add(this.btnCurrencyExchange);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnClientsTransactions);
            this.Controls.Add(this.btnManageClients);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnManageClients;
        private System.Windows.Forms.Button btnClientsTransactions;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnCurrencyExchange;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnRecordTheExist;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer HomeTime;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}