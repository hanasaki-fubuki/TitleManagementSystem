using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class AddUser : Form
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
        
        public AddUser()
        {
            InitializeComponent();
        }

        //文本框内容非空合法检查，当文本框的TextChanged事件被触发时被调用
        private void TextBoxValidate()
        {
            if (txtPwd.Text == txtConfirmPwd.Text)
            {
                if (txtUsername.Text != "" && cboAdmin.Text != "" && txtPwd.Text != "" && txtConfirmPwd.Text != "" && txtName.Text != "" && cboGender.Text != "" && txtJob.Text != "" && txtTitle.Text != "")
                {
                    btnConfirm.Enabled = true;
                }
                else
                {
                    btnConfirm.Enabled = false;
                }
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }

        private void txtConfirmPwd_TextChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }

        //Confirm按钮单击事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var myConn = new MySqlConnection(_mainConn);
            var gender = cboGender.Text == @"Male" ? 1 : 0;
            var isAdmin = cboAdmin.Text == @"Yes" ? 1 : 2;
            myConn.Open();
            //以当前输入的用户名为准在数据库中查找是否存在相同用户名
            var userExists = new MySqlCommand($"select username from user_table where username='{txtUsername.Text}'", myConn);
            var userExistsReader = userExists.ExecuteReader();
            userExistsReader.Read();
            var userExistsResult = userExistsReader.HasRows;
            if (userExistsResult)
            {
                //若存在相同用户名则弹出对话框提示管理员用户已存在
                MessageBox.Show(@"Username already exists!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userExistsReader.Close();
                myConn.Close();
            }
            else
            {
                //若用户名不存在则将用户信息插入数据库
                userExistsReader.Close();
                //先写入个人信息
                var myCmd = new MySqlCommand($"insert into profile_table set name='{txtName.Text}', gender={gender}, email='{txtEmail.Text}', phone='{txtPhone.Text}', job='{txtJob.Text}', title='{txtTitle.Text}'", myConn);
                myCmd.ExecuteNonQuery();
                //写入个人信息后从数据库中获取刚刚写入的个人信息的id
                var getProfileId = new MySqlCommand($"select id from profile_table where name='{txtName.Text}' order by id desc", myConn);
                var profileId = Convert.ToInt32(getProfileId.ExecuteScalar());
                //再写入用户凭据，其中profile_id为刚刚获取的个人信息id
                var myCmd2 = new MySqlCommand($"insert into user_table set username='{txtUsername.Text}', password='{txtPwd.Text}', isAdmin='{isAdmin}', profile_id={profileId}", myConn);
                myCmd2.ExecuteNonQuery();
                //用户添加完成，在数据库中写入用户日志
                var myCmd3 = new MySqlCommand($"insert into transfer_history set uid_link=(select id from user_table where username='{txtUsername.Text}'), op_time=now(), pre_job='reg', pre_title='reg', new_job='{txtJob.Text}', new_title='{txtTitle.Text}'", myConn);
                myCmd3.ExecuteNonQuery();
                myConn.Close();
                //写入成功后弹出对话框提示管理员用户添加成功
                MessageBox.Show(@"User added successfully! ", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void txtJob_TextChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            TextBoxValidate();
        }
    }
}