using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace figYureD.Views.Admin
{
    public partial class AdminEditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                RecreateControls(); 
            }
        }

        protected void BtnAddTB_Click(object sender, EventArgs e)
        {
            List<String> textBoxIds = ViewState["TextBoxIds"] as List<String> ?? new List<String>();
            string newId = "tb" + textBoxIds.Count;
            textBoxIds.Add(newId);
            ViewState["TextBoxIds"] = textBoxIds;

            AddTextBox(newId);
        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            string targetTb = btnRemove.CommandArgument;

            List<String> textBoxIds = ViewState["TextBoxIds"] as List<String> ?? new List<String>();
            textBoxIds.Remove(targetTb);
            ViewState["TextBoxIds"] = textBoxIds;

            RecreateControls();
        }

        private void AddTextBox(String id)
        {
            TextBox tb = new TextBox
            {
                ID = id
            };

            Button removeBtn = new Button
            {
                Text = "X",
                ID = "btnRemove_" + id,
                CommandArgument = id,
                CssClass = "btn btn-error mb-3"
            };

            removeBtn.Click += BtnRemove_Click;

            PHTextboxes.Controls.Add(tb);
            PHTextboxes.Controls.Add(removeBtn);
        }

        private void RecreateControls()
        {
            PHTextboxes.Controls.Clear();
            List<String> textBoxIds = ViewState["TextBoxIds"] as List<String> ?? new List<String>();
            foreach (String id in textBoxIds)
            {
                AddTextBox(id);
            }
        }
    } 
}