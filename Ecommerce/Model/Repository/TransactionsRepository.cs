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
    }
}
