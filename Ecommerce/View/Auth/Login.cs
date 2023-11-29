using Ecommerce.Controller;
using Ecommerce.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecommerce.View;

namespace Ecommerce.View.Auth
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();

            pictureBox1.ImageLocation = "https://forumasisten.or.id/assets/img/asisten/22.11.4640.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            txtPhone.KeyPress += txtPhone_KeyPress;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill all field.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsersController controller = new UsersController();
            result = controller.Login(txtPhone.Text, txtPassword.Text);

            if (result > 0)
            {
                LandingPage Landing = new LandingPage();
                Landing.Show();
                Visible = false;
            }
            else if(result == 0) 
            {
                MessageBox.Show("Account not found.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                MessageBox.Show("Failed to write session.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            
            register.Show();
            Visible = false;
        }
    }
}
