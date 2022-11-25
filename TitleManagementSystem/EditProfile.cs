using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class EditProfile : Form
    {
        private readonly string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;

        private readonly int _profileId;

        public string NameOfUser;
        public int Gender;
        public string Email;
        public string Phone;

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
        public EditProfile()
        {
            InitializeComponent();
            //从主窗体接收Uid信息并从用户表中查找用户对应的用户名
            var uid = MainForm.Uid;
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select username, profile_id from user_table where id='{uid}'";
            var getUsername = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var getUserReader = getUsername.ExecuteReader();
            if (getUserReader.Read())
            {
                //查询成功将用户名展示给用户
                lblUid.Text = uid.ToString();
                txtUsername.Text = getUserReader.GetString("username");
                //profileId用于后续查询用户当前个人信息
                _profileId = Convert.ToInt32(getUserReader["profile_id"]);
                getUserReader.Close();
                //开始查询用户当前个人信息
                var mySql2 = $"select * from profile_table where id='{_profileId}'";
                var getProfile = new MySqlCommand(mySql2, mainConn);
                var getProfileReader = getProfile.ExecuteReader();
                if (getProfileReader.Read())
                {
                    //查询成功将用户当前个人信息展示给用户
                    txtName.Text = getProfileReader.GetString("name");
                    txtEmail.Text = getProfileReader.GetString("email");
                    txtPhone.Text = getProfileReader.GetString("phone");
                    cboGender.Text = getProfileReader.GetInt32("Gender") == 1 ? @"Male" : @"Female";
                    NameOfUser = txtName.Text;
                    Gender = cboGender.Text == @"Male" ? 1 : 0;
                    Email = txtEmail.Text;
                    Phone = txtPhone.Text;
                }
            }
            else
            {
                //查询失败提示用户重新登陆
                MessageBox.Show(@"Cannot get user token. Try re-login. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        //Confirm按钮单击事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //验证用户当前密码
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select * from user_table where id='{Convert.ToInt32(lblUid.Text)}' and password='{txtPwd.Text}'";
            var pwdCheck = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var pwdCheckReader = pwdCheck.ExecuteReader();
            if (pwdCheckReader.Read())
            {
                //当前密码正确，将新个人信息写入数据库并弹出对话框提示用户修改完成
                pwdCheckReader.Close();
                NameOfUser = txtName.Text;
                Gender = cboGender.Text == @"Male" ? 1 : 0;
                Email = txtEmail.Text;
                Phone = txtPhone.Text;
                var mySql2 = $"update profile_table set name='{NameOfUser}', gender={Gender}, email='{Email}', phone='{Phone}' where id='{_profileId}'";
                var updateProfile = new MySqlCommand(mySql2, mainConn);
                updateProfile.ExecuteNonQuery();
                MessageBox.Show(@"Profile updated successfully.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                //当前密码错误，认证失败，提示用户检查当前密码
                MessageBox.Show(@"Wrong password. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPwd.SelectAll();
                txtPwd.Focus();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }
    }
}