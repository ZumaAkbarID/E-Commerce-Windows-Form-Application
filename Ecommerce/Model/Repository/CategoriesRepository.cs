using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Context;
using Ecommerce.Helper;

namespace Ecommerce.Model.Repository
{
    public class CategoriesRepository
    {
        private MySqlConnection _conn;

        public CategoriesRepository(DbContext context)
        {
            _conn = context.Conn;
        }
    }
}
