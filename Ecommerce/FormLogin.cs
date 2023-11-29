using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using EcommerceDB;
using static Ecommerce.form_register;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ecommerce
{
    public partial class form_login : Form
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

        private void form_login_Load(object sender, EventArgs e)
        {
            var decoded = JsonConvert.DeserializeObject<ConnectionResult>(Connection.TestConnection());
            if (!decoded.Connected)
            {
                MessageBox.Show("Message: " + decoded.Message);
                Application.Exit();
            }
        }

        public form_login()
        {
            InitializeComponent();
        }

        private void form_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            form_register form_reg = new form_register();
            form_reg.Show();
            Visible = false;
        }

        public bool validation()
        {
            bool status;

            if(String.IsNullOrWhiteSpace(auth.Text) || String.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Lengkapi data!", "Perhatian!");
                status = false;
            } else
            {
                status = true;
            }
            return status;
        }

        public void Clear()
        {
            auth.Text = "";
            password.Text = "";
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(validation())
            {
                object data = new
                {
                    Auth = auth.Text,
                    Password = password.Text
                };

                var result = Login.LoginAttempt(JsonConvert.SerializeObject(data));
                var decoded = JsonConvert.DeserializeObject<Connection.StructureResult>(result);

                if (!decoded.Status)
                {
                    MessageBox.Show("Kesalahan: " + decoded.Message, "Perhatian!");
                }
                else
                {
                    Landing landing = new Landing();
                    landing.Show();
                    Visible = false;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
