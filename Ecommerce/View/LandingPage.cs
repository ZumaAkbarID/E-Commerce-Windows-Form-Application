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
using System.Text.RegularExpressions;

namespace Ecommerce.View
{
    public partial class LandingPage : Form
    {
        private Users user;
        private GrabUser grabUser;
        private LandingPageController controller;
        private Currency currency;
        private List<Products> listOfProducts = new List<Products>();
        private string role = ""; 
        public LandingPage()
        {
            InitializeComponent();
            this.CenterToScreen();
            grabUser = new GrabUser();
            controller = new LandingPageController();
            currency = new Currency();
               
            if(grabUser.Data() != null)
            {
                pictureBoxLogout.Show();
                pictureBoxProfile.Show();
                btn_login.Hide();
                btn_register.Hide();
                lbl_profil.Text = "Halo " + grabUser.Data().NameUser;
                role = grabUser.Data().RoleUser;
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
                pictureBoxProfile.Hide();
                btn_login.Show();
                btn_register.Show();
                lbl_profil.Hide();

                btnAdminListCategory.Hide();
                btnAdminListProducts.Hide();
            }

            LoadCatalog();
            AssignEventButton();
        }

        private void ProductElementsHandler(int x, int y, bool visibility)
        {
            string categoryControlName = $"txtCategory{y}";
            string imageControlName = $"image{x}_{y}";
            string titleControlName = $"txtTitle{x}_{y}";
            string priceControlName = $"txtPrice{x}_{y}";
            string buyButtonName = $"btnBuy{x}_{y}";
            string detailButtonName = $"btnDetail{x}_{y}";

            Control categoryControl = Controls.Find(categoryControlName, true).FirstOrDefault();
            Control imageControl = Controls.Find(imageControlName, true).FirstOrDefault();
            Control titleControl = Controls.Find(titleControlName, true).FirstOrDefault();
            Control priceControl = Controls.Find(priceControlName, true).FirstOrDefault();
            Control buyButton = Controls.Find(buyButtonName, true).FirstOrDefault();
            Control detailButton = Controls.Find(detailButtonName, true).FirstOrDefault();

            if(visibility)
            {
                if(x == 1)
                {
                    categoryControl.Show();
                }
                imageControl?.Show();
                titleControl?.Show();
                priceControl?.Show();
                buyButton?.Show();
                detailButton?.Show();
            } else
            {
                if(x == 1)
                {
                    categoryControl.Hide();
                }
                imageControl?.Hide();
                titleControl?.Hide();
                priceControl?.Hide();
                buyButton?.Hide();
                detailButton?.Hide();
            }
            
        }

        private void SetProductData(int x, int y, string category_name, string image, string product_name, double price, int id)
        {
            string idControlName = $"idProduct{x}_{y}";
            string imageControlName = $"image{x}_{y}";
            string titleControlName = $"txtTitle{x}_{y}";
            string priceControlName = $"txtPrice{x}_{y}";

            PictureBox imageControl = Controls.Find(imageControlName, true).FirstOrDefault() as PictureBox;
            Label titleControl = Controls.Find(titleControlName, true).FirstOrDefault() as Label;
            Label priceControl = Controls.Find(priceControlName, true).FirstOrDefault() as Label;
            Label idControl = Controls.Find(idControlName, true).FirstOrDefault() as Label;

            if(x == 1)
            {
                string categoryControlName = $"txtCategory{y}";
                Label categoryControl = Controls.Find(categoryControlName, true).FirstOrDefault() as Label;
                if(categoryControl != null)
                {
                    categoryControl.Text = "• " + category_name;
                }
            }

            if (idControl != null)
            {
                idControl.Text = id.ToString();
            }

            if (imageControl != null)
            {
                imageControl.Load(image);
                imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (titleControl != null)
            {
                titleControl.Text = product_name;
            }

            if (priceControl != null)
            {
                priceControl.Text = currency.ConvertToIdn(price);
            }

            ProductElementsHandler(x, y, true);
        }

        private void LoadCatalog()
        {
            int totalX = 5;
            int totalY = 5;

            int tempX = 1;
            int tempY = 1;
            string tempCat = string.Empty;

            for(int y = 1; y <= totalY; y++)
            {
                for (int x = 1; x <= totalX; x++)
                {
                    ProductElementsHandler(x, y, false);
                }
            }
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfProducts = controller.ReadAllCategoriesProducts();
            // ekstrak objek dari collection
            foreach (var p in listOfProducts)
            {
                if(tempX == 6) { 
                    tempX = 1;
                } else if (tempX == 1)
                {
                    tempCat = p.CategoryName;
                } else if(tempCat != p.CategoryName)
                {
                    tempX = 1;
                    tempY++;
                    tempCat = p.CategoryName;
                }

                if (p.CategoryName == tempCat)
                {
                    SetProductData(tempX, tempY, tempCat, p.Image, p.Name, p.Price, p.Id);
                    tempX++;
                }
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            if(grabUser.Data() == null)
            {
                MessageBox.Show("You need to login", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (role == "Admin")
            {
                MessageBox.Show("LUWH ITU ADMIN CUY! SY SUDAH MLS NGERJAIN");
                return;
            }

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Match buttonInfo = Regex.Match(clickedButton.Name, @"([a-zA-Z]+)(\d+)_(\d+)");
                string x = buttonInfo.Groups[2].Value;
                string y = buttonInfo.Groups[3].Value;

                string idControlName = $"idProduct{x}_{y}";
                Label idControl = Controls.Find(idControlName, true).FirstOrDefault() as Label;
                if (idControl != null)
                {
                    var dtlPrd = new DetailProduct(Convert.ToInt32(idControl.Text), true);
                    dtlPrd.BELI_OM();
                }
                else
                {
                    MessageBox.Show("ERROR", "ALERT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void BtnDetail_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Match buttonInfo = Regex.Match(clickedButton.Name, @"([a-zA-Z]+)(\d+)_(\d+)");
                string x = buttonInfo.Groups[2].Value;
                string y = buttonInfo.Groups[3].Value;
                string idControlName = $"idProduct{x}_{y}";
                Label idControl = Controls.Find(idControlName, true).FirstOrDefault() as Label;
                if (idControl != null)
                {
                    DetailProduct detail = new DetailProduct(Convert.ToInt32(idControl.Text));
                    detail.Show();
                    Visible = false;
                } else
                {
                    MessageBox.Show("ERROR", "ALERT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AssignEventButton()
        {
            for (int x = 1; x <= 3; x++)
            {
                for (int y = 1; y <= 3; y++)
                {
                    string buttonBuyName = $"btnBuy{x}_{y}";
                    string buttonDetailName = $"btnDetail{x}_{y}";
                    Button buttonBuy = Controls.Find(buttonBuyName, true).FirstOrDefault() as Button;
                    Button buttonDetail = Controls.Find(buttonDetailName, true).FirstOrDefault() as Button;

                    if (buttonBuy != null)
                    {
                        buttonBuy.Click += BtnBuy_Click;
                    }
                    if (buttonDetail != null)
                    {
                        buttonDetail.Click += BtnDetail_Click;
                    }
                }
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

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            Profile prf = new Profile();
            prf.Show();
            Visible = false;
        }
    }
}
