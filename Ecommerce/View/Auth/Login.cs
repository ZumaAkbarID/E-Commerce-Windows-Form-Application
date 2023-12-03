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
using Ecommerce.Helper;

namespace Ecommerce.View.Auth
{
    public partial class Login : Form
    {
        private Input handleInput;
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();

            handleInput = new Input();

            //pictureBox1.ImageLocation = "https://forumasisten.or.id/assets/img/asisten/22.11.4640.jpg";
            pictureBox1.ImageLocation = "https://media.discordapp.net/attachments/1129445903669940404/1180446645608009738/logo.png";
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

            if (result == 2)
            {
                LandingPage Landing = new LandingPage();
                Landing.Show();
                Visible = false;
            }
            else if (result == 0)
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
            e.Handled = handleInput.preventNonNumeric(e);
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
