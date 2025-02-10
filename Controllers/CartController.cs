using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class CartController
    {
        private CartHandler handler = new CartHandler();

        public List<UserCart> GetUserCarts(String userId)
        {
            return handler.GetUserCarts(userId);
        }
        public void AddToCart(String figurineId, String userId)
        {
            handler.InsertCart(figurineId, userId);
        }

        public void RemoveFromCart(String figurineId, String userId)
        {
            handler.DeleteCart(figurineId, userId);
        }

        public String UpdateCart(String figurineId, String userId, int quantity)
        {
            if(quantity <= 0)
            {
                RemoveFromCart(figurineId, userId);
                return "SUCCESS";
            }
            else
            {
                bool res = handler.UpdateCart(figurineId, userId, quantity);
                if (res)
                {
                    return "SUCCESS";
                }
                else
                {
                    return "Update failed!";
                }
            }
        }
    }
}