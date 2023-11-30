using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce.Helper
{
    public class Input
    {
        public bool preventNonNumeric(KeyPressEventArgs e)
        {
            return (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) ? true : false;
        }
    }
}
