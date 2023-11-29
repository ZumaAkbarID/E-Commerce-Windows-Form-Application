using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace Ecommerce.Model.Context
{
    public class DbContext : IDisposable
    {
        private MySqlConnection _conn;
        public MySqlConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private MySqlConnection GetOpenConnection()
        {
            MySqlConnection conn = null;
            try 
            {
                string anjayKoneksi = "server=127.0.0.1;uid=root;pwd=;database=db_ecomm";
                conn = new MySqlConnection(anjayKoneksi);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}; Error Number : {1}", ex.Message, ex.Number);
            }
            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
