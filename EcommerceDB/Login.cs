using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace EcommerceDB
{
    public class Login
    {
        public static string myConnectionString = Connection.myConnectionString;

        private static UserInfo ingfo;

        public class StructureLogin
        {
            public string Auth { get; set; }
            public string Password { get; set; }
        }

        static bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        public static string LoginAttempt(string data)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                try
                {
                    var decoded = JsonConvert.DeserializeObject<StructureLogin>(data);

                    conn.Open();

                    bool isNumeric = IsNumeric(decoded.Auth);
                    string query;
                    if (isNumeric)
                    {
                        query = "SELECT * FROM pelanggan WHERE telepon = @Telepon AND password = @Password";
                    }
                    else
                    {
                        query = "SELECT * FROM pelanggan WHERE email = @Email AND password = @Password";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (isNumeric)
                        {
                            cmd.Parameters.AddWithValue("@Telepon", decoded.Auth);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Email", decoded.Auth);
                        }

                        cmd.Parameters.AddWithValue("@Password", PasswordHasher.BuatMD5Hash(decoded.Password));

                        object result;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId;
                                bool userIdParsed = int.TryParse(reader["id"].ToString(), out userId);

                                string userNama = reader["nama"].ToString();
                                string userEmail = reader["email"].ToString();
                                string userTelepon = reader["telepon"].ToString();

                                string userAlamat = reader["alamat"].ToString();

                                if (userIdParsed)
                                {
                                    ingfo = new UserInfo
                                    {
                                        IsAdmin = false,
                                        UserId = userId,
                                        Nama = userNama,
                                        Email = userEmail,
                                        Telepon = userTelepon,
                                        Alamat = userAlamat
                                    };

                                    result = new
                                    {
                                        Status = true,
                                        Message = ""
                                    };
                                }
                                else
                                {
                                    // Penanganan jika parsing gagal
                                    result = new
                                    {
                                        Status = false,
                                        Message = "Gagal membaca data pengguna. Format data tidak valid.",
                                        //Message = userId.GetType() + " | " + reader["alamat"].ToString().GetType(),
                                    };
                                }
                            }
                            else
                            {
                                result = new
                                {
                                    Status = false,
                                    Message = "Akun tidak ditemukan."
                                };
                            }
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

        public static UserInfo getIngfo()
        {
            return ingfo;
        }
    }
}
