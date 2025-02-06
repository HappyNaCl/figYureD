using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;

namespace figYureD.Views.User
{
    public partial class UserProduct : System.Web.UI.Page
    {
        private FigurineController figurineController = new FigurineController();
        private FigurineImageController figurineImageController = new FigurineImageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            List<ProductViewModel> products = LoadProducts();
            RepeaterProducts.DataSource = products;
            RepeaterProducts.DataBind();
        }

        private List<ProductViewModel> LoadProducts()
        {
            List<Figurine> figurines = figurineController.GetFigurines();
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (Figurine figurine in figurines)
            {
                ProductViewModel product = new ProductViewModel();
                product.Name = figurine.Name;
                product.Description = figurine.Description;
                product.Price = figurine.Price;
                product.ImageUrl = figurineImageController.GetFigurineImage(figurine.Id).PictureUrl;
                products.Add(product);
            }
            return products;
        }
    }

    public class ProductViewModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public String ImageUrl { get; set; }
    }
}