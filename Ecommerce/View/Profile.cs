using Ecommerce.Controller;
using Ecommerce.Helper;
using Ecommerce.View.Admin.Products;
using Ecommerce.View.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.Model.Entity;

namespace Ecommerce.View
{
    public partial class Profile : Form
    {
        private GrabUser grabUser;
        private ImageList imageList;
        private Currency currency;
        private List<Transactions> listOfTrx = new List<Transactions>();
        private ProfileController controller;
        private string role;
        public Profile()
        {
            InitializeComponent();
            this.CenterToScreen();
            
            controller = new ProfileController();
            grabUser = new GrabUser();
            currency = new Currency();

            var user = grabUser.Data();
            role = user.RoleUser;

            LoadProfile();
            InisialisasiListView();
            LoadData();
        }

        private void LoadProfile()
        {
            var user = grabUser.Data();
            txtName.Text = user.NameUser;
            txtAddress.Text = user.AddressUser;
            txtPhone.Text = user.PhoneUser;
            txtRole.Text = user.RoleUser;
            if(role == "Admin")
            {
                label6.Show();
                label5.Hide();
                button1.Text = "Check";
            } else
            {
                label6.Hide();
                label5.Show();
                button1.Text = "Pay";
            }
        }

        private void InisialisasiListView()
        {
            imageList = new ImageList();
            imageList.ImageSize = new Size(150, 150);

            lvwProfile.View = System.Windows.Forms.View.Details;
            lvwProfile.FullRowSelect = true;
            lvwProfile.GridLines = true;
            lvwProfile.Columns.Add("Picture", 150, HorizontalAlignment.Center);
            lvwProfile.Columns.Add("Invoice", 100, HorizontalAlignment.Left);
            if (role == "Admin")
            {
                lvwProfile.Columns.Add("User Name", 110, HorizontalAlignment.Left);
                lvwProfile.Columns.Add("Category", 100, HorizontalAlignment.Left);
                lvwProfile.Columns.Add("Product", 100, HorizontalAlignment.Left);
            }
            else
            {
                lvwProfile.Columns.Add("Category", 130, HorizontalAlignment.Left);
                lvwProfile.Columns.Add("Product", 200, HorizontalAlignment.Left);
            }
            lvwProfile.Columns.Add("Amount", 70, HorizontalAlignment.Center);
            lvwProfile.Columns.Add("Price", 120, HorizontalAlignment.Center);
            lvwProfile.Columns.Add("Payment Amount", 120, HorizontalAlignment.Left);
            lvwProfile.Columns.Add("Date", 130, HorizontalAlignment.Left);
        }

        private void AddListViewItemFromUrl(int noUrut, Transactions t)
        {
            try
            {
                // Download gambar dari URL
                WebClient webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(t.ImageProduct);

                // Convert bytes menjadi objek Image
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(stream);

                    // Tambahkan gambar ke dalam ImageList
                    imageList.Images.Add(t.ImageProduct, image);

                    // Buat objek ListViewItem
                    ListViewItem item = new ListViewItem();
                    item.ImageKey = t.ImageProduct; // Set kunci gambar sesuai nama

                    // Tambahkan teks tambahan ke dalam ListViewItem
                    item.SubItems.Add(t.InvoiceNumber);
                    if(role == "Admin")
                    {
                        item.SubItems.Add(t.UserName);
                    }
                    item.SubItems.Add(t.CategoryName);
                    item.SubItems.Add(t.ProductName);
                    item.SubItems.Add("1x");
                    item.SubItems.Add(currency.ConvertToIdn(t.Price));
                    if (t.Payed == 0)
                    {
                        item.SubItems.Add("Unpaid");
                    } else
                    {
                        item.SubItems.Add(currency.ConvertToIdn(t.Payed));
                    }
                    item.SubItems.Add(t.DateTime.ToString());

                    // Tambahkan ListViewItem ke dalam ListView
                    lvwProfile.Items.Add(item);
                    lvwProfile.SmallImageList = imageList;
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
            lvwProfile.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            if(role == "Admin")
            {
                listOfTrx = controller.ReadAllTransaction();
            } else
            {
                listOfTrx = controller.ReadAllTransactionWhereUser(grabUser.Data().IdUser);
            }
            
            // ekstrak objek dari collection
            foreach (var t in listOfTrx)
            {
                var noUrut = lvwProfile.Items.Count + 1;
                AddListViewItemFromUrl(noUrut, t);

            }
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LandingPage landing = new LandingPage();
            landing.Show();
            Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwProfile.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Model.Entity.Transactions t = listOfTrx[lvwProfile.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                if(role == "Admin")
                {
                    Invoice inv = new Invoice(t, true, true);
                    // tampilkan form entry
                    inv.ShowDialog();
                } else
                {
                    Invoice inv = new Invoice(t, true);
                    // mendaftarkan method event handler untuk merespon event OnUpdate
                    inv.OnUpdate += LoadData;
                    // tampilkan form entry
                    inv.ShowDialog();
                }
                
            }
            else // data belum dipilih
            {
                MessageBox.Show("No data selected", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvwProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(role == "Admin") { return; }

            if (lvwProfile.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Model.Entity.Transactions t = listOfTrx[lvwProfile.SelectedIndices[0]];
                if (t.Status == "paid")
                {
                    button1.Text = "View";
                } else
                {
                    button1.Text = "Pay";
                }
            }
        }
    }
}
