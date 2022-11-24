using System.ComponentModel;

namespace TitleManagementSystem
{
    partial class TransferHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferHistory));
            this.dgvTransfer = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWarning1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWarning2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransfer
            // 
            this.dgvTransfer.AllowUserToAddRows = false;
            this.dgvTransfer.AllowUserToDeleteRows = false;
            this.dgvTransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransfer.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTransfer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransfer.Location = new System.Drawing.Point(12, 12);
            this.dgvTransfer.Name = "dgvTransfer";
            this.dgvTransfer.ReadOnly = true;
            this.dgvTransfer.Size = new System.Drawing.Size(820, 380);
            this.dgvTransfer.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(757, 398);
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
            this.lblWarning1.Size = new System.Drawing.Size(614, 26);
            this.lblWarning1.TabIndex = 2;
            this.lblWarning1.Text = "lblWarning1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(676, 398);
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
            this.lblWarning2.TabIndex = 4;
            this.lblWarning2.Text = "lblWarning2";
            // 
            // TransferHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 427);
            this.Controls.Add(this.lblWarning2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblWarning1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferHistory";
            this.Text = "Job Transfer History - [Administrator Access]";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblWarning2;

        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Label lblWarning1;

        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.DataGridView dgvTransfer;

        #endregion
    }
}