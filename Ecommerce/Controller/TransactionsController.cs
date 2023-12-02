using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Helper;
using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Repository;

namespace Ecommerce.Controller
{
    public class TransactionsController
    {
        private Transactions trx;
        private GrabUser grabUser;
        private TransactionsRepository _transactionsRepository;

        public int Create(Transactions trx)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _transactionsRepository = new TransactionsRepository(context);
                result = _transactionsRepository.Create(trx);
            }

            return result;
        }

        public int Pay(string InvoiceNumber, double amount)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _transactionsRepository = new TransactionsRepository(context);
                result = _transactionsRepository.Pay(InvoiceNumber, amount);
            }

            return result;
        }

        public int Delete(string InvoiceNumber, int idProduct)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _transactionsRepository = new TransactionsRepository(context);
                result = _transactionsRepository.Delete(InvoiceNumber, idProduct);
            }

            return result;
        }

    }
}
