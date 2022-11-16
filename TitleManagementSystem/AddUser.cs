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

        private void TextBoxValidate()
        {
            if (txtPwd.Text == txtConfirmPwd.Text)
            {
                if (txtUsername.Text != "" && cboAdmin.Text != "" && txtPwd.Text != "" && txtConfirmPwd.Text != "" && txtName.Text != "" && cboGender.Text != "")
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var myConn = new MySqlConnection(_mainConn);
            var gender = cboGender.Text == @"Male" ? 1 : 0;
            var isAdmin = cboAdmin.Text == @"Yes" ? 1 : 2;
            myConn.Open();
            var userExists = new MySqlCommand($"select username from user_table where username='{txtUsername.Text}'", myConn);
            var userExistsReader = userExists.ExecuteReader();
            userExistsReader.Read();
            var userExistsResult = userExistsReader.HasRows;
            if (userExistsResult)
            {
                MessageBox.Show(@"Username already exists!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userExistsReader.Close();
                myConn.Close();
            }
            else
            {
                userExistsReader.Close();
                var myCmd = new MySqlCommand($"insert into profile_table set name='{txtName.Text}', gender={gender}, email='{txtEmail.Text}', phone='{txtPhone.Text}'", myConn);
                myCmd.ExecuteNonQuery();
                var getProfileId = new MySqlCommand($"select id from profile_table where name='{txtName.Text}' order by id desc", myConn);
                var profileId = Convert.ToInt32(getProfileId.ExecuteScalar());
                var myCmd2 = new MySqlCommand($"insert into user_table set username='{txtUsername.Text}', password='{txtPwd.Text}', isAdmin='{isAdmin}', profile_id={profileId}", myConn);
                myCmd2.ExecuteNonQuery();
                myConn.Close();
                MessageBox.Show(@"User added successfully! ", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

    }
}