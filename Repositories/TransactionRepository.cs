using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Factories;

namespace figYureD.Repositories
{
    public class TransactionRepository
    {
        private Database1Entities db = new Database1Entities();
        private TransactionFactory tFactory = new TransactionFactory();
        private TransactionDetailFactory tdFactory = new TransactionDetailFactory();
       
        public List<TransactionHeader> GetTransactions(String userId)
        {
            return (from th in db.TransactionHeaders
                    where th.UserId == userId
                    select th).ToList();
        }

        public List<TransactionDetail> GetDetails(String transactionId)
        {
            return (from td in db.TransactionDetails
                    where td.TransactionId == transactionId
                    select td).ToList();
        }

        public List<TransactionHeader> GetAllTransactions()
        {
            return db.TransactionHeaders.ToList();
        }

        public bool InsertTransaction(List<UserCart> cartItems)
        {
            String userId = cartItems.First().UserId;
            TransactionHeader currTransaction = tFactory.ExtractTransactionHeader(userId);
            List<TransactionDetail> details = new List<TransactionDetail>();

            foreach(UserCart item in cartItems)
            {
                TransactionDetail detail = tdFactory.ExtractTransactionDetail(currTransaction, item);
                details.Add(detail);
            }

            db.TransactionHeaders.Add(currTransaction);
            
            foreach(TransactionDetail detail in details)
            {
                db.TransactionDetails.Add(detail);
            }

            db.SaveChanges();
            return true;
        }
    }
}