using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class EditProfile : Form
    {
        private readonly string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        
        private readonly int _uid;
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
        
        public EditProfile()
        {
            InitializeComponent();
            _uid = MainForm.Uid;
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select username, profile_id from user_table where id='{_uid}'";
            var getUsername = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var getUserReader = getUsername.ExecuteReader();
            if (getUserReader.Read())
            {
                lblUid.Text = _uid.ToString();
                _profileId = Convert.ToInt32(getUserReader["profile_id"]);
                txtUsername.Text = getUserReader.GetString("username");
                getUserReader.Close();
                var mySql2 = $"select * from profile_table where id='{_profileId}'";
                var getProfile = new MySqlCommand(mySql2, mainConn);
                var getProfileReader = getProfile.ExecuteReader();
                if (getProfileReader.Read())
                {
                    txtName.Text = getProfileReader.GetString("name");
                    txtEmail.Text = getProfileReader.GetString("email");
                    txtPhone.Text = getProfileReader.GetString("phone");
                    cboGender.Text = getProfileReader.GetInt32("Gender") == 1 ? @"Male" : @"Female";
                }
            }
            else
            {
                MessageBox.Show(@"Cannot get user token. Try re-login. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select * from user_table where id='{Convert.ToInt32(lblUid.Text)}' and password='{txtPwd.Text}'";
            var pwdCheck = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var pwdCheckReader = pwdCheck.ExecuteReader();
            if (pwdCheckReader.Read())
            {
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
                MessageBox.Show(@"Wrong password. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPwd.SelectAll();
                txtPwd.Focus();
            }
        }
        
    }
}