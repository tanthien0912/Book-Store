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
            List<Transactions> list = new List<Transactions>();
            using (DbContext context = new DbContext())
            {
                _trxRepository = new TransactionsRepository(context);
                list = _trxRepository.ReadAllTransactionWhereUser(Id);
            }
            return list;
        }
        public List<Transactions> ReadAllTransaction()
        {
            List<Transactions> list = new List<Transactions>();
            using (DbContext context = new DbContext())
            {
                _trxRepository = new TransactionsRepository(context);
                list = _trxRepository.ReadAllTransaction();
            }
            return list;
        }
    }
}
