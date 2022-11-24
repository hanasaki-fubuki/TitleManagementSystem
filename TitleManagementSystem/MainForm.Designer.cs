using System.ComponentModel;

namespace TitleManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnChPwd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAdmin1 = new System.Windows.Forms.Button();
            this.lblPrivilege = new System.Windows.Forms.Label();
            this.btnAdmin2 = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnJobTransfer = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.lblJobPrivilege = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtMainSearch = new System.Windows.Forms.TextBox();
            this.cboColumn = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnLogout);
            this.groupBox1.Controls.Add(this.lblUid);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblPosition);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblPhone);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.lblGender);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Infomation";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(245, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(132, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit System";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(245, 67);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(132, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout Session";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUid
            // 
            this.lblUid.Location = new System.Drawing.Point(302, 26);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(75, 23);
            this.lblUid.TabIndex = 11;
            this.lblUid.Text = "lblUid";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(245, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "UID:";
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(302, 49);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(75, 23);
            this.lblPosition.TabIndex = 9;
            this.lblPosition.Text = "lblPosition";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(245, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Position:";
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(65, 95);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(174, 23);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "lblPhone";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(65, 72);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(174, 23);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "lblEmail";
            // 
            // lblGender
            // 
            this.lblGender.Location = new System.Drawing.Point(65, 49);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(174, 23);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "lblGender";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(65, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(174, 23);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "lblName";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProfile);
            this.groupBox2.Controls.Add(this.btnChPwd);
            this.groupBox2.Location = new System.Drawing.Point(408, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Management";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(133, 21);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(121, 23);
            this.btnProfile.TabIndex = 4;
            this.btnProfile.Text = "Edit Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnChPwd
            // 
            this.btnChPwd.Location = new System.Drawing.Point(6, 21);
            this.btnChPwd.Name = "btnChPwd";
            this.btnChPwd.Size = new System.Drawing.Size(121, 23);
            this.btnChPwd.TabIndex = 3;
            this.btnChPwd.Text = "Change Password";
            this.btnChPwd.UseVisualStyleBackColor = true;
            this.btnChPwd.Click += new System.EventHandler(this.btnChPwd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAdmin1);
            this.groupBox3.Controls.Add(this.lblPrivilege);
            this.groupBox3.Controls.Add(this.btnAdmin2);
            this.groupBox3.Location = new System.Drawing.Point(408, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 74);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Administration";
            // 
            // btnAdmin1
            // 
            this.btnAdmin1.Enabled = false;
            this.btnAdmin1.Location = new System.Drawing.Point(6, 40);
            this.btnAdmin1.Name = "btnAdmin1";
            this.btnAdmin1.Size = new System.Drawing.Size(121, 23);
            this.btnAdmin1.TabIndex = 5;
            this.btnAdmin1.Text = "Add User";
            this.btnAdmin1.UseVisualStyleBackColor = true;
            this.btnAdmin1.Click += new System.EventHandler(this.btnAdmin1_Click);
            // 
            // lblPrivilege
            // 
            this.lblPrivilege.Location = new System.Drawing.Point(6, 22);
            this.lblPrivilege.Name = "lblPrivilege";
            this.lblPrivilege.Size = new System.Drawing.Size(248, 15);
            this.lblPrivilege.TabIndex = 2;
            this.lblPrivilege.Text = "privilegeIndicator";
            // 
            // btnAdmin2
            // 
            this.btnAdmin2.Location = new System.Drawing.Point(133, 40);
            this.btnAdmin2.Name = "btnAdmin2";
            this.btnAdmin2.Size = new System.Drawing.Size(121, 23);
            this.btnAdmin2.TabIndex = 6;
            this.btnAdmin2.Text = "Change User Pass";
            this.btnAdmin2.UseVisualStyleBackColor = true;
            this.btnAdmin2.Click += new System.EventHandler(this.btnAdmin2_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 171);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.Size = new System.Drawing.Size(923, 351);
            this.dgvMain.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnJobTransfer);
            this.groupBox4.Controls.Add(this.btnHistory);
            this.groupBox4.Controls.Add(this.lblJobPrivilege);
            this.groupBox4.Location = new System.Drawing.Point(675, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 124);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Job Management";
            // 
            // btnJobTransfer
            // 
            this.btnJobTransfer.Enabled = false;
            this.btnJobTransfer.Location = new System.Drawing.Point(6, 50);
            this.btnJobTransfer.Name = "btnJobTransfer";
            this.btnJobTransfer.Size = new System.Drawing.Size(121, 23);
            this.btnJobTransfer.TabIndex = 15;
            this.btnJobTransfer.Text = "Job/Title Transfer";
            this.btnJobTransfer.UseVisualStyleBackColor = true;
            this.btnJobTransfer.Click += new System.EventHandler(this.btnJobTransfer_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Enabled = false;
            this.btnHistory.Location = new System.Drawing.Point(6, 90);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(121, 23);
            this.btnHistory.TabIndex = 14;
            this.btnHistory.Text = "Transfer History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // lblJobPrivilege
            // 
            this.lblJobPrivilege.Location = new System.Drawing.Point(6, 26);
            this.lblJobPrivilege.Name = "lblJobPrivilege";
            this.lblJobPrivilege.Size = new System.Drawing.Size(248, 18);
            this.lblJobPrivilege.TabIndex = 3;
            this.lblJobPrivilege.Text = "No job administrative privilege acquired. ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 142);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh Table";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtMainSearch
            // 
            this.txtMainSearch.Location = new System.Drawing.Point(228, 144);
            this.txtMainSearch.Name = "txtMainSearch";
            this.txtMainSearch.Size = new System.Drawing.Size(618, 20);
            this.txtMainSearch.TabIndex = 0;
            this.txtMainSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMainSearch_KeyDown);
            // 
            // cboColumn
            // 
            this.cboColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumn.FormattingEnabled = true;
            this.cboColumn.Items.AddRange(new object[] { "Name", "Job", "Title", "Email", "Phone" });
            this.cboColumn.Location = new System.Drawing.Point(101, 143);
            this.cboColumn.Name = "cboColumn";
            this.cboColumn.Size = new System.Drawing.Size(121, 21);
            this.cboColumn.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(852, 142);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 534);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboColumn);
            this.Controls.Add(this.txtMainSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main - Title Management System";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnJobTransfer;

        private System.Windows.Forms.TextBox txtMainSearch;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.ComboBox cboColumn;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Label lblJobPrivilege;

        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.DataGridView dgvMain;

        private System.Windows.Forms.Button btnAdmin1;
        private System.Windows.Forms.Button btnAdmin2;
        private System.Windows.Forms.Label lblPrivilege;

        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.Button btnChPwd;
        private System.Windows.Forms.Button btnProfile;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUid;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPosition;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.GroupBox groupBox1;

        #endregion
    }
}