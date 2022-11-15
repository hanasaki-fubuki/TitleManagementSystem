using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class ProfileDatabase : Form
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
        
        public ProfileDatabase()
        {
            InitializeComponent();
            GridViewBind();
        }
        
        private void GridViewBind()
        {
            var myConn = new MySqlConnection(_mainConn);
            var myDa = new MySqlDataAdapter("select * from profile_table", myConn);
            myConn.Open();
            var myDataSet = new DataSet();
            myDa.Fill(myDataSet, "profile_table");
            dgvProfile.DataSource = myDataSet.Tables["profile_table"];
            myConn.Close();
            dgvProfile.Columns[0].HeaderText = @"Profile ID";
            dgvProfile.Columns[1].HeaderText = @"Name";
            dgvProfile.Columns[2].HeaderText = @"Gender";
            dgvProfile.Columns[3].HeaderText = @"Email";
            dgvProfile.Columns[4].HeaderText = @"Phone";
            dgvProfile.Columns[0].Frozen = true;
            dgvProfile.Columns[0].ReadOnly = true;
            lblWarning.Text = "Changing Profile ID is not allowed.\nWARNING: Edit data table directly may cause data loss, proceed with caution.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvProfile_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvProfile.Rows[e.RowIndex].Cells[0].Value);
            string column = null;
            switch (e.ColumnIndex)
            {
                case 1:
                    column = "name";
                    break;
                case 2:
                    column = "gender";
                    break;
                case 3:
                    column = "email";
                    break;
                case 4:
                    column = "phone";
                    break;
                default:
                    MessageBox.Show(@"Unable to get column name. ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            var value = dgvProfile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            var myConn = new MySqlConnection(_mainConn);
            myConn.Open();
            var updateCmd = new MySqlCommand($"update profile_table set {column}='{value}' where id='{id}'", myConn);
            updateCmd.ExecuteNonQuery();
            myConn.Close();
        }
    }
}