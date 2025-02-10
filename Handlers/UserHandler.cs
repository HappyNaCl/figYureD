using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Handlers
{
    public class UserHandler
    {
        private UserRepository repo = new UserRepository();
        private UserFactory factory = new UserFactory();
        public void InsertUser(String name, String email, String password)
        {
            User user = factory.ExtractUser(name, email, password);
            repo.InsertUser(user);
        }

        public figYureD.User GetUser(String userId)
        {
            return repo.GetUser(userId);
        }

        public User GetUser(String email, String password)
        {
           return repo.GetUser(email, password);
        }

        public bool IsEmailUnique(String email)
        {
            return repo.IsEmailUnique(email);
        }
    }
}