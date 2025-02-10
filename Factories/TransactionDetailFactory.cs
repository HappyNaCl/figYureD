using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class TransactionDetailFactory
    {
        public TransactionDetail ExtractTransactionDetail(TransactionHeader header, UserCart cartItem)
        {
            TransactionDetail detail = new TransactionDetail();
            detail.Id = Guid.NewGuid().ToString();
            detail.TransactionId = header.Id;
            detail.FigurineId = cartItem.FigurineId;
            detail.Quantity = cartItem.Quantity;
            return detail;
        }
    }
}