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

        public void DeleteAllFigurineImageById(String figurineId)
        {
            repo.DeleteAllFigurineImageById(figurineId);
        }

        public String GetFigurineImage(String figurineId)
        {
            return repo.GetFigurineImage(figurineId);
        }
    }
}