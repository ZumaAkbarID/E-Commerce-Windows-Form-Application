using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcommerceDB;

namespace Ecommerce
{
    public partial class Landing : Form
    {
        private UserInfo user;
        public Landing()
        {
            InitializeComponent();
            IsLogin();
        }

        private void IsLogin()
        {
            if (EcommerceDB.Login.getIngfo() != null && EcommerceDB.Login.getIngfo().UserId != 0)
            {
                user = EcommerceDB.Login.getIngfo();
            }

            if (user != null && user.UserId != 0)
            {
                lbl_profil.Text = "Halo, " + user.Nama;
                btn_login.Hide();
                btn_register.Hide();
            }
            else
            {
                lbl_profil.Hide();
                btn_login.Show();
                btn_register.Show();
            }
        }

        private void Landing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            form_login form_log = new form_login();
            form_log.Show();
            Visible = false;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(EcommerceDB.Login.getIngfo().Nama);
            form_register form_reg = new form_register();
            form_reg.Show();
            Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Landing_Load(object sender, EventArgs e)
        {

        }
    }
}
