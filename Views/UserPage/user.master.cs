using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace figYureD.Views.UserPage
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null || Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("/login", true);
            }
            else
            {
                lblUsername.Text = ((figYureD.User)Session["user"]).Username;
            }
            
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["user_cookie"].Value = null;
            Session.Abandon();
            Response.Redirect("/login", false);
        }
    }
}