using System;
using System.Text;

namespace Ecommerce.Helper
{
    public class InvoiceGenerator
    {
        private static Random random = new Random();

        public static string GenerateInvoiceNumber()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder invoiceNumber = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(characters.Length);
                invoiceNumber.Append(characters[index]);
            }

            return "INV-" + invoiceNumber.ToString();
        }
    }
}
