using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ecommerce.Controller;
using Ecommerce.Model.Entity;

namespace Ecommerce.View.Admin.Categories
{
    public partial class ListCategories : Form
    {
        private List<Model.Entity.Categories> listOfCategory = new List<Model.Entity.Categories>();

        private CategoriesController controller;
        private Model.Entity.Categories category;

        public ListCategories()
        {
            InitializeComponent();
            this.CenterToScreen();
            controller = new CategoriesController();
            InisialisasiListView();
            LoadData();
        }

        private void InisialisasiListView()
        {
            lvwCategory.View = System.Windows.Forms.View.Details;
            lvwCategory.FullRowSelect = true;
            lvwCategory.GridLines = true;
            lvwCategory.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwCategory.Columns.Add("Created By", 350, HorizontalAlignment.Left);
            lvwCategory.Columns.Add("Category", 400, HorizontalAlignment.Left);
        }

        private void LoadData()
        {
            // kosongkan listview
            lvwCategory.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfCategory = controller.ReadAll();
            // ekstrak objek dari collection
            foreach (var cat in listOfCategory)
            {
                var noUrut = lvwCategory.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(cat.CreatedByName);
                item.SubItems.Add(cat.Name);
                // tampilkan data mhs ke listview
                lvwCategory.Items.Add(item);
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Model.Entity.Categories cat)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfCategory.Add(cat);
            int noUrut = lvwCategory.Items.Count + 1;
            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(cat.CreatedByName);
            item.SubItems.Add(cat.Name);
            lvwCategory.Items.Add(item);
        }
        // method event handler untuk merespon event OnUpdate,
        private void OnUpdateEventHandler(Model.Entity.Categories cat)
        {
            // ambil index data mhs yang edit
            int index = lvwCategory.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lvwCategory.Items[index];
            itemRow.SubItems[1].Text = cat.CreatedByName;
            itemRow.SubItems[2].Text = cat.Name;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            EntryCategory frmEntry = new EntryCategory("Add Category", controller);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (lvwCategory.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Model.Entity.Categories cat = listOfCategory[lvwCategory.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                EntryCategory frmEntry = new EntryCategory("Edit Data Category", cat, controller);
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

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lvwCategory.SelectedItems.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirm == DialogResult.Yes)
                {
                    // panggil operasi CRUD
                    var result = controller.Delete(listOfCategory[lvwCategory.SelectedIndices[0]].Id);
                    if (result > 0) LoadData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("No data selected", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelCategory_Click(object sender, EventArgs e)
        {
            LandingPage landing = new LandingPage();
            landing.Show();
            Visible = false;
        }

        private void ListCategories_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
