using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class FigurineController
    {
        private FigurineHandler handler = new FigurineHandler();
        private FigurineImageHandler imageHandler = new FigurineImageHandler();

        public Figurine GetFigurine(String id)
        {
            return handler.GetFigurine(id);
        }
        public List<Figurine> GetFigurines()
        {
            return handler.GetFigurines();
        }

        public String UpdateFigurine(String id, String name, String desc, String character, String series, String strPrice, String strStock, List<String> images)
        {
            int price, stock;
            if (!int.TryParse(strPrice, out price))
            {
                return "Price must be a number";
            }
            if (!int.TryParse(strStock, out stock))
            {
                return "Stock must be a number";
            }
            if (name.Length <= 0 || desc.Length <= 0 || series.Length == 0 || character.Length == 0 || price == 0 || stock == 0)
            {
                return "Please fill all fields";
            }
            if (name.Length < 8 || name.Length > 72)
            {
                return "Name must be 8 to 72 characters long";
            }
            if (price < 0)
            {
                return "Price must not be a negative number";
            }
            if (stock < 0)
            {
                return "Stock must not be a negative number";
            }

            bool figurineRes = handler.UpdateFigurine(id, name, desc, character, series, price, stock);
            bool imageRes = imageHandler.UpdateFigurineImages(id, images);
            if (figurineRes && imageRes)
            {
                return "SUCCESS";
            }
            else if(!figurineRes)
            {
                return "Figurine update gone wrong!";
            }
            else if(!imageRes)
            {
                return "Image update gone wrong!";
            }
            else
            {
                return "Update gone wrong!";
            }
        }

        public String DeleteFigurine(String id)
        {
            if(handler.GetFigurine(id) != null)
            {
                imageHandler.DeleteAllFigurineImageById(id);
                bool res = handler.DeleteFigurine(id);
                return res ? "SUCCESS" : "Delete gone wrong!";
            }
            else
            {
                return "No Figurine found!";
            }
        }

        public String InsertFigurine(String name, String description, String series, String character, String manufacturerId, String imageUrl, String strPrice, String strStock)
        {
            int price, stock;
            if(!int.TryParse(strPrice, out price))
            {
                return "Price must be a number";
            }
            if(!int.TryParse(strStock, out stock))
            {
                return "Stock must be a number";
            }
            if (name.Length <= 0 || description.Length <= 0 || series.Length == 0 || character.Length == 0 || price == 0 || stock == 0)
            {
                return "Please fill all fields";
            }
            if(name.Length < 8 || name.Length > 72)
            {
                return "Name must be 8 to 72 characters long";
            }
            if(price < 0)
            {
                return "Price must not be a negative number";
            }
            if (stock < 0)
            {
                return "Stock must not be a negative number";
            }

            Figurine insertedFigurine = handler.InsertFigurine(name, description, series, character, manufacturerId, price, stock);
            imageHandler.InsertFigurineImage(insertedFigurine.Id, imageUrl);
            return "SUCCESS";
        }
    }
}