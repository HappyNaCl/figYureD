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
            if (!IsPostBack)
            {
                UpdateManufacturerList();
            }
        }

        protected void BtnSubmit_Click(Object sender, EventArgs e)
        {
            String name = TxtName.Text;
            String res = controller.InsertManufacturer(name);
            if (res == "SUCCESS")
            {
                Response.Redirect("/admin/manufacturers");
                UpdateManufacturerList();
            }
            else
            {
                LblError.Text = res;
            }
        }

        protected void GVManufacturer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GVManufacturer.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("/admin/manufacturer/" + id);
        }

        protected void GVManufacturer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GVManufacturer.Rows[e.RowIndex];
            String id = row.Cells[0].Text;
            if (controller.DeleteManufacturer(id) == "SUCCESS")
            {
                Response.Redirect("/admin/manufacturer");
                UpdateManufacturerList();
            }
        }


        private void UpdateManufacturerList()
        {
            List<Manufacturer> manufacturers = controller.GetManufacturers();
            if (manufacturers.Count != 0)
            {
                GVManufacturer.DataSource = manufacturers;
                GVManufacturer.DataBind();
            }
        }
    }
}