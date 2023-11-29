namespace EcommerceDB
{
    public class Connection
    {
        private MySql.Data.MySqlClient.MySqlConnection? conn;
        public string myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=12345;database=test";

        public string test_db()
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                return "Berhasil terkoneksi";
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return ex.Message;
            }
        }
    }
}