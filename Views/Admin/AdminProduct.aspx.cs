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
        FigurineController figurineController = new FigurineController();
        ManufacturerController manufacturerController = new ManufacturerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadManufacturers();
                LoadFigurines();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            String name = TxtProductName.Text;
            String description = TxtProductDescription.Text;
            String character = TxtProductCharacter.Text;
            String price = TxtProductPrice.Text;
            String stock = TxtProductQuantity.Text;
            String series = TxtProductSeries.Text;
            String imageUrl = TxtImageUrl.Text;
            String manufacturerId = DDLManufacturer.SelectedValue;

            String res = figurineController.InsertFigurine(name, description, series, character, manufacturerId, imageUrl, price, stock);
            if (res == "SUCCESS")
            {
                LoadFigurines();
                Response.Redirect("/admin/products");
            }
            else
            {
                LblError.Text = res;
            } 
        }
        protected void GVProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GVProducts.Rows[e.RowIndex];
            String id = row.Cells[0].Text;
            if (figurineController.DeleteFigurine(id) == "SUCCESS")
            {
                LoadFigurines();
                Response.Redirect("/admin/products");
            }
        }

        protected void GVProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GVProducts.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("/admin/products/" + id);
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

        private void LoadFigurines()
        {
            List<Figurine> figurines = figurineController.GetFigurines();
            List<FigurineViewModel> models = new List<FigurineViewModel>();
            foreach(Figurine f in figurines)
            {
                models.Add(new FigurineViewModel(f));
            }
            GVProducts.DataSource = models;
            GVProducts.DataBind();
        }

        private class FigurineViewModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Character { get; set; }
            public int Price { get; set; }
            public int Stock { get; set; }
            public string Series { get; set; }
            public string Manufacturer { get; set; }
            public string ImageUrl { get; set; }

            public FigurineViewModel(Figurine f)
            {
                Id = f.Id;
                Name = f.Name;
                Description = f.Description;
                Character = f.Character;
                Price = f.Price;
                Stock = f.Stock;
                Series = f.Series;
                Manufacturer = (new ManufacturerController()).GetManufacturer(f.ManufacturerID).Name;
                ImageUrl = (new FigurineImageController()).GetFigurineImage(f.Id).PictureUrl;
            }

        }
    }
}