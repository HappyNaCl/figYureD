using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class TransactionFactory
    {
        public TransactionHeader ExtractTransactionHeader(String userId)
        {
            TransactionHeader header = new TransactionHeader();
            header.Id = Guid.NewGuid().ToString();
            header.UserId = userId;
            header.CreatedAt = DateTime.Now;
            header.UpdatedAt = DateTime.Now;
            return header;
        }
    }
}