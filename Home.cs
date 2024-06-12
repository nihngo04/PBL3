using System;
using System.Windows.Forms;

namespace PBL3_fi
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            Login loginForm = new Login();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
            /*else
            {
                MessageBox.Show("Login cancelled or failed. Returning to Home screen.");
            }*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
