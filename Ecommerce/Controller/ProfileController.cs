using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controller
{
    public class ProfileController
    {
        private TransactionsRepository _trxRepository;
        public List<Transactions> ReadAllTransactionWhereUser(int Id)
        {
            // membuat objek collection
            List<Transactions> list = new List<Transactions>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _trxRepository = new TransactionsRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _trxRepository.ReadAllTransactionWhereUser(Id);
            }
            return list;
        }
        public List<Transactions> ReadAllTransaction()
        {
            // membuat objek collection
            List<Transactions> list = new List<Transactions>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _trxRepository = new TransactionsRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _trxRepository.ReadAllTransaction();
            }
            return list;
        }
    }
}
