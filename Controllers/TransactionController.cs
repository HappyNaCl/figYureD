using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class TransactionController
    {
        private figYureD.Handlers.TransactionHandler handler = new figYureD.Handlers.TransactionHandler();
        public String CreateTransaction(List<UserCart> cartItems)
        {
            bool res = handler.InsertTransaction(cartItems);
            return res ? "SUCCESS" : "Insert failed!";
        }

        public List<TransactionHeader> GetTransactions(String userId)
        {
            return handler.GetTransactions(userId);
        }
        
        public List<TransactionDetail> GetDetails(String transactionId)
        {
            return handler.GetDetails(transactionId);
        }

        public List<TransactionHeader> GetAllTransactions()
        {
            return handler.GetAllTransactions();
        }
    }
}