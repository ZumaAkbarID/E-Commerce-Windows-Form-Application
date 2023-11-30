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

namespace Ecommerce.View.Admin.Categories
{
    public partial class ListCategories : Form
    {
        private List<Model.Entity.Categories> listOfCategory = new List<Model.Entity.Categories>();

        private CategoriesController controller;

        public ListCategories()
        {
            InitializeComponent();
            controller = new CategoriesController();
            InisialisasiListView();
        }

        private void InisialisasiListView()
        {
            lvwCategory.View = System.Windows.Forms.View.Details;
            lvwCategory.FullRowSelect = true;
            lvwCategory.GridLines = true;
            lvwCategory.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwCategory.Columns.Add("Nama Pembuat", 200, HorizontalAlignment.Center);
            lvwCategory.Columns.Add("Nama Kategori", 350, HorizontalAlignment.Left);
        }

        private void LoadDataMahasiswa()
        {
            // kosongkan listview
            lvwCategory.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfCategory = controller.ReadAll();
            // ekstrak objek dari collection
            foreach (var cat in listOfCategory)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Npm);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Angkatan);
                // tampilkan data mhs ke listview
                lvwMahasiswa.Items.Add(item);
            }
        }
    }
}
