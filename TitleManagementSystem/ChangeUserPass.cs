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
        
        //查找用户按钮单击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select id, isAdmin from user_table where username='{txtUsername.Text}'";
            var findUser = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var findUserReader = findUser.ExecuteReader();
            if (findUserReader.Read())
            {
                //若数据库中找到用户
                if (findUserReader["isAdmin"].ToString() == "2")
                {
                    //普通用户可以被管理员强制修改密码，查找成功，显示uid，关闭查找按钮和搜索框
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
                    //管理员不能被强制修改密码，查找失败，弹出对话框提示不可平级修改密码
                    MessageBox.Show(@"You cannot change the password of an administrator. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
                else if (findUserReader["isAdmin"].ToString() == "0")
                {
                    //若搜索到了运维用户的用户名则直接伪装成用户不存在，防止运维用户被强制修改密码，做到运维用户名隐形
                    MessageBox.Show(@"Cannot find the specified user.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
            }
            else
            {
                //若数据库中未找到相应用户，弹出对话框提示用户不存在
                MessageBox.Show(@"Cannot find the specified user.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                txtUsername.Focus();
            }
            mainConn.Close();
        }

        //Confirm按钮单击事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //由于判断逻辑已经在上方实现，且当前登录用户为管理员，直接将新密码写入数据库
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