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
using Ecommerce.Controller;
using Ecommerce.Model.Entity;
using Ecommerce.View.Auth;
using Newtonsoft.Json;
using Ecommerce.Helper;

namespace Ecommerce.View
{
    public partial class LandingPage : Form
    {
        private string SessionPath;
        private Users user;
        private GrabUser grabUser;
        public LandingPage()
        {
            InitializeComponent();
            this.CenterToScreen();
            grabUser = new GrabUser();
               
            if(grabUser.Data() != null)
            {
                btn_login.Hide();
                btn_register.Hide();
                btnLogout.Show();
                lbl_profil.Text = "Halo " + grabUser.Data().NameUser;
            } else
            {
                btn_login.Show();
                btn_register.Show();
                btnLogout.Hide();
                lbl_profil.Hide();
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
            Register register = new Register();
            register.Show();
            Visible = false;
        }

        private void LandingPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UsersController usersController = new UsersController();
            if(usersController.Logout() > 0)
            {
                Login login = new Login();
                login.Show();
                Visible = false;
            }
        }
    }
}
