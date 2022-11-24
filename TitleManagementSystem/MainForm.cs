using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class MainForm : Form
    {
        private readonly string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        
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
            lblPosition.Text = Authenticator.Position;
            switch (Authenticator.IsAdmin)
            {
                case 0:
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
                    break;
                case 1:
                    lblPrivilege.Text = @"Logged in as Admin with administrative privileges. ";
                    lblPrivilege.ForeColor = Color.Aqua;
                    lblJobPrivilege.Text = @"Privilege acquired, job management enabled. ";
                    lblJobPrivilege.ForeColor = Color.Aqua;
                    btnHistory.Enabled = true;
                    btnJobTransfer.Enabled = true;
                    btnAdmin1.Enabled = true;
                    btnAdmin2.Enabled = true;
                    break;
                default:
                    lblPrivilege.Text = @"No administrative privilege acquired. ";
                    btnAdmin1.Enabled = false;
                    btnAdmin2.Enabled = false;
                    break;
            }
            GridViewBind();
            cboColumn.Text = @"Name";
            txtMainSearch.Focus();
        }

        void GridViewBind()
        {
            dgvMain.DataSource = null;
            var myConn = new MySqlConnection(_mainConn);
            var myDa = new MySqlDataAdapter("select name, job, title, email, phone from profile_table", myConn);
            myConn.Open();
            var myDataSet = new DataSet();
            myDa.Fill(myDataSet, "profile_table");
            dgvMain.DataSource = myDataSet.Tables["profile_table"];
            myConn.Close();
            dgvMain.Columns[0].HeaderText = @"Name";
            dgvMain.Columns[1].HeaderText = @"Job";
            dgvMain.Columns[2].HeaderText = @"Title";
            dgvMain.Columns[3].HeaderText = @"Email";
            dgvMain.Columns[4].HeaderText = @"Phone";
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
            lblName.Text = editProfile.NameOfUser;
            lblGender.Text = editProfile.Gender == 1 ? @"Male" : @"Female";
            lblEmail.Text = editProfile.Email;
            lblPhone.Text = editProfile.Phone;
        }

        private void btnAdmin1_Click(object sender, EventArgs e)
        {
            if (btnAdmin1.Text == @"Add User")
            {
                var addUser = new AddUser();
                addUser.ShowDialog();
                GridViewBind();
            }
            else if (btnAdmin1.Text == @"User Database")
            {
                if (FormPool.UserDatabase.IsDisposed || FormPool.UserDatabase == null)
                {
                    FormPool.UserDatabase = new UserDatabase();
                }
                FormPool.UserDatabase.Show();
                FormPool.UserDatabase.BringToFront();
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
                FormPool.ProfileDatabase.BringToFront();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = null;
            var myConn = new MySqlConnection(_mainConn);
            var myDa = new MySqlDataAdapter($"select name, job, title, email, phone from profile_table where {cboColumn.Text} like '%{txtMainSearch.Text}%'", myConn);
            myConn.Open();
            var myDataSet = new DataSet();
            myDa.Fill(myDataSet, "profile_table");
            dgvMain.DataSource = myDataSet.Tables["profile_table"];
            myConn.Close();
            dgvMain.Columns[0].HeaderText = @"Name";
            dgvMain.Columns[1].HeaderText = @"Job";
            dgvMain.Columns[2].HeaderText = @"Title";
            dgvMain.Columns[3].HeaderText = @"Email";
            dgvMain.Columns[4].HeaderText = @"Phone";
        }

        private void txtMainSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (FormPool.TransferHistory.IsDisposed || FormPool.TransferHistory == null)
            {
                FormPool.TransferHistory = new TransferHistory();
            }
            FormPool.TransferHistory.Show();
            FormPool.TransferHistory.BringToFront();
        }

        private void btnJobTransfer_Click(object sender, EventArgs e)
        {
            var transfer = new Transfer();
            transfer.ShowDialog();
        }

        private void cboColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainSearch.Focus();
        }
    }
}