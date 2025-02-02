using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class UserFactory
    {
        public User ExtractUser(String name, String email, String password)
        {
            User user = new User();
            user.Id = System.Guid.NewGuid().ToString();
            user.Username = name;
            user.Email = email;
            user.Password = password;
            user.Role = "User";
            user.Balance = 0;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            return user;
        }
    }
}