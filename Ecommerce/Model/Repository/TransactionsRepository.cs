using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Helper;
using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace Ecommerce.Model.Repository
{
    public class TransactionsRepository
    {
        private MySqlConnection _conn;
        private Transactions trx;

        public TransactionsRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public bool StockDecrement(int id)
        {
            int result = 0;
            string sql = @"select stock from products where id = @id limit 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            if (result < 1) { return false; }
            
            sql = @"update products set stock = @stock where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@stock", result - 1);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    return false;
                }
            }
        }

        public bool StockIncrement(int id)
        {
            int result = 0;
            string sql = @"select stock from products where id = @id limit 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            sql = @"update products set stock = @stock where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@stock", result + 1);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    return false;
                }
            }
        }

        public int Delete(string InvoiceNumber, int idProduct)
        {
            int result = 0;

            if(!StockIncrement(idProduct)) { return result; }

            string sql = @"delete from transactions where invoice_number = @invoice_number";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@invoice_number", trx.InvoiceNumber);

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

        public int Create(Transactions trx)
        {
            int result = 0;

            if (!StockDecrement(trx.IdProduct)) { return result; }

            string sql = @"insert into transactions (id_user, id_product, status, invoice_number, date) values (@id_user, @id_product, @status, @invoice_number, @date)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_user", trx.IdUser);
                cmd.Parameters.AddWithValue("@id_product", trx.IdProduct);
                cmd.Parameters.AddWithValue("@status", "unpaid");
                cmd.Parameters.AddWithValue("@invoice_number", trx.InvoiceNumber);
                cmd.Parameters.AddWithValue("@date", trx.DateTime);

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

        public int Pay(string InvoiceNumber, double amount)
        {
            int result = 0;

            string sql = @"update transactions set status = @paid, payed = @payed where invoice_number = @invoice_number";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@paid", "paid");
                cmd.Parameters.AddWithValue("@payed", amount);
                cmd.Parameters.AddWithValue("@invoice_number", InvoiceNumber);

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

        public List<Transactions> ReadAllTransactionWhereUser(int Id)
        {
            List<Transactions> list = new List<Transactions>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                t.id,
                                c.category_name AS category_name,
                                p.product_name AS product_name,
                                p.price AS product_price,
                                p.image AS product_image,
                                t.invoice_number,
                                t.status,
                                t.date,
                                t.payed,
                                u.name AS user_name
                            FROM transactions t
                            JOIN products p ON t.id_product = p.id
                            JOIN categories c ON p.id_category = c.id
                            JOIN users u ON t.id_user = u.id
                            WHERE u.id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Transactions t = new Transactions();

                            t.Id = Convert.ToInt32(dtr["id"]);
                            t.UserName = Convert.ToString(dtr["user_name"]);
                            t.ProductName = Convert.ToString(dtr["product_name"]);
                            t.ImageProduct = Convert.ToString(dtr["product_image"]);
                            t.CategoryName = Convert.ToString(dtr["category_name"]);
                            t.Status = Convert.ToString(dtr["status"]);
                            t.InvoiceNumber = Convert.ToString(dtr["invoice_number"]);
                            t.DateTime = Convert.ToDateTime(dtr["date"]);
                            if (String.IsNullOrEmpty(dtr["payed"].ToString()))
                            {
                                t.Payed = Convert.ToDouble(0);
                            }
                            else
                            {
                                t.Payed = Convert.ToDouble(dtr["payed"]);
                            }
                            t.Price = Convert.ToDouble(dtr["product_price"]);

                            list.Add(t);
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

        public List<Transactions> ReadAllTransaction()
        {
            List<Transactions> list = new List<Transactions>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                t.id,
                                c.category_name AS category_name,
                                p.product_name AS product_name,
                                p.price AS product_price,
                                p.image AS product_image,
                                t.invoice_number,
                                t.status,
                                t.date,
                                t.payed,
                                u.name AS user_name
                            FROM transactions t
                            JOIN products p ON t.id_product = p.id
                            JOIN categories c ON p.id_category = c.id
                            JOIN users u ON t.id_user = u.id";

                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Transactions t = new Transactions();

                            t.Id = Convert.ToInt32(dtr["id"]);
                            t.UserName = Convert.ToString(dtr["user_name"]);
                            t.ProductName = Convert.ToString(dtr["product_name"]);
                            t.ImageProduct = Convert.ToString(dtr["product_image"]);
                            t.CategoryName = Convert.ToString(dtr["category_name"]);
                            t.Status = Convert.ToString(dtr["status"]);
                            t.InvoiceNumber = Convert.ToString(dtr["invoice_number"]);
                            t.DateTime = Convert.ToDateTime(dtr["date"]);
                            if (String.IsNullOrEmpty(dtr["payed"].ToString()))
                            {
                                t.Payed = Convert.ToDouble(0);
                            }
                            else
                            {
                                t.Payed = Convert.ToDouble(dtr["payed"]);
                            }
                            t.Price = Convert.ToDouble(dtr["product_price"]);

                            list.Add(t);
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
