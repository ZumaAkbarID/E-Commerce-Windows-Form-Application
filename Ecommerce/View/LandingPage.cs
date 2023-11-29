using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.View.Auth;

namespace Ecommerce.View
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
            this.CenterToScreen();

            if (File.Exists(Path.Combine(Application.StartupPath, "Session.json")))
            {
                string data = File.ReadAllText(Path.Combine(Application.StartupPath, "Session.json"));
                if (String.IsNullOrEmpty(data))
                {
                    MessageBox.Show("File is empty.");
                }
                else
                {
                    MessageBox.Show(data);
                }
            }
            else
            {
                MessageBox.Show("File does not exist.");
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Visible = false;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {

        }

        private void LandingPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
