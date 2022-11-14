using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class ChangeUserPass : Form
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
        
        public ChangeUserPass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtConfirmNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(null, null);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
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
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select id, isAdmin from user_table where username='{txtUsername.Text}'";
            var findUser = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var findUserReader = findUser.ExecuteReader();
            if (findUserReader.Read())
            {
                if (findUserReader["isAdmin"].ToString() == "2")
                {
                    lblUid.Text = findUserReader["id"].ToString();
                    txtUsername.Enabled = false;
                    txtNew.Enabled = true;
                    txtConfirmNew.Enabled = true;
                    btnSearch.Enabled = false;
                    txtNew.Focus();
                    findUserReader.Close();
                }
                else if (findUserReader["isAdmin"].ToString() == "1")
                {
                    MessageBox.Show(@"You cannot change the password of an administrator. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
                else if (findUserReader["isAdmin"].ToString() == "0")
                {
                    MessageBox.Show(@"Cannot find the specified user.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show(@"Cannot find the specified user.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                txtUsername.Focus();
            }
            mainConn.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var updatePwd = $"update user_table set password='{txtNew.Text}' where id='{Convert.ToInt32(lblUid.Text)}'";
            mainConn.Open();
            var updatePwdCmd = new MySqlCommand(updatePwd, mainConn);
            updatePwdCmd.ExecuteNonQuery();
            MessageBox.Show(@"User password successfully changed. ", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

    }
}