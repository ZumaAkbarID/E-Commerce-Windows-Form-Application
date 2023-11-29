using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.Model.Entity;
using Ecommerce.Controller;

namespace Ecommerce.View.Auth
{
    public partial class Register : Form
    {
        private UsersController controller;

        private Users user;

        public Register()
        {
            InitializeComponent();
            this.CenterToScreen();

            //pictureBox1.ImageLocation = "https://pmm.kampusmerdeka.kemdikbud.go.id/files/logopt/051024.png";
            pictureBox1.ImageLocation = "https://forumasisten.or.id/assets/img/asisten/22.11.4640.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            txtPhone.KeyPress += txtPhone_KeyPress;
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtCPassword.Text))
            {
                MessageBox.Show("Please fill all field.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (txtPassword.TextLength < 6)
            {
                MessageBox.Show("Password minimum 6 character.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (txtCPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Password confirmation must be same.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Users user = new Users();
            user.NameUser = txtName.Text;
            user.PhoneUser = txtPhone.Text;
            user.AddressUser = txtAddress.Text;
            user.PasswordUser = txtPassword.Text;

            UsersController controller = new UsersController();
            result = controller.Register(user);
            if (result == 69) {
                MessageBox.Show("Phone number already registered", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Text = "";
            } else if (result > 0)
            {
                txtName.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtPassword.Text = "";
                txtCPassword.Text = "";

                DialogResult dialogResult = MessageBox.Show("Your account successfuly created.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login FormLogin = new Login();
                
                FormLogin.Show();
                Visible = false;
            } else
            {
                MessageBox.Show("Failed to create your account.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}