using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Views.Auth
{
    public partial class Register : System.Web.UI.Page
    {
        private UserController controller = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            String name = TxtName.Text.Trim();
            String email = TxtEmail.Text.Trim();
            String password = TxtPassword.Text.Trim();
            String confirmPassword = TxtConfirmPassword.Text.Trim();
            
            String errorMsg = controller.InsertUser(name, email, password, confirmPassword);
            if (errorMsg == "SUCCESS")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                LblError.Text = errorMsg;
            }
        }
    }
}