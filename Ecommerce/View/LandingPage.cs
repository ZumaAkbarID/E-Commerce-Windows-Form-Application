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
using Ecommerce.View.Admin;
using Ecommerce.View.Admin.Categories;
using Ecommerce.View.Admin.Products;

namespace Ecommerce.View
{
    public partial class LandingPage : Form
    {
        private Users user;
        private GrabUser grabUser;
        public LandingPage()
        {
            InitializeComponent();
            this.CenterToScreen();
            grabUser = new GrabUser();
               
            if(grabUser.Data() != null)
            {
                pictureBoxLogout.Show();
                btn_login.Hide();
                btn_register.Hide();
                lbl_profil.Text = "Halo " + grabUser.Data().NameUser;
                if(grabUser.Data().RoleUser == "Admin")
                {
                    btnAdminListCategory.Show();
                    btnAdminListProducts.Show();
                } else
                {
                    btnAdminListCategory.Hide();
                    btnAdminListProducts.Hide();
                }
            } else
            {
                pictureBoxLogout.Hide();
                btn_login.Show();
                btn_register.Show();
                lbl_profil.Hide();

                btnAdminListCategory.Hide();
                btnAdminListProducts.Hide();
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

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            UsersController usersController = new UsersController();
            if (usersController.Logout() > 0)
            {
                Login login = new Login();
                login.Show();
                Visible = false;
            }
        }

        private void btnAdminListCategory_Click(object sender, EventArgs e)
        {
            ListCategories listCatForm = new ListCategories();
            listCatForm.Show();
            Visible = false;
        }

        private void btnAdminListProducts_Click(object sender, EventArgs e)
        {
            ListProducts listPrdForm = new ListProducts();
            listPrdForm.Show();
            Visible = false;
        }
    }
}
