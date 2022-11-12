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
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection mainConn = new MySqlConnection(_mainConn);
            string mySql = "select * from user_table where username='" + txtUsername.Text + "' and " + "password='" + txtPassword.Text + "'";
            MySqlCommand loginProcess = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            MySqlDataReader loginReader = loginProcess.ExecuteReader();
            if (loginReader.Read())
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                txtUsername.Text = "";
                txtPassword.Text = "";
                Hide();
            }
            else
            {
                MessageBox.Show(@"Invalid username or password. Please try again. ", @"Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                txtUsername.Focus();
                txtPassword.SelectAll();
                
            }
            loginReader.Close();
            mainConn.Close();
            
        }
    }
}