using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model.Entity
{
    public class Users
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string PhoneUser { get; set; }
        public string AddressUser { get; set; }
        public string PasswordUser { get; set; }
    }
}
