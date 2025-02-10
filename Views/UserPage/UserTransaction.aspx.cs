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
    public partial class UserTransaction : System.Web.UI.Page
    {
        private TransactionController controller = new TransactionController();
        private ProductService service = new ProductService();
        private figYureD.User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = (figYureD.User)Session["user"];
            if (!IsPostBack)
            {
                BindTransactions();
            }
        }

        private void BindTransactions()
        {
            List<TransactionHeader> headers = controller.GetTransactions(currentUser.Id);
            List<HeaderViewModel> headerModels = new List<HeaderViewModel>();

            foreach (TransactionHeader header in headers)
            {
                HeaderViewModel headerViewModel = new HeaderViewModel();
                headerViewModel.Id = header.Id;
                headerViewModel.CreatedAt = header.CreatedAt.ToString();
                headerViewModel.Total = 0;

                List<TransactionDetail> details = controller.GetDetails(header.Id);
                List<DetailViewModel> detailModels = new List<DetailViewModel>();

                foreach (TransactionDetail detail in details)
                {
                    DetailViewModel detailViewModel = new DetailViewModel();
                    Figurine figurine = service.GetFigurine(detail.FigurineId);
                    String imageUrl = service.GetFigurineImages(figurine.Id)[0].PictureUrl;
                    detailViewModel.Name = figurine.Name;
                    detailViewModel.ImageUrl = imageUrl;
                    detailViewModel.Quantity = detail.Quantity;
                    detailViewModel.Price = figurine.Price;

                    headerViewModel.Total += detailViewModel.Quantity * detailViewModel.Price;
                    detailModels.Add(detailViewModel);
                }

                headerViewModel.Details = detailModels;
                headerModels.Add(headerViewModel);
            }

            rptHeader.DataSource = headerModels;
            rptHeader.DataBind();
        }
        
        private class HeaderViewModel
        {
            public String Id { get; set; }
            public String CreatedAt { get; set; }
            public int Total { get; set; }
            public List<DetailViewModel> Details { get; set; }
        }

        private class DetailViewModel
        {
            public String Name { get; set; }
            public String ImageUrl { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        }
    }
}