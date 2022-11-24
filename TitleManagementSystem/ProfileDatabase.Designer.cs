using System.ComponentModel;

namespace TitleManagementSystem
{
    partial class ProfileDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileDatabase));
            this.dgvProfile = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWarning1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWarning2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProfile
            // 
            this.dgvProfile.AllowUserToAddRows = false;
            this.dgvProfile.AllowUserToDeleteRows = false;
            this.dgvProfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfile.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfile.Location = new System.Drawing.Point(12, 12);
            this.dgvProfile.Name = "dgvProfile";
            this.dgvProfile.Size = new System.Drawing.Size(776, 380);
            this.dgvProfile.TabIndex = 0;
            this.dgvProfile.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProfile_CellEndEdit);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblWarning1
            // 
            this.lblWarning1.ForeColor = System.Drawing.Color.Red;
            this.lblWarning1.Location = new System.Drawing.Point(12, 395);
            this.lblWarning1.Name = "lblWarning1";
            this.lblWarning1.Size = new System.Drawing.Size(614, 23);
            this.lblWarning1.TabIndex = 2;
            this.lblWarning1.Text = "lblWarning1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(632, 398);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWarning2
            // 
            this.lblWarning2.ForeColor = System.Drawing.Color.Red;
            this.lblWarning2.Location = new System.Drawing.Point(12, 411);
            this.lblWarning2.Name = "lblWarning2";
            this.lblWarning2.Size = new System.Drawing.Size(614, 22);
            this.lblWarning2.TabIndex = 3;
            this.lblWarning2.Text = "lblWarning2";
            // 
            // ProfileDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.lblWarning2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblWarning1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileDatabase";
            this.Text = "Profile Database - [Super User Access]";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfile)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblWarning2;

        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Label lblWarning1;

        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.DataGridView dgvProfile;

        #endregion
    }
}