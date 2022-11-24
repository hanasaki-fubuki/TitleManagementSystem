using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class UserDatabase : Form
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
        
        public UserDatabase()
        {
            InitializeComponent();
            GridViewBind();
        }
        
        private void GridViewBind()
        {
            dgvUser.DataSource = null;
            var myConn = new MySqlConnection(_mainConn);
            var myDa = new MySqlDataAdapter("select * from user_table", myConn);
            myConn.Open();
            var myDataSet = new DataSet();
            myDa.Fill(myDataSet, "user_table");
            dgvUser.DataSource = myDataSet.Tables["user_table"];
            myConn.Close();
            dgvUser.Columns[0].HeaderText = @"User ID";
            dgvUser.Columns[1].HeaderText = @"Username";
            dgvUser.Columns[2].HeaderText = @"Password";
            dgvUser.Columns[3].HeaderText = @"isAdmin";
            dgvUser.Columns[4].HeaderText = @"Linked Profile ID";
            dgvUser.Columns[0].Frozen = true;
            dgvUser.Columns[0].ReadOnly = true;
            dgvUser.Columns[1].Frozen = true;
            dgvUser.Columns[1].ReadOnly = true;
            dgvUser.Columns[4].Frozen = true;
            dgvUser.Columns[4].ReadOnly = true;
            lblWarning1.Text = @"Changing User ID, Username and Linked Profile ID is not allowed. ";
            lblWarning2.Text = @"WARNING: Edit data table directly may cause data loss, proceed with caution.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvUser_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells[0].Value);
            string column = null;
            switch (e.ColumnIndex)
            {
                case 2:
                    column = "password";
                    break;
                case 3:
                    column = "isAdmin";
                    break;
                default:
                    MessageBox.Show(@"Unable to get column name. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            var value = dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            var myConn = new MySqlConnection(_mainConn);
            myConn.Open();
            var updateCmd = new MySqlCommand($"update user_table set {column}='{value}' where id='{id}'", myConn);
            updateCmd.ExecuteNonQuery();
            myConn.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }
    }
}