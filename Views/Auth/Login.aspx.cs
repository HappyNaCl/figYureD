using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;
using figYureD.Repositories;

namespace figYureD.Views.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        AuthController controller = new AuthController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            String email = TxtEmail.Text.Trim();
            String password = TxtPassword.Text.Trim();
            bool rememberMe = CbRememberMe.Checked;
            String res = controller.Login(email, password, rememberMe);
            if(res.Equals("SUCCESS"))
            {
                if (Request.Cookies["user_cookie"]["role"].Equals("admin"))
                {
                    Response.Redirect("~/Views/Admin/Home.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/User/Home.aspx");
                }
            }
            else
            {
                LblError.Text = res;
            }
        }
    }
}