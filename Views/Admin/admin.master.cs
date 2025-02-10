using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace figYureD.Views.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("/login");
            }
            else if (!(Session["user"] as figYureD.User).Role.Equals("Admin"))
            {
                Response.Redirect("/products");
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Request.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            Session.Remove("user");
            Response.Redirect("/login");
        }
    }
}