using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;

namespace figYureD.Views.Admin
{
    public partial class AdminManufacturer : System.Web.UI.Page
    {
        private ManufacturerController controller = new ManufacturerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Manufacturer> manufacturers = controller.GetManufacturers();
            if(manufacturers.Count != 0)
            {
                GVManufacturer.DataSource = manufacturers;
                GVManufacturer.DataBind();
            }
        }

        protected void BtnSubmit_Click(Object sender, EventArgs e)
        {
            String name = TxtName.Text;
            String res = controller.InsertManufacturer(name);
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