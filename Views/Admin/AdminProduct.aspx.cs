using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;

namespace figYureD.Views.Admin
{
    public partial class AdminProduct : System.Web.UI.Page
    {
        ManufacturerController manufacturerController = new ManufacturerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadManufacturers();
            }
        }


        private void LoadManufacturers()
        {
            List<Manufacturer> manufacturers = manufacturerController.GetManufacturers();
            DDLManufacturer.DataSource = manufacturers;
            DDLManufacturer.DataTextField = "Name";
            DDLManufacturer.DataValueField = "Id";
            DDLManufacturer.DataBind();
            DDLManufacturer.Items.Insert(0, new ListItem("Select Manufacturer", "0"));
        }
    }
}