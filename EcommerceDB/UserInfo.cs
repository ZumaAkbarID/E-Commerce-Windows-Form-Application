using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDB
{
    public class UserInfo
    {
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Telepon { get; set; }
        public string Alamat { get; set; }

        // is admin
        public string Username { get; set; }
    }
}
