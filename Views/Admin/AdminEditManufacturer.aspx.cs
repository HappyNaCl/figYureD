using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;

namespace figYureD.Views.Admin
{
    public partial class AdminEditManufacturer : System.Web.UI.Page
    {
        ManufacturerController controller = new ManufacturerController();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String id = Page.RouteData.Values["id"] as string;
                Manufacturer manufacterer = controller.GetManufacturer(id);
                if(manufacterer == null)
                {
                    Response.Redirect("/admin/manufacturer");
                }
                TxtName.Text = manufacterer.Name;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String id = Page.RouteData.Values["id"] as string;
            String newName = TxtName.Text;
            String res = controller.UpdateManufacturer(id, newName);
            if (res == "SUCCESS")
            {
                Response.Redirect("/admin/manufacturer");
            }
            else
            {
                LblError.Text = res;
            }
        }
    }
}