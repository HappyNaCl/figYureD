using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Controllers;

namespace figYureD.Services
{

    public class CheckoutService
    {
        private CartController cartController = new CartController();
        private TransactionController transactionController = new TransactionController();

        public void CheckOut(List<UserCart> cart)
        {
            cartController.RemoveAllCart(cart);
            transactionController.CreateTransaction(cart);
        }
    }
}