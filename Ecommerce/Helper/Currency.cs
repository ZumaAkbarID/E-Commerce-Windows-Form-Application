using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce.Helper
{
    public class Currency
    {
        public string ConvertToIdn(double amount)
        {
            return "Rp. " + Regex.Replace(amount.ToString("N2", new System.Globalization.CultureInfo("id-ID")), @"(?<=\d)(?=(\d{3})+(?!\d))", ".");
        }
    }
}
