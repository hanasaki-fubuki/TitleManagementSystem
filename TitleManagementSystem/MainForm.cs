using System;
using System.Configuration;
using System.Windows.Forms;

namespace TitleManagementSystem
{
    public partial class MainForm : Form
    {
        
        private string _mainConn = ConfigurationManager.ConnectionStrings["MainConnection"].ToString();
        public MainForm()
        {
            InitializeComponent();
        }
        
    }
}