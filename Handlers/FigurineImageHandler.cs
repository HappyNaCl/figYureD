using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Handlers
{
    public class FigurineImageHandler
    {
        private FigurineImageRepository repo = new FigurineImageRepository();
        private FigurineImageFactory factory = new FigurineImageFactory();

        public void InsertFigurineImage(String figurineId, String imageUrl)
        {
            FigurineImage figurineImage = factory.ExtractFigurineImage(figurineId, imageUrl);
            repo.InsertFigurineImage(figurineImage);
        }

        public bool UpdateFigurineImages(String figurineId, List<String> imageUrls)
        {
            List<FigurineImage> figurineImages = new List<FigurineImage>();
            foreach (String imageUrl in imageUrls)
            {
                FigurineImage figurineImage = factory.ExtractFigurineImage(figurineId, imageUrl);
                figurineImages.Add(figurineImage);
            }
            return repo.UpdateFigurineImages(figurineImages);
        }

        public void DeleteAllFigurineImageById(String figurineId)
        {
            repo.DeleteAllFigurineImageById(figurineId);
        }

        public FigurineImage GetFigurineImage(String figurineId)
        {
            return repo.GetFigurineImage(figurineId);
        }

        public List<FigurineImage> GetFigurineImages(String figurineId)
        {
            return repo.GetFigurineImages(figurineId);
        }
    }
}