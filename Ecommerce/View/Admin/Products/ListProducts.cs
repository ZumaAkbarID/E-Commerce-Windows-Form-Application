using Ecommerce.Controller;
using Ecommerce.Helper;
using Ecommerce.View.Admin.Categories;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce.View.Admin.Products
{
    public partial class ListProducts : Form
    {
        private List<Model.Entity.Products> listOfProducts = new List<Model.Entity.Products>();
        private ProductsController controller;
        private ImageList imageList;
        private Currency currency;

        public ListProducts()
        {
            InitializeComponent();
            this.CenterToScreen();

            currency = new Currency();
            controller = new ProductsController();

            InisialisasiListView();
            LoadData();
        }

        private void InisialisasiListView()
        {
            imageList = new ImageList();
            imageList.ImageSize = new Size(150, 150);

            lvwProduct.View = System.Windows.Forms.View.Details;
            lvwProduct.FullRowSelect = true;
            lvwProduct.GridLines = true;
            lvwProduct.Columns.Add("Picture", 150, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Category", 200, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Product", 200, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Stock", 100, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Price", 150, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Created By", 150, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Description", 300, HorizontalAlignment.Left);
        }

        private void AddListViewItemFromUrl(int noUrut, Model.Entity.Products p)
        {
            try
            {
                // Download gambar dari URL
                WebClient webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(p.Image);

                // Convert bytes menjadi objek Image
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(stream);

                    // Tambahkan gambar ke dalam ImageList
                    imageList.Images.Add(p.Image, image);

                    // Buat objek ListViewItem
                    ListViewItem item = new ListViewItem();
                    item.ImageKey = p.Image; // Set kunci gambar sesuai nama

                    // Tambahkan teks tambahan ke dalam ListViewItem
                    item.SubItems.Add(p.CategoryName);
                    item.SubItems.Add(p.Name);
                    item.SubItems.Add(p.Stock.ToString());
                    item.SubItems.Add(currency.ConvertToIdn(p.Price));
                    item.SubItems.Add(p.CreatedByName);
                    item.SubItems.Add(p.Description);

                    // Tambahkan ListViewItem ke dalam ListView
                    lvwProduct.Items.Add(item);
                    lvwProduct.SmallImageList = imageList;
                }
            }
            catch (Exception ex)
            {
                // Tangani kesalahan jika terjadi saat mendownload atau mengkonversi gambar
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadData()
        {
            // kosongkan listview
            lvwProduct.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfProducts = controller.ReadAll();
            // ekstrak objek dari collection
            foreach (var p in listOfProducts)
            {
                var noUrut = lvwProduct.Items.Count + 1;
                /*var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(p.);
                // tampilkan data mhs ke listview
                lvwProduct.Items.Add(item);*/
                AddListViewItemFromUrl(noUrut, p);
                
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Model.Entity.Products p)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfProducts.Add(p);
            LoadData();
            //AddListViewItemFromUrl(lvwProduct.Items.Count + 1, p);
        }
        // method event handler untuk merespon event OnUpdate,
        private void OnUpdateEventHandler(Model.Entity.Products p)
        {
            LoadData();
        }

        private void ListProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            EntryProduct entry = new EntryProduct();
            entry.OnCreate += OnCreateEventHandler;
            entry.ShowDialog();
        }

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            LandingPage landing = new LandingPage();
            landing.Show();
            Visible = false;
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (lvwProduct.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Model.Entity.Products p = listOfProducts[lvwProduct.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                EntryProduct frmEntry = new EntryProduct("Edit Data " + p.Name, p, controller);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmEntry.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                frmEntry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("No data selected", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (lvwProduct.SelectedItems.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirm == DialogResult.Yes)
                {
                    // panggil operasi CRUD
                    var result = controller.Delete(listOfProducts[lvwProduct.SelectedIndices[0]].Id);

                    if (result > 0) LoadData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("No data selected", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
