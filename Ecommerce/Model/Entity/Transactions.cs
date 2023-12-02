using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model.Entity
{
    public class Transactions
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateTime { get; set; }
        public double Payed { get; set; }
        public double Price { get; set; }
    }
}
