using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class FigurineImageFactory
    {
        public FigurineImage ExtractFigurineImage(String id, String url)
        {
            FigurineImage img = new FigurineImage();
            img.Id = Guid.NewGuid().ToString();
            img.FigurineId = id;
            img.PictureUrl = url;
            img.CreatedAt = DateTime.Now;
            return img; 
        }
    }
}