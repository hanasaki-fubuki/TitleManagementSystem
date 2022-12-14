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
        public static string Position;
        
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
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select * from user_table where username='{txtUsername.Text}' and password='{txtPassword.Text}'";
            var loginProcess = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var loginReader = loginProcess.ExecuteReader();
            if (loginReader.Read())
            {
                //用户认证成功
                loginReader.Close();
                //从用户凭据表获取用户部分信息
                mySql = $"select id, profile_id, isAdmin from user_table where username='{txtUsername.Text}'";
                var getUser = new MySqlCommand(mySql, mainConn);
                var userReader = getUser.ExecuteReader();
                userReader.Read();
                //infoId用于从个人信息表中获取用户个人信息
                var infoId = userReader.GetInt32(1);
                //Uid和IsAdmin用于主窗体中的权限判断
                Uid = userReader.GetInt32(0);
                IsAdmin = userReader.GetInt32(2);
                userReader.Close();
                //从个人信息表获取用户个人信息
                mySql = $"select * from profile_table where id={infoId}";
                var getProfile = new MySqlCommand(mySql, mainConn);
                var profileInfoReader = getProfile.ExecuteReader();
                profileInfoReader.Read();
                //以下参数用于传递给主窗体的用户信息显示模块
                NameOfUser = profileInfoReader.GetString(1);
                Gender = profileInfoReader.GetInt32(2);
                Email = profileInfoReader.GetString(3);
                Phone = profileInfoReader.GetString(4);
                Position = profileInfoReader.GetString(5) + ", " + profileInfoReader.GetString(6);
                profileInfoReader.Close();
                //记录登录日志，关闭认证窗体，打开主窗体
                var mainForm = new MainForm();
                mainForm.Show();
                var loginLog = new MySqlCommand($"insert into login_log set uid={Uid}, log_time=now(), status=0", mainConn);
                loginLog.ExecuteNonQuery();
                Close();
            }
            else
            { 
                //用户认证失败，弹出对话框提示
                loginReader.Close();
                MessageBox.Show(@"Invalid username or password. Please try again. ", @"Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                txtUsername.Focus();
                txtPassword.SelectAll();
            }
            mainConn.Close();
        }
    }
}