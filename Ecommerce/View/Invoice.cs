﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecommerce.Controller;
using Ecommerce.Helper;
using Ecommerce.Model.Entity;

namespace Ecommerce.View
{
    public partial class Invoice : Form
    {
        private Transactions trx;
        private Currency currency;
        private double price;
        private string InvoiceNumber;
        private int idProduct;
        private string status;
        private bool isDirect;
        private TransactionsController trxController;

        public delegate void CreateUpdateEventHandler();
        public event CreateUpdateEventHandler OnUpdate;
        public Invoice()
        {
            InitializeComponent();
            this.CenterToScreen();

            currency = new Currency();
            trxController = new TransactionsController();

            InisialisasiListView();
        }

        public Invoice(Transactions trx, bool direct = false, bool isAdmin = false) : this()
        {
            InvoiceNumber = trx.InvoiceNumber;
            idProduct = trx.IdProduct;
            status = trx.Status;
            isDirect = direct;

            txtDear.Text = "Dear, " + trx.UserName;
            txtDate.Text = trx.DateTime.ToString();
            txtInvoiceNumber.Text = trx.InvoiceNumber;

            if (trx.Status == "unpaid")
            {
                btnUnpaid.Show();
                btnPaid.Hide();
            }
            else
            {
                btnUnpaid.Hide();
                btnPaid.Show();
                label2.Text = "Payment Amount: ";
                txtDuit.Text = currency.ConvertToIdn(trx.Payed);
                txtDuit.ReadOnly = true;
                btnOkInvoice.Hide();
            }

            if (isAdmin)
            {
                txtDuit.ReadOnly = true;
                btnOkInvoice.Hide();
                if (trx.Status == "unpaid")
                {
                    txtDuit.Hide();
                    label2.Hide();
                }
            }

            var noUrut = listView1.Items.Count + 1;
            var item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(trx.CategoryName);
            item.SubItems.Add(trx.ProductName);
            item.SubItems.Add("1x");
            item.SubItems.Add(currency.ConvertToIdn(trx.Price));
            price = trx.Price;
            // tampilkan data mhs ke listview
            listView1.Items.Add(item);
            txtDuit.Focus();
        }
        private void InisialisasiListView()
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add("No.", 35, HorizontalAlignment.Center);
            listView1.Columns.Add("Category", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Product", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Amount", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Price", 150, HorizontalAlignment.Left);
        }

        private void Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOkInvoice_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDuit.Text))
            {
                MessageBox.Show("Om mana duitnya 😭");
                return;
            } 

            double duit = Convert.ToDouble(txtDuit.Text);
            
            if (duit < price)
            {
                MessageBox.Show("Duitnya kurang om 😭");
                return;
            } else if (duit == price) {
                MessageBox.Show("Pas ya om duitnya 😃");
            } else
            {
                MessageBox.Show($"Makasih om, ini kembaliannya {currency.ConvertToIdn(duit - price)} 🤑");
            }

            if (trxController.Pay(InvoiceNumber, duit) > 0)
            {
                if (isDirect)
                {
                    OnUpdate();
                    this.Visible = false;
                    return;
                }
                Profile prf = new Profile();
                prf.Show();
                Visible = false;
                return;
            }
            {
                MessageBox.Show("Failed to pay!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {
            if (isDirect)
            {
                this.Visible = false;
                return;
            }
            Profile prf = new Profile();
            prf.Show();
            Visible = false;
        }
    }
}
