using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Repositories
{
    public class UserRepository
    {
        private Database1Entities db = new Database1Entities();

        public void InsertUser(User user)
        {
            db.Users.Add(user);
            user.Role = "User";
            db.SaveChanges();
        }

        public User GetUser(String email, String password)
        {
            User user = (from usr in db.Users
                         where usr.Email == email && usr.Password == password
                         select usr).FirstOrDefault();
            return user;
        }

        public User GetUser(String userId)
        {
            return (from usr in db.Users
                    where usr.Id == userId
                    select usr).FirstOrDefault();
        }

        public bool IsEmailUnique(String email)
        {
            User user = (from usr in db.Users
                         where usr.Email == email
                         select usr).FirstOrDefault();
            return user == null;
        }
    }
}