using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class CartFactory
    {
        public UserCart ExtractCart(String figurineId, String userId)
        {
            UserCart cart = new UserCart();
            cart.FigurineId = figurineId;
            cart.UserId = userId;
            cart.CreatedAt = DateTime.Now;
            cart.Quantity = 1;
            return cart;
        }
    }
}