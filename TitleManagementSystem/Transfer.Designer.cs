using System.ComponentModel;

namespace TitleManagementSystem
{
    partial class Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrevJob = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrevTitle = new System.Windows.Forms.TextBox();
            this.txtNewJob = new System.Windows.Forms.TextBox();
            this.txtNewTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(325, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(244, 147);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "&Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "You are changing the job or title of a employee. ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(348, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(138, 29);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(204, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Target Username:";
            // 
            // lblUid
            // 
            this.lblUid.Location = new System.Drawing.Point(138, 55);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(141, 23);
            this.lblUid.TabIndex = 20;
            this.lblUid.Text = "null";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Target User ID:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Target Employee:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(138, 78);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(141, 23);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "null";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 24;
            this.label5.Text = "Prev Job:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 25;
            this.label6.Text = "New Job:";
            // 
            // txtPrevJob
            // 
            this.txtPrevJob.Enabled = false;
            this.txtPrevJob.Location = new System.Drawing.Point(76, 98);
            this.txtPrevJob.Name = "txtPrevJob";
            this.txtPrevJob.ReadOnly = true;
            this.txtPrevJob.Size = new System.Drawing.Size(118, 20);
            this.txtPrevJob.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(200, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 23);
            this.label7.TabIndex = 27;
            this.label7.Text = "Prev Title:";
            // 
            // txtPrevTitle
            // 
            this.txtPrevTitle.Enabled = false;
            this.txtPrevTitle.Location = new System.Drawing.Point(268, 98);
            this.txtPrevTitle.Name = "txtPrevTitle";
            this.txtPrevTitle.ReadOnly = true;
            this.txtPrevTitle.Size = new System.Drawing.Size(132, 20);
            this.txtPrevTitle.TabIndex = 28;
            // 
            // txtNewJob
            // 
            this.txtNewJob.Enabled = false;
            this.txtNewJob.Location = new System.Drawing.Point(76, 121);
            this.txtNewJob.Name = "txtNewJob";
            this.txtNewJob.Size = new System.Drawing.Size(118, 20);
            this.txtNewJob.TabIndex = 3;
            this.txtNewJob.TextChanged += new System.EventHandler(this.txtNewJob_TextChanged);
            // 
            // txtNewTitle
            // 
            this.txtNewTitle.Enabled = false;
            this.txtNewTitle.Location = new System.Drawing.Point(268, 121);
            this.txtNewTitle.Name = "txtNewTitle";
            this.txtNewTitle.Size = new System.Drawing.Size(132, 20);
            this.txtNewTitle.TabIndex = 4;
            this.txtNewTitle.TextChanged += new System.EventHandler(this.txtNewTitle_TextChanged);
            this.txtNewTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewTitle_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(200, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 23);
            this.label8.TabIndex = 31;
            this.label8.Text = "New Title:";
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 180);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNewTitle);
            this.Controls.Add(this.txtNewJob);
            this.Controls.Add(this.txtPrevTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrevJob);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Transfer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job/Title Transfer - [Administrator Access]";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtPrevJob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrevTitle;
        private System.Windows.Forms.TextBox txtNewJob;
        private System.Windows.Forms.TextBox txtNewTitle;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUid;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;

        #endregion
    }
}