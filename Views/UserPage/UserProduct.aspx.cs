using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;

namespace figYureD.Views.UserPage
{
    public partial class UserProduct : System.Web.UI.Page
    {
        private FigurineController figurineController = new FigurineController();
        private FigurineImageController figurineImageController = new FigurineImageController();
        private CartController cartController = new CartController();
        private figYureD.User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = (figYureD.User)Session["user"];
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        protected void rptProducts_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddItemToCart")
            {
                if (currentUser != null)
                {
                    cartController.AddToCart((string)e.CommandArgument, currentUser.Id);
                }
            }
        }

        private void BindRepeater()
        {
            List<ProductViewModel> products = LoadProducts();
            rptProducts.DataSource = products;
            rptProducts.DataBind();
        }

        private List<ProductViewModel> LoadProducts()
        {
            List<Figurine> figurines = figurineController.GetFigurines();
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (Figurine figurine in figurines)
            {
                ProductViewModel product = new ProductViewModel();
                product.Id = figurine.Id;
                product.Name = figurine.Name;
                product.Description = figurine.Description;
                product.Price = figurine.Price;
                product.ImageUrl = figurineImageController.GetFigurineImage(figurine.Id).PictureUrl;
                products.Add(product);
            }
            return products;
        }
        private class ProductViewModel
        {
            public String Id { get; set; }
            public String Name { get; set; }
            public String Description { get; set; }
            public int Price { get; set; }
            public String ImageUrl { get; set; }
        }
    }
}