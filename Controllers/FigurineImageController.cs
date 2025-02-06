using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class FigurineImageController
    {
        private FigurineImageHandler handler = new FigurineImageHandler();
        public FigurineImage GetFigurineImage(String figurineId)
        {
            return handler.GetFigurineImage(figurineId);
        }

        public void DeleteAllFigurineImagesById(String figurineId)
        {
            handler.DeleteAllFigurineImageById(figurineId);
        }
    }
}