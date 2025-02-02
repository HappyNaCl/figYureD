using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Views.Auth
{
    public partial class Register : System.Web.UI.Page
    {
        private UserFactory uf = new UserFactory();
        private UserRepository ur = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            String name = TxtName.Text.Trim();
            String email = TxtEmail.Text.Trim();
            String password = TxtPassword.Text.Trim();
            String confirmPassword = TxtConfirmPassword.Text.Trim();
            
            if (name.Length == 0 || email.Length == 0 || password.Length == 0 || confirmPassword.Length == 0)
            {
                LblError.Text = "Please fill all fields!";
                return;
            }
            if (name.Length < 8 || name.Length > 20)
            {
                LblError.Text = "Name must be between 8 and 20 characters!";
                return;
            }
            if (ur.IsEmailUnique(email) == false)
            {
                LblError.Text = "Email already exists!";
                return;
            }
            if (email.IndexOf('@') == -1 || !email.Contains(".com"))
            {
                LblError.Text = "Invalid email!";
                return;
            }
            if (password.Length < 8 || password.Length > 20)
            {
                LblError.Text = "Password must be between 8 and 20 characters!";
                return;
            }
            if (password != confirmPassword)
            {
                LblError.Text = "Passwords do not match!";
                return;
            }

            User user = uf.ExtractUser(name, email, password);
            ur.InsertUser(user);
            Response.Redirect("/Views/Auth/Login.aspx");
        }
    }
}