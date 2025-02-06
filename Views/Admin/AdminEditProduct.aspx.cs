using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using figYureD.Controllers;
using figYureD.Services;

namespace figYureD.Views.Admin
{
    public partial class AdminEditProduct : System.Web.UI.Page
    {
        private FigurineController controller = new FigurineController();
        private ProductService service = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Figurine figurine = controller.GetFigurine(Page.RouteData.Values["id"] as string);
                if (figurine == null)
                {
                    Response.Redirect("/admin/products");
                    return;
                }
                else
                {
                    List<string> textBoxIds = new List<string> {};
                    Dictionary<string, string> textBoxValues = new Dictionary<string, string>();

                    TxtProductName.Text = figurine.Name;
                    TxtProductDescription.Text = figurine.Description;
                    TxtProductCharacter.Text = figurine.Character;
                    TxtProductSeries.Text = figurine.Series;
                    TxtProductPrice.Text = figurine.Price.ToString();
                    TxtProductQuantity.Text = figurine.Stock.ToString();
                    List<FigurineImage> images = service.GetFigurineImages(figurine.Id);
                    foreach (FigurineImage image in images)
                    {
                        string textBoxId = "tb" + textBoxIds.Count;
                        textBoxIds.Add(textBoxId);
                        textBoxValues[textBoxId] = image.PictureUrl;
                    }

                    ViewState["TextBoxIds"] = textBoxIds;
                    ViewState["TextBoxValues"] = textBoxValues;
                    RecreateControls();
                }
            }
            else
            {
                RecreateControls();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String name = TxtProductName.Text;
            String description = TxtProductDescription.Text;
            String character = TxtProductCharacter.Text;
            String series = TxtProductSeries.Text;
            String price = TxtProductPrice.Text;
            String quantity = TxtProductQuantity.Text;
            List<string> images = GetTextBoxValues().Values.ToList() as List<string> ?? new List<string>();
            String res = controller.UpdateFigurine(Page.RouteData.Values["id"] as string, name, description, character, series, price, quantity, images);
            if (res == "SUCCESS")
            {
                Response.Redirect("/admin/products");
            }
            else
            {
                LblError.Text = res;
            }
        }

        protected void BtnAddTB_Click(object sender, EventArgs e)
        {
            List<string> textBoxIds = ViewState["TextBoxIds"] as List<string> ?? new List<string>();
            Dictionary<string, string> textBoxValues = GetTextBoxValues();

            if (textBoxIds.Count >= 5)
            {
                LblError.Text = "You can only put 5 images!";
                return;
            }

            string newId = "tb" + textBoxIds.Count;
            textBoxIds.Add(newId);

            ViewState["TextBoxIds"] = textBoxIds;
            ViewState["TextBoxValues"] = textBoxValues;

            AddTextBox(newId, string.Empty);
        }


        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            string targetTb = btnRemove.CommandArgument;

            List<string> textBoxIds = ViewState["TextBoxIds"] as List<string> ?? new List<string>();
            Dictionary<string, string> textBoxValues = GetTextBoxValues();

            if (textBoxIds.Count > 1)
            {
                textBoxIds.Remove(targetTb);
                textBoxValues.Remove(targetTb);

                ViewState["TextBoxIds"] = textBoxIds;
                ViewState["TextBoxValues"] = textBoxValues;

                RecreateControls();
            }
            else
            {
                LblError.Text = "Provide at least one image!";
            }
        }

        protected void Tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string id = tb.ID;
            string url = tb.Text;

            Dictionary<string, string> textBoxValues = ViewState["TextBoxValues"] as Dictionary<string, string> ?? new Dictionary<string, string>();
            textBoxValues[id] = url;
            ViewState["TextBoxValues"] = textBoxValues;

            Image img = (Image)PHTextboxes.FindControl("img_" + id);
            if (img != null)
            {
                img.ImageUrl = url;
            }
        }

        private void AddTextBox(string id, string value)
        {
            Image img = new Image
            {
                ID = "img_" + id,
                CssClass = "w-[20%]"
            };
            img.Attributes["alt"] = "Image " + (PHTextboxes.Controls.Count + 1);

            TextBox tb = new TextBox
            {
                ID = id,
                CssClass = "input input-bordered bg-[var(--secondary)] flex-1 text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out",
                Text = value,
                AutoPostBack = true
            };
            tb.Attributes["placeholder"] = "Image URL " + (PHTextboxes.Controls.Count + 1);
            tb.TextChanged += Tb_TextChanged;

            Button removeBtn = new Button
            {
                Text = "X",
                ID = "btnRemove_" + id,
                CommandArgument = id,
                CssClass = "btn btn-error"
            };

            Panel panel = new Panel
            {
                CssClass = "flex flex-row items-center w-2/5 gap-1"
            };

            removeBtn.Click += BtnRemove_Click;

            panel.Controls.Add(img);
            panel.Controls.Add(tb);
            panel.Controls.Add(removeBtn);

            PHTextboxes.Controls.Add(panel);

            if (!string.IsNullOrEmpty(value))
            {
                img.ImageUrl = value;
            }
        }

        private Dictionary<string, string> GetTextBoxValues()
        {
            Dictionary<string, string> textBoxValues = new Dictionary<string, string>();

            // Iterate through the controls to get the current values of the textboxes
            foreach (Control control in PHTextboxes.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is TextBox tb)
                        {
                            textBoxValues[tb.ID] = tb.Text;
                        }
                    }
                }
            }
            return textBoxValues;
        }

        private void RecreateControls()
        {
            List<string> textBoxIds = ViewState["TextBoxIds"] as List<string> ?? new List<string>();
            Dictionary<string, string> textBoxValues = ViewState["TextBoxValues"] as Dictionary<string, string> ?? new Dictionary<string, string>();

            PHTextboxes.Controls.Clear();
            foreach (string id in textBoxIds)
            {
                string value = textBoxValues.ContainsKey(id) ? textBoxValues[id] : string.Empty;
                AddTextBox(id, value);
            }
        }
    }
}
