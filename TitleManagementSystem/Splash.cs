using System.Timers;
using System.Windows.Forms;

namespace TitleManagementSystem
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            var authenticator = new Authenticator();
            authenticator.Show();
            timer1.Enabled = false;
            Hide();
        }
    }
}