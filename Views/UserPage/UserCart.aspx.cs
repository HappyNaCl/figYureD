using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;
using figYureD.Services;

namespace figYureD.Views.UserPage
{
    public partial class UserCartPage : System.Web.UI.Page
    {
        private figYureD.User currentUser;
        private ProductService service = new ProductService();
        private CartController controller = new CartController();
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = (figYureD.User)Session["user"];
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()
        {
            List<CartViewModel> models = new List<CartViewModel>();
            List<UserCart> cart = controller.GetUserCarts(currentUser.Id);
            foreach (UserCart item in cart)
            {
                Figurine figurine = service.GetFigurine(item.FigurineId);
                CartViewModel model = new CartViewModel();
                model.Id = figurine.Id;
                model.Name = figurine.Name;
                model.Manufacturer = service.GetManufacturerByFigurineId(figurine.Id).Name;
                model.ImageUrl = service.GetFigurineImages(figurine.Id)[0].PictureUrl;
                model.Quantity = item.Quantity.ToString();
                model.Price = figurine.Price;
                models.Add(model);
            }
            GvCart.DataSource = models;
            GvCart.DataBind();
        }

        protected void TxtQuantity_Changed(object sender, EventArgs e)
        {
            TextBox txtQuantity = (TextBox)sender;
            GridViewRow row = (GridViewRow)txtQuantity.NamingContainer;
            HiddenField hfProductId = (HiddenField)row.FindControl("hfProductId");

            int rowIndex = row.RowIndex;
            int newQuantity = int.Parse(txtQuantity.Text);

            String res = controller.UpdateCart(hfProductId.Value, currentUser.Id, newQuantity);
            if (res.Equals("SUCCESS"))
            {
                BindCart();
            }
        }

        private class CartViewModel
        {
            public String Id { get; set; }
            public String Name { get; set; }
            public String Manufacturer { get; set; }
            public String ImageUrl { get; set; }
            public String Quantity { get; set; }
            public int Price { get; set; }
        }
    }
}