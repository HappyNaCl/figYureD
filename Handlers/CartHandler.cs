using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Handlers
{
    public class CartHandler
    {
        private CartFactory factory = new CartFactory();
        private CartRepository repo = new CartRepository();

        public bool InsertCart(String figurineId, String userId)
        {
            UserCart cart = factory.ExtractCart(figurineId, userId);
            repo.InsertItemToCart(cart);
            return true;
        }

        public List<UserCart> GetUserCarts(String userId)
        {
            return repo.GetUserCarts(userId);
        }

        public UserCart GetUserCart(String figurineId, String userId)
        {
            return repo.GetUserCart(figurineId, userId);
        }

        public bool DeleteCart(String figurineId, String userId)
        {
            return repo.RemoveItemFromCart(figurineId, userId);
        }

        public bool UpdateCart(String figurineId, String userId, int quantity)
        {
            return repo.UpdateCart(figurineId, userId, quantity);
        }
    }
}