using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class AuthController
    {
        private readonly UserHandler handler = new UserHandler();

        public String Login(string email, string password, bool rememberMe)
        {
            if (email.Length == 0 || password.Length == 0)
            {
                return "Please fill all the fields!";
            }

            User user = handler.GetUser(email, password);
            if (user != null)
            {
                HttpContext.Current.Session["user"] = user;
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Values.Add("id", user.Id);
                cookie.Values.Add("username", user.Username);
                cookie.Values.Add("role", user.Role);
                cookie.Expires = DateTime.Now.AddDays(1);
                if (rememberMe)
                {
                    cookie.Expires = DateTime.Now.AddDays(3);
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
                return "SUCCESS";
            }
            else return "Invalid Credentials!";

        }
    }
}