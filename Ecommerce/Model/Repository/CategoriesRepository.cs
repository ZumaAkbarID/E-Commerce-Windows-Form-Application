using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Context;
using Ecommerce.Helper;
using System.Security.Policy;
using System.Windows.Forms;

namespace Ecommerce.Model.Repository
{
    public class CategoriesRepository
    {
        private MySqlConnection _conn;
        private GrabUser _user;
        private Categories category;

        public CategoriesRepository(DbContext context)
        {
            _conn = context.Conn;
            _user = new GrabUser();
        }

        public int CountAllCategories()
        {
            int result = 0;

            string sql = @"select count(*) from categories";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Count All error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Create(string CategoryName)
        {
            if(CountAllCategories() >= 5) { return 2; }
            int result = 0;

            string sql = @"insert into categories (created_by, category_name) values (@created_by, @category_name)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@created_by", _user.Data().IdUser);
                cmd.Parameters.AddWithValue("@category_name", CategoryName);

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

        public List<Categories> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Categories> list = new List<Categories>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT categories.id, categories.category_name, users.name AS created_by_name FROM categories INNER JOIN users ON categories.created_by = users.id";
                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Categories cat = new Categories();
                            cat.Id = Convert.ToInt32(dtr["id"]);
                            cat.Name = dtr["category_name"].ToString();
                            cat.CreatedByName = dtr["created_by_name"].ToString();

                            list.Add(cat);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        internal int Delete(int Id)
        {
            int result = 0;

            string sql = @"delete from categories where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", Id);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        internal int Update(Categories cat)
        {
            int result = 0;

            string sql = @"update categories set category_name = @category_name where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@category_name", cat.Name);
                cmd.Parameters.AddWithValue("@id", cat.Id);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }
    }
}
