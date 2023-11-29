using EcommerceDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcommerceDB;

namespace Ecommerce
{
    public partial class form_register : Form
    {
        Connection conn = new Connection();

        public class ConnectionResult
        {
            public bool Connected { get; set; }
            public string Message { get; set; }
        }

        public void ForceFullScreen()
        {
            // Force full screen
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void form_register_Load(object sender, EventArgs e)
        {
            var decoded = JsonConvert.DeserializeObject<ConnectionResult>(Connection.TestConnection());
            if (!decoded.Connected)
            {
                MessageBox.Show("Message: " + decoded.Message);
                Application.Exit();
            }
        }
        public form_register()
        {
            InitializeComponent();

            // Mengaitkan event handler dengan event KeyPress
            telepon.KeyPress += TeleponTextBox_KeyPress;
        }

        private void TeleponTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Memeriksa apakah karakter yang dimasukkan adalah angka atau kontrol karakter (seperti Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Jika bukan angka atau kontrol, tolak karakter tersebut
                e.Handled = true;
            }
        }

        private void form_register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            form_login form_log = new form_login();
            form_log.Show();
            Visible = false;
        }

        public void Clear()
        {
            nama.Text = "";
            email.Text = "";
            telepon.Text = "";
            alamat.Text = "";
            password.Text = "";
        }

        public bool validation()
        {
            bool status;

            if(String.IsNullOrWhiteSpace(nama.Text) || String.IsNullOrWhiteSpace(email.Text) || String.IsNullOrWhiteSpace(telepon.Text) || String.IsNullOrWhiteSpace(alamat.Text) || String.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Lengkapi data!", "Perhatian!");
                status = false;
            } else if (password.Text.Length < 6)
            {
                MessageBox.Show("Password minimal 6 karakter!", "Perhatian!");
                status = false;
            } else if (!email.Text.Contains("@") || !email.Text.Contains("."))
            {
                MessageBox.Show("Email tidak valid!", "Perhatian!");
                status = false;
            } else
            {
                if (Register.EmailIsUsed(email.Text))
                {
                    MessageBox.Show("Email telah terdaftar!", "Perhatian!");
                    status = false;
                } else if (Register.TeleponIsUsed(telepon.Text)) {
                    MessageBox.Show("Telepon telah terdaftar!", "Perhatian!");
                    status = false;
                } else
                {
                    status = true;
                }
            }

            return status;
        }

        
        private void btn_register_Click(object sender, EventArgs e)
        {
            if(validation())
            {
                object data = new
                {
                    Nama = nama.Text,
                    Email = email.Text,
                    Telepon = telepon.Text,
                    Alamat = alamat.Text,
                    Password = password.Text
                };

                var result = Register.RegisterAttempt(JsonConvert.SerializeObject(data));
                var decoded = JsonConvert.DeserializeObject<Connection.StructureResult>(result);

                if (!decoded.Status)
                {
                    MessageBox.Show("Kesalahan: " + decoded.Message, "Perhatian!");
                    Clear();
                } else
                {
                    MessageBox.Show(decoded.Message, "Informasi");
                    Clear();
                    form_login form_log = new form_login();
                    form_log.Show();
                    Visible = false;
                }
            }
        }
    }
}
