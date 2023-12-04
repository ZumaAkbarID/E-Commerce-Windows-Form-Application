using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Ecommerce.Controller;
using Ecommerce.Helper;
using Ecommerce.Model.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ecommerce.View.Admin.Products
{
    public partial class EntryProduct : Form
    {
        private Input inputHandler;
        private ImageBB imgBB;

        private ProductsController controller;

        private Model.Entity.Categories category;
        private Model.Entity.Products product;
        private ResponseImageBB responseImgBB;

        List<Model.Entity.Categories> listOfCategories = new List<Model.Entity.Categories>();

        private bool selectedPicture = false;
        private string selectedPicturePath;
        private string defaultPicture;

        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Model.Entity.Products product);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        private bool isNewData;

        private GrabUser grabUser;

        public EntryProduct()
        {
            InitializeComponent();
            this.CenterToScreen();

            isNewData = true;

            inputHandler = new Input();

            listOfCategories = new ProductsController().ReadAllCategory();
            foreach (Model.Entity.Categories category in listOfCategories)
            {
                cmbCategories.Items.Add(category.Name);
            }

            defaultPicture = "https://placehold.co/200x200.png?text=1:1+Better";
            pictureBox1.Load(defaultPicture);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public EntryProduct(string title, ProductsController controller) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = true;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public EntryProduct(string title, Model.Entity.Products prd, ProductsController controller) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;

            isNewData = false; // set status edit data
            selectedPicture = false;
            product = prd;
            foreach (var item in cmbCategories.Items)
            {
                if (item.ToString() == prd.CategoryName)
                {
                    cmbCategories.SelectedItem = item;
                    break; 
                }
            }
            txtProductName.Text = prd.Name;
            txtStock.Text = prd.Stock.ToString();
            txtPrice.Text = prd.Price.ToString();
            txtDescProduct.Text = prd.Description;
            pictureBox1.Load(prd.Image);
        }

        private void EntryProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private async void btnSaveProduct_Click(object sender, EventArgs e)
        {
            /*imgBB = new ImageBB();
            ResponseImageBB responseImgBB = await imgBB.UploadImageAsync(selectedPicturePath);
            MessageBox.Show(responseImgBB.data.url);*/

            if (String.IsNullOrEmpty(cmbCategories.SelectedIndex.ToString()) || String.IsNullOrEmpty(txtProductName.Text) || String.IsNullOrEmpty(txtStock.Text) || String.IsNullOrEmpty(txtPrice.Text) || String.IsNullOrEmpty(txtDescProduct.Text))
            {
                MessageBox.Show("Please fill all field.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cmbCategories.SelectedIndex < 0)
            {
                MessageBox.Show("Please select valid category.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (isNewData && !selectedPicture)
            {
                MessageBox.Show("Please fill all field.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isNewData) product = new Model.Entity.Products();

            grabUser = new GrabUser();
            imgBB = new ImageBB();
            ResponseImageBB responseImgBB = new ResponseImageBB();
            ProductsController controller = new ProductsController();

            if(selectedPicture)
            {
                try
                {
                    responseImgBB = await imgBB.UploadImageAsync(selectedPicturePath);

                    if (!responseImgBB.success)
                    {
                        MessageBox.Show(responseImgBB.ToString());
                        MessageBox.Show("Failed upload image to server.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            Model.Entity.Categories cat = listOfCategories[cmbCategories.SelectedIndex];
            product.CategoryId = cat.Id;
            product.CategoryName = cat.Name;
            product.CreatedBy = grabUser.Data().IdUser;
            product.CreatedByName = grabUser.Data().NameUser;
            product.Name = txtProductName.Text;
            product.Description = txtDescProduct.Text;
            product.Stock = Convert.ToInt32(txtStock.Text);
            product.Price = Convert.ToDouble(txtPrice.Text);
            if (selectedPicture)
            {
                product.Image = responseImgBB.data.url;
            } else
            {
                product.Image = pictureBox1.ImageLocation;
            }

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(product);
                if (result == 1) // tambah data berhasil
                {
                    OnCreate(product); // panggil event OnCreate
                                       // reset form input, utk persiapan input data berikutnya
                    cmbCategories.SelectedIndex = -1;
                    txtProductName.Text = "";
                    txtStock.Text = "";
                    txtPrice.Text = "";
                    txtDescProduct.Text = "";
                    pictureBox1.Load(defaultPicture);
                }
                else if (result == 2)
                {
                    MessageBox.Show("Category has been reach the limit 5 product", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create data", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(product);
                if (result == 1)
                {
                    OnUpdate(product);
                } else if (result == 69)
                {
                    MessageBox.Show("Category has been reach the limit 5 product", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Failed to update data", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Hide();
            }
        }

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                selectedPicture = true;
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                selectedPicturePath = opnfd.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = inputHandler.preventNonNumeric(e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = inputHandler.preventNonNumeric(e);
        }
    }
}
