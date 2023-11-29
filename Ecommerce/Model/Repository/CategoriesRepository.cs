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
    public class CategoriesRepository
    {
        private MySqlConnection _conn;

        public CategoriesRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Categories category)
        {
            int result = 0;

            string sql = @"insert into categories (created_by, category_name) values (@created_by, @category_name)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                /*cmd.Parameters.AddWithValue("@created_by", user.NameUser);
                cmd.Parameters.AddWithValue("@phone", user.PhoneUser);*/

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
    }
}
