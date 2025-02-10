using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Repositories
{
    public class CartRepository
    {
        private Database1Entities db = new Database1Entities();

        public List<UserCart> GetUserCarts(String userId)
        {
            return (from crt in db.UserCarts
                    where crt.UserId == userId
                    select crt).ToList();
        }


        public UserCart GetUserCart(String figurineId, String userId)
        {
            return (from crt in db.UserCarts
                    where crt.FigurineId == figurineId &&
                    crt.UserId == userId
                    select crt).FirstOrDefault();
        }

        public bool InsertItemToCart(UserCart cartItem)
        {
            UserCart oldCart = (from crt in db.UserCarts
                                where crt.FigurineId == cartItem.FigurineId &&
                                crt.UserId == cartItem.UserId
                                select crt).FirstOrDefault();
            if(oldCart == null)
            {
                db.UserCarts.Add(cartItem);
                db.SaveChanges();
                return true;
            }
            else
            {
                oldCart.Quantity += cartItem.Quantity;
                oldCart.CreatedAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateCart(String figurineId, String userId, int quantity)
        {
            UserCart oldCart = (from crt in db.UserCarts
                                where crt.FigurineId == figurineId &&
                                crt.UserId == userId
                                select crt).FirstOrDefault();
            if (oldCart == null)
            {
                return false;
            }
            else
            {
                oldCart.Quantity = quantity;
                oldCart.CreatedAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
        }

        public bool DecreaseItemCount(String figurineId, String userId)
        {
            UserCart oldCart = (from crt in db.UserCarts
                                where crt.FigurineId == figurineId &&
                                crt.UserId == userId
                                select crt).FirstOrDefault();
            if(oldCart == null)
            {
                return false;
            }
            else if(oldCart.Quantity == 1)
            {
                db.UserCarts.Remove(oldCart);
                db.SaveChanges();
                return true;
            }
            else
            {
                oldCart.Quantity -= 1;
                oldCart.CreatedAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
        }

        public bool IncreaseItemCount(String figurineId, String userId)
        {
            UserCart oldCart = (from crt in db.UserCarts
                                where crt.FigurineId == figurineId &&
                                crt.UserId == userId
                                select crt).FirstOrDefault();
            if (oldCart == null)
            {
                return false;
            }
            else
            {
                oldCart.Quantity += 1;
                oldCart.CreatedAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveItemFromCart(String figurineId, String userId)
        {
            UserCart oldCart = (from crt in db.UserCarts
                                where crt.FigurineId == figurineId &&
                                crt.UserId == userId
                                select crt).FirstOrDefault();
            if (oldCart == null)
            {
                return false;
            }
            else
            {
                db.UserCarts.Remove(oldCart);
                db.SaveChanges();
                return true;
            }
        }
    }
}