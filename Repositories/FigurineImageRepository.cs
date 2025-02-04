using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Repositories
{
    public class FigurineImageRepository
    {
        private Database1Entities db = new Database1Entities();
        public void InsertFigurineImage(FigurineImage figurineImage)
        {
            db.FigurineImages.Add(figurineImage);
            db.SaveChanges();
        }   

        public String GetFigurineImage(String figurineId)
        {
            String imageUrl = (from img in db.FigurineImages
                               where img.FigurineId == figurineId
                               select img.PictureUrl).FirstOrDefault();
            return imageUrl;
        }

        public void DeleteAllFigurineImageById(String figurineId)
        {
            List<FigurineImage> images = (from img in db.FigurineImages
             where img.FigurineId == figurineId
             select img).ToList();
            foreach(FigurineImage img in images)
            {
                db.FigurineImages.Remove(img);
            }
            db.SaveChanges();
        }
    }
}