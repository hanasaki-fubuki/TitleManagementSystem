using System;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblName.Text = Authenticator.NameOfUser;
            lblGender.Text = Authenticator.Gender == 1 ? @"Male" : @"Female";
            lblEmail.Text = Authenticator.Email;
            lblPhone.Text = Authenticator.Phone;
            lblUid.Text = Uid.ToString();
            if (Authenticator.IsAdmin == 0)
            {
                lblIsAdmin.Text = @"Super User";
            }
            else if (Authenticator.IsAdmin == 1)
            {
                lblIsAdmin.Text = @"Admin";
            }
            else
            {
                lblIsAdmin.Text = @"Non Admin";
            }
            
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(@"Are you sure to logout?", @"Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var authenticator = new Authenticator();
                authenticator.Show();
                Close();
            }
            
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(@"Are you sure to exit?", @"Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
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
    }
}