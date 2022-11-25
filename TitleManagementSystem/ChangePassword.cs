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
        
        //窗体类构造函数
        public ChangePassword()
        {
            InitializeComponent();
            //从主窗体接收Uid信息并从用户表中查找用户对应的用户名
            var uid = MainForm.Uid;
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select username from user_table where id='{uid}'";
            var getUsername = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var getUsernameReader = getUsername.ExecuteReader();
            if (getUsernameReader.Read())
            {
                //查询成功将用户名展示给用户
                lblUid.Text = uid.ToString();
                txtUsername.Text = getUsernameReader.GetString("username");
            }
            else
            {
                //查询失败提示用户重新登陆
                MessageBox.Show(@"Cannot get userinfo. Try re-login. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //修改密码按钮单击事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //验证用户原密码
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select * from user_table where id='{Convert.ToInt32(lblUid.Text)}' and password='{txtCurrent.Text}'";
            var chPwd = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var chPwdReader = chPwd.ExecuteReader();
            if (chPwdReader.Read())
            {
                //原密码正确，将新密码写入数据库并弹出对话框提示用户
                chPwdReader.Close();
                var updatePwd = $"update user_table set password='{txtNew.Text}' where id='{Convert.ToInt32(lblUid.Text)}'";
                var updatePwdCmd = new MySqlCommand(updatePwd, mainConn);
                updatePwdCmd.ExecuteNonQuery();
                MessageBox.Show(@"Password successfully changed. ", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                //原密码错误，弹出对话框提示用户确认原密码
                MessageBox.Show(@"Current password is incorrect. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrent.SelectAll();
                txtCurrent.Focus();
            }
            mainConn.Close();
        }

        //密码一致性验证，两文本框内容一致时确认按钮可用
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