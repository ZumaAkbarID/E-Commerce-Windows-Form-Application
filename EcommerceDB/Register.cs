using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;

namespace EcommerceDB
{
    public class Register
    {
        public static string myConnectionString = Connection.myConnectionString;

        public static bool EmailIsUsed(string email)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();

                string query = "SELECT email FROM pelanggan WHERE email = @Email";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        return rdr.HasRows;
                    }
                }
            }
        }

        public static bool TeleponIsUsed(string telepon)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();

                string query = "SELECT telepon FROM pelanggan WHERE telepon = @Telepon";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Telepon", telepon);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        return rdr.HasRows;
                    }
                }
            }
        }

        public class StructureRegister
        {
            public string Nama { get; set; }
            public string Email { get; set; }
            public string Telepon { get; set; }
            public string Alamat { get; set; }
            public string Password { get; set; }
        }

        public static string RegisterAttempt(string data)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                try
                {
                    var decoded = JsonConvert.DeserializeObject<StructureRegister>(data);

                    conn.Open();

                    // Query untuk insert data
                    string query = "INSERT INTO pelanggan (nama, email, telepon, alamat, password) VALUES (@Nama, @Email, @Telepon, @Alamat, @Password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nama", decoded.Nama);
                        cmd.Parameters.AddWithValue("@Email", decoded.Email);
                        cmd.Parameters.AddWithValue("@Telepon", decoded.Telepon);
                        cmd.Parameters.AddWithValue("@Alamat", decoded.Alamat);
                        cmd.Parameters.AddWithValue("@Password", PasswordHasher.BuatMD5Hash(decoded.Password));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        object result;

                        if (rowsAffected > 0)
                        {
                            result = new
                            {
                                Status = true,
                                Message = "Data pelanggan berhasil ditambahkan!"
                            };
                        }
                        else
                        {
                            result = new
                            {
                                Status = false,
                                Message = "Gagal menambahkan data pelanggan."
                            };
                        }

                        return JsonConvert.SerializeObject(result);
                    }
                }
                catch (MySqlException ex)
                {
                    object result = new
                    {
                        Status = false,
                        Message = $"MySQL Error: {ex.Message}"
                    };
                    return JsonConvert.SerializeObject(result);
                }
            }
        }
    }
}
