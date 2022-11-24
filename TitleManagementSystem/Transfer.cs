using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class Transfer : Form
    {
        private readonly string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        private int _profileId;

        protected override CreateParams CreateParams        //禁用右上角关闭按钮
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ClassStyle |= 512;
                return createParams;
            }
        }
        
        public Transfer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var mySql = $"select id, isAdmin, profile_id from user_table where username='{txtUsername.Text}'";
            var findUser = new MySqlCommand(mySql, mainConn);
            mainConn.Open();
            var findUserReader = findUser.ExecuteReader();
            if (findUserReader.Read())
            {
                if (findUserReader["isAdmin"].ToString() == "2")
                {
                    lblUid.Text = findUserReader["id"].ToString();
                    _profileId = Convert.ToInt32(findUserReader["profile_id"]);
                    findUserReader.Close();
                    var mySql2 = $"select name, job, title from profile_table where id={_profileId}";
                    var findProfile = new MySqlCommand(mySql2, mainConn);
                    var findProfileReader = findProfile.ExecuteReader();
                    findProfileReader.Read();
                    lblName.Text = findProfileReader["name"].ToString();
                    txtPrevJob.Text = findProfileReader["job"].ToString();
                    txtPrevTitle.Text = findProfileReader["title"].ToString();
                    findProfileReader.Close();
                    txtUsername.Enabled = false;
                    txtNewJob.Enabled = true;
                    txtNewTitle.Enabled = true;
                    btnSearch.Enabled = false;
                    txtNewJob.Focus();
                    
                }
                else if (findUserReader["isAdmin"].ToString() == "1")
                {
                    MessageBox.Show(@"You cannot change this info of an administrator. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
                else if (findUserReader["isAdmin"].ToString() == "0")
                {
                    MessageBox.Show(@"Cannot find the specified user.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show(@"Cannot find the specified user.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                txtUsername.Focus();
            }
            mainConn.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var mainConn = new MySqlConnection(_mainConn);
            var updateJobCmd = new MySqlCommand($"update profile_table set job='{txtNewJob.Text}', title='{txtNewTitle.Text}' where id={_profileId}", mainConn);
            var saveHistory = new MySqlCommand($"insert into transfer_history set uid_link={lblUid.Text}, op_time=now(), pre_job='{txtPrevJob.Text}', pre_title='{txtPrevTitle.Text}', new_job='{txtNewJob.Text}', new_title='{txtNewTitle.Text}'", mainConn);
            mainConn.Open();
            updateJobCmd.ExecuteNonQuery();
            saveHistory.ExecuteNonQuery();
            mainConn.Close();
            MessageBox.Show(@"Transfer successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void txtNewJob_TextChanged(object sender, EventArgs e)
        {
            if (txtNewJob.Text != "" && txtNewTitle.Text != "")
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void txtNewTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtNewJob.Text != "" && txtNewTitle.Text != "")
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void txtNewTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }
    }
}