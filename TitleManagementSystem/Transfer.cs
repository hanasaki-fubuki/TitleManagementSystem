using System;
using System.Configuration;
using System.Windows.Forms;

namespace TitleManagementSystem
{
    public partial class Transfer : Form
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
        
        public Transfer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}