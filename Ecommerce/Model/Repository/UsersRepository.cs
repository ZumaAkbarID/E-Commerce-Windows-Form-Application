using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Helper;
using System.Security.Policy;

namespace Ecommerce.Model.Repository
{
    public class UsersRepository
    {
        private MySqlConnection _conn;

        public UsersRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int FindByPhone(string phone)
        {
            int result = 0;

            string sql = @"select count(*) from users where phone = @phone";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@phone", phone);

                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Find By Phone error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Create(Users user)
        {
            int result = 0;

            if (FindByPhone(user.PhoneUser) > 0)
            {
                return result = 69;
            }

            string sql = @"insert into users (name, phone, address, password) values (@name, @phone, @address, @password)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@name", user.NameUser);
                cmd.Parameters.AddWithValue("@phone", user.PhoneUser);
                cmd.Parameters.AddWithValue("@address", user.AddressUser);
                cmd.Parameters.AddWithValue("@password", Password.BuatMD5Hash(user.PasswordUser));
                
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            
            return result;
        }

        public int Show(Users user)
        {
            int result = 0;

            string sql = @"select * from users where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", user.IdUser);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Show error: {0}", ex.Message);
                }
            }

            return result;
        }

        public Users LoginAttempt(string phone, string password)
        {
            Users user = new Users();

            string sql = @"select * from users where phone = @phone and password = @password";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@password", Password.BuatMD5Hash(password));

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.IdUser = Convert.ToInt32(reader["id"]);
                        user.NameUser = reader["name"].ToString();
                        user.PhoneUser = reader["phone"].ToString();
                        user.AddressUser = reader["address"].ToString();
                        user.RoleUser = reader["role"].ToString();
                        user.PasswordUser = reader["password"].ToString();
                    }
                }
            }

            return user;
        }

        public List<Users> ReadAll()
        {
            List<Users> list = new List<Users>();
            try
            {
                string sql = @"select * from users order by id";

                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Users user = new Users();
                            user.IdUser = Convert.ToInt32(dtr["id"]);
                            user.NameUser = dtr["name"].ToString();
                            user.PhoneUser = dtr["phone"].ToString();
                            user.RoleUser = dtr["role"].ToString();
                            user.AddressUser = dtr["address"].ToString();

                            list.Add(user);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }
    }
}
