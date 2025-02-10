using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Repositories;

namespace figYureD.Handlers
{
    public class TransactionHandler
    {
        private TransactionRepository repo = new TransactionRepository();
        public bool InsertTransaction(List<UserCart> userCarts)
        {
            repo.InsertTransaction(userCarts);
            return true;
        }

        public List<TransactionHeader> GetTransactions(String userId)
        {
            return repo.GetTransactions(userId);
        }

        public List<TransactionDetail> GetDetails(String transactionId)
        {
            return repo.GetDetails(transactionId);
        }

        public List<TransactionHeader> GetAllTransactions()
        {
            return repo.GetAllTransactions();
        }
    }
}