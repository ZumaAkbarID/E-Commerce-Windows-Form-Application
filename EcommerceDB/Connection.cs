using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace EcommerceDB
{
    public class Connection
    {
        private static MySqlConnection conn;
        public static string myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=;database=db_ecommerce";
        public static string isConnectionError = "";

        public Connection()
        {
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        isConnectionError = "Tidak dapat terhubung ke Server";
                        break;
                    case 1045:
                        isConnectionError = "Kesalahan dalam database";
                        break;
                }
            }
        }

        public static string TestConnection()
        {
            object result;
            if (!string.IsNullOrEmpty(isConnectionError))
            {
                result = new
                {
                    Connected = false,
                    Message = isConnectionError
                };
            } else
            {
                result = new
                {
                    Connected = true
                };
            }
            return JsonConvert.SerializeObject(result);
        }

        public class StructureResult
        {
            public bool Status { get; set; }
            public string Message { get; set; }
        }
    }
}