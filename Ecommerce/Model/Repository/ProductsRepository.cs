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

        public int CountCategoryHasProduct()
        {
            int result = 0;

            string sql = @"select count(distinct(id_category)) from products";
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

        internal int Delete(int id)
        {
            int result = 0;

            string sql = @"delete from products where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

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

        public List<Products> ReadAll()
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

        public List<Products> ReadAllCategoriesProducts()
        {
            List<Products> list = new List<Products>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                products.id AS product_id,
                                products.product_name AS product_name,
                                products.price AS product_price,
                                products.description AS product_description,
                                products.stock AS product_stock,
                                products.image AS product_image,
                                categories.id AS category_id,
                                categories.category_name AS category_name
                            FROM
                                products
                            JOIN
                                categories ON products.id_category = categories.id
                            ORDER BY category_name";
                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Products p = new Products();
                            p.Id = Convert.ToInt32(dtr["product_id"]);
                            p.CategoryId = Convert.ToInt32(dtr["category_id"]);
                            p.CategoryName = dtr["category_name"].ToString();
                            p.Name = dtr["product_name"].ToString();
                            p.Description = dtr["product_description"].ToString();
                            p.Stock = Convert.ToInt32(dtr["product_stock"]);
                            p.Price = Convert.ToDouble(dtr["product_price"]);
                            p.Image = dtr["product_image"].ToString();

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

        public Products ReadDetailProduct(int Id)
        {
            Products p = new Products();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                products.id AS product_id,
                                products.product_name AS product_name,
                                products.price AS product_price,
                                products.description AS product_description,
                                products.stock AS product_stock,
                                products.image AS product_image,
                                categories.id AS category_id,
                                categories.category_name AS category_name
                            FROM
                                products
                            JOIN
                                categories ON products.id_category = categories.id
                            WHERE products.id = @id
                            ORDER BY category_name
                            LIMIT 1";
                        
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("id", Id);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            p.Id = Convert.ToInt32(dtr["product_id"]);
                            p.CategoryId = Convert.ToInt32(dtr["category_id"]);
                            p.CategoryName = dtr["category_name"].ToString();
                            p.Name = dtr["product_name"].ToString();
                            p.Description = dtr["product_description"].ToString();
                            p.Stock = Convert.ToInt32(dtr["product_stock"]);
                            p.Price = Convert.ToDouble(dtr["product_price"]);
                            p.Image = dtr["product_image"].ToString();
                            return p;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return p;
        }

        public int Update(Products p)
        {
            int result = 0;

            string sql = @"update products set id_category = @id_category, created_by = @created_by, product_name = @product_name, description = @description, stock = @stock, price = @price, image = @image where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", p.Id);
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
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }


    }
}
