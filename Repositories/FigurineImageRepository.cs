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

        public bool UpdateFigurineImages(List<FigurineImage> figurineImages)
        {
            String figurineId = figurineImages[0].Id;
            List<FigurineImage> oldImages = (from img in db.FigurineImages
                                          where img.FigurineId == figurineId 
                                          select img).ToList();
            foreach (FigurineImage old in oldImages)
            {
                db.FigurineImages.Remove(old);
            }

            foreach (FigurineImage img in figurineImages)
            {
                db.FigurineImages.Add(img);
            }
            return db.SaveChanges() != 0;
        }

        public FigurineImage GetFigurineImage(String figurineId)
        {
            return (from img in db.FigurineImages where img.FigurineId == figurineId select img).FirstOrDefault();
        }

        public List<FigurineImage> GetFigurineImages(String figurineId)
        {
            List<FigurineImage> images = (from img in db.FigurineImages
                                          where img.FigurineId == figurineId
                                          select img).ToList();
            return images;
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