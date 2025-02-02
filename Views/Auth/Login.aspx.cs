using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Repositories;

namespace figYureD.Views.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        UserRepository ur = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            String email = TxtEmail.Text.Trim();
            String password = TxtPassword.Text.Trim();
            if (email.Length == 0 || password.Length == 0)
            {
                LblError.Text = "Please fill all fields!";
                return;
            }
           
            User user = ur.GetUser(email, password);
            if (user == null)
            {
                LblError.Text = "Invalid email or password!";
                return;
            }
            Session["user"] = user;
            Response.Redirect("~/Views/Home/Index.aspx");
        }
    }
}