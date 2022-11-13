using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class Authenticator : Form
    {

        private readonly string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        
        //args for the main form
        public static int Uid = -1;
        public static string NameOfUser;
        public static int Gender = -1;
        public static string Email;
        public static string Phone;
        public static int IsAdmin = -1;
        
        protected override CreateParams CreateParams        //禁用右上角关闭按钮
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ClassStyle |= 512;
                return createParams;
            }
        }

        public Authenticator()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Parent = pictureBackground;
            label1.Text = @"USERNAME";
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Parent = pictureBackground;
            label2.Text = @"PASSWORD";
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Parent = pictureBackground;
            label3.Text = @"Welcome to the Title Management System! ";
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Parent = pictureBackground;
            label4.Text = @"Please enter your username and password to proceed. ";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = "select * from user_table where username='" + txtUsername.Text + "' and " + "password='" + txtPassword.Text + "'";
            var loginProcess = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var loginReader = loginProcess.ExecuteReader();
            if (loginReader.Read())
            {
                loginReader.Close();
                mySql = "select id, personal_info_id, isAdmin from user_table where username='" + txtUsername.Text + "'";
                var getUser = new MySqlCommand(mySql, mainConn);
                var userReader = getUser.ExecuteReader();
                userReader.Read();
                Uid = userReader.GetInt32(0);
                var infoId = userReader.GetInt32(1);
                IsAdmin = userReader.GetInt32(2);
                userReader.Close();
                mySql = "select * from personal_info_table where id=" + infoId;
                var getPersonalInfo = new MySqlCommand(mySql, mainConn);
                var personalInfoReader = getPersonalInfo.ExecuteReader();
                personalInfoReader.Read();
                NameOfUser = personalInfoReader.GetString(1);
                Gender = personalInfoReader.GetInt32(2);
                Email = personalInfoReader.GetString(3);
                Phone = personalInfoReader.GetString(4);
                var mainForm = new MainForm();
                mainForm.Show();
                Close();
            }
            else
            {
                MessageBox.Show(@"Invalid username or password. Please try again. ", @"Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                txtUsername.Focus();
                txtPassword.SelectAll();
                
            }
            mainConn.Close();
            
        }
    }
}