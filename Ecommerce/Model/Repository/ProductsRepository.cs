using Ecommerce.Helper;
using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model.Repository
{
    public class ProductsRepository
    {
        private MySqlConnection _conn;
        private GrabUser _user;
        private Products category;

        public ProductsRepository(DbContext context)
        {
            _conn = context.Conn;
            _user = new GrabUser();
        }

        public int CountAllProducts()
        {
            int result = 0;

            string sql = @"select count(*) from products";
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

        public int CountAllProductsOnCategory(int id_category)
        {
            int result = 0;

            string sql = @"select count(*) from products where id_category = @id_category";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("id_category", id_category);
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

        public int Create(Products p)
        {
            if (CountAllProductsOnCategory(p.CategoryId) >= 5) { return 2; }
            int result = 0;

            string sql = @"insert into products (id_category, created_by, product_name, description, stock, price, image) values (@id_category, @created_by, @product_name, @description, @stock, @price, @image)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_category", p.CategoryId);
                cmd.Parameters.AddWithValue("@created_by", _user.Data().IdUser);
                cmd.Parameters.AddWithValue("@product_name", p.Name);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@price", p.Price);
                cmd.Parameters.AddWithValue("@image", p.Image);

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

        internal List<Products> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Products> list = new List<Products>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                    products.*,
                                    users.name AS created_by_name,
                                    categories.category_name
                                FROM
                                    products
                                JOIN
                                    users ON products.created_by = users.id
                                JOIN
                                    categories ON products.id_category = categories.id";
                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Products p = new Products();
                            p.Id = Convert.ToInt32(dtr["id"]);
                            p.CategoryId = Convert.ToInt32(dtr["id_category"]);
                            p.CategoryName = dtr["category_name"].ToString();
                            p.CreatedBy = Convert.ToInt32(dtr["created_by"]);
                            p.CreatedByName = dtr["created_by_name"].ToString();
                            p.Name = dtr["product_name"].ToString();
                            p.Description = dtr["description"].ToString();
                            p.Stock = Convert.ToInt32(dtr["stock"]);
                            p.Price = Convert.ToDouble(dtr["price"]);
                            p.Image = dtr["image"].ToString();

                            list.Add(p);
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
    }
}
