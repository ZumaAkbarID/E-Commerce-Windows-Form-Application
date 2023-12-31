﻿using System;
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
using Ecommerce.Helper;

namespace Ecommerce.View.Admin.Categories
{
    public partial class EntryCategory : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Model.Entity.Categories cat);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private CategoriesController controller;
        private bool isNewData;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Model.Entity.Categories cat;
        private GrabUser grabUser;

        public EntryCategory()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        // constructor untuk inisialisasi data ketika entri data baru
        public EntryCategory(string title, CategoriesController controller) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = true;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public EntryCategory(string title, Model.Entity.Categories obj, CategoriesController controller) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;

            isNewData = false; // set status edit data
            cat = obj;
            txtCategoryName.Text = cat.Name;
        }

        private void btnSaveEC_Click(object sender, EventArgs e)
        {
            if (isNewData) cat = new Model.Entity.Categories();
            grabUser = new GrabUser();

            cat.CreatedByName = grabUser.Data().NameUser;
            cat.Name = txtCategoryName.Text;

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(txtCategoryName.Text);
                if (result == 1) // tambah data berhasil
                {
                    OnCreate(cat); // panggil event OnCreate
                                   // reset form input, utk persiapan input data berikutnya
                    txtCategoryName.Text = "";
                } else if (result == 2)
                {
                    MessageBox.Show("Categories has been reach the limit 5", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Hide();
                } else
                {
                    MessageBox.Show("Failed to create data", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(cat);
                if (result > 0)
                {
                    OnUpdate(cat);
                } else
                {
                    MessageBox.Show("Failed to update data", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Hide();
            }
        }

        private void btnCancelEC_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EntryCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
