using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class ChangePassword : Form
    {
        private readonly string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;

        protected override CreateParams CreateParams        //禁用右上角关闭按钮
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ClassStyle |= 512;
                return createParams;
            }
        }
        public ChangePassword()
        {
            InitializeComponent();
            var uid = MainForm.Uid;
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = "select username from user_table where id='" + uid + "'";
            var getUsername = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var getUsernameReader = getUsername.ExecuteReader();
            if (getUsernameReader.Read())
            {
                lblUid.Text = uid.ToString();
                txtUsername.Text = getUsernameReader.GetString("username");
            }
            else
            {
                MessageBox.Show(@"Cannot get userinfo. Try re-login. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = "select * from user_table where id='" + Convert.ToInt32(lblUid.Text) + "' and " + "password='" + txtCurrent.Text + "'";
            var chPwd = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var chPwdReader = chPwd.ExecuteReader();
            if (chPwdReader.Read())
            {
                chPwdReader.Close();
                var updatePwd = "update user_table set password='" + txtNew.Text + "' where id='" + Convert.ToInt32(lblUid.Text) + "'";
                var updatePwdCmd = new MySqlCommand(updatePwd, mainConn);
                updatePwdCmd.ExecuteNonQuery();
                MessageBox.Show(@"Password successfully changed. ", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show(@"Current password is incorrect. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrent.SelectAll();
                txtCurrent.Focus();
            }
            mainConn.Close();
        }

        private void txtConfirmNew_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmNew.Text != "")
            {
                btnConfirm.Enabled = txtConfirmNew.Text == txtNew.Text;
            }
        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {
            if (txtNew.Text != "")
            {
                btnConfirm.Enabled = txtNew.Text == txtConfirmNew.Text;
            }
        }
    }
}