using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TitleManagementSystem
{
    public partial class TransferHistory : Form
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
        
        public TransferHistory()
        {
            InitializeComponent();
            GridViewBind();
        }
        
        private void GridViewBind()
        {
            dgvTransfer.DataSource = null;
            var myConn = new MySqlConnection(_mainConn);
            var myDa = new MySqlDataAdapter("select * from transfer_history", myConn);
            myConn.Open();
            var myDataSet = new DataSet();
            myDa.Fill(myDataSet, "profile_table");
            dgvTransfer.DataSource = myDataSet.Tables["profile_table"];
            myConn.Close();
            dgvTransfer.Columns[0].HeaderText = @"Transfer ID";
            dgvTransfer.Columns[1].HeaderText = @"Linked User ID";
            dgvTransfer.Columns[2].HeaderText = @"Transfer Date";
            dgvTransfer.Columns[3].HeaderText = @"Previous Job";
            dgvTransfer.Columns[4].HeaderText = @"Previous Title";
            dgvTransfer.Columns[5].HeaderText = @"New Job";
            dgvTransfer.Columns[6].HeaderText = @"New Title";
            lblWarning.Text = "Changing transfer log is strictly prohibited! \nPlease contact the administrator if you have any questions.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }
    }
}