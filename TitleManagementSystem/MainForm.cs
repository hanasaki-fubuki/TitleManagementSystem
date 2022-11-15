using System;
using System.Drawing;
using System.Windows.Forms;

namespace TitleManagementSystem
{
    public partial class MainForm : Form
    {
        //args for the main form
        public static int Uid = -1;

        protected override CreateParams CreateParams        //禁用右上角关闭按钮
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ClassStyle |= 512;
                return createParams;
            }
        }
        
        public MainForm()
        {
            InitializeComponent();
            Uid = Authenticator.Uid;
            lblName.Text = Authenticator.NameOfUser;
            lblGender.Text = Authenticator.Gender == 1 ? @"Male" : @"Female";
            lblEmail.Text = Authenticator.Email;
            lblPhone.Text = Authenticator.Phone;
            lblUid.Text = Uid.ToString();
            if (Authenticator.IsAdmin == 0)
            {
                lblIsAdmin.Text = @"Super User";
                lblPrivilege.Text = @"Logged in as Super User with highest privileges. ";
                lblPrivilege.ForeColor = Color.Red;
                btnAdmin1.Text = @"User Database";
                btnAdmin1.BackColor = Color.Red;
                btnAdmin1.ForeColor = Color.White;
                btnAdmin2.Text = @"Profile Database";
                btnAdmin2.BackColor = Color.Red;
                btnAdmin2.ForeColor = Color.White;
                btnAdmin1.Enabled = true;
                btnAdmin2.Enabled = true;
            }
            else if (Authenticator.IsAdmin == 1)
            {
                lblIsAdmin.Text = @"Admin";
                lblPrivilege.Text = @"Logged in as Admin with admin privileges. ";
                lblPrivilege.ForeColor = Color.Aqua;
                btnAdmin1.Enabled = true;
                btnAdmin2.Enabled = true;
            }
            else
            {
                lblIsAdmin.Text = @"Non Admin";
                lblPrivilege.Text = @"No administrative privilege acquired. ";
                btnAdmin1.Enabled = false;
                btnAdmin2.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(@"Are you sure to logout?", @"Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;
            var authenticator = new Authenticator();
            authenticator.Show();
            Close();

        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(@"Are you sure to exit?", @"Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void btnChPwd_Click(object sender, EventArgs e)
        {
            var changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            var editProfile = new EditProfile();
            editProfile.ShowDialog();
        }

        private void btnAdmin1_Click(object sender, EventArgs e)
        {
            if (btnAdmin1.Text == @"Add User")
            {
                var addUser = new AddUser();
                addUser.ShowDialog();
            }
            else if (btnAdmin1.Text == @"User Database")
            {
                if (FormPool.UserDatabase.IsDisposed || FormPool.UserDatabase == null)
                {
                    FormPool.UserDatabase = new UserDatabase();
                }
                FormPool.UserDatabase.Show();
            }
            
        }

        private void btnAdmin2_Click(object sender, EventArgs e)
        {
            if (btnAdmin2.Text == @"Change User Pass")
            {
                var changeUserPass = new ChangeUserPass();
                changeUserPass.ShowDialog();
            } 
            else if (btnAdmin2.Text == @"Profile Database")
            {
                if (FormPool.ProfileDatabase.IsDisposed || FormPool.ProfileDatabase == null)
                {
                    FormPool.ProfileDatabase = new ProfileDatabase();
                } 
                FormPool.ProfileDatabase.Show();
            }
        }
    }
}