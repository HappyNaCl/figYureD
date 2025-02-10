using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class UserController
    {
        private readonly UserHandler handler = new UserHandler();

        public figYureD.User GetUser(String userId)
        {
            return handler.GetUser(userId);
        }

        public string InsertUser(string name, string email, string password, string confirmPassword)
        {
            if (name.Length == 0 || email.Length == 0 || password.Length == 0 || confirmPassword.Length == 0)
            {
                return "Please fill all fields!";
            }
            if (name.Length < 8 || name.Length > 20)
            {
                return "Name must be between 8 and 20 characters!";
                
            }
            if (handler.IsEmailUnique(email) == false)
            {
                return "Email already exists!";
            }
            if (email.IndexOf('@') == -1 || !email.Contains(".com"))
            {
                return "Invalid email!";
            }
            if (password.Length < 8 || password.Length > 20)
            {
                return "Password must be between 8 and 20 characters!";
              
            }
            if (password != confirmPassword)
            {
                return "Passwords do not match!";
            }
            handler.InsertUser(name, email, password);
            return "SUCCESS";
        }
    }
}