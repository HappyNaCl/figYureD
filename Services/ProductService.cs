using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using figYureD.Controllers;
using figYureD.Handlers;

namespace figYureD.Services
{
    public class ProductService
    {
        private readonly FigurineHandler figurineHandler = new FigurineHandler();
        private readonly FigurineImageHandler figurineImageHandler = new FigurineImageHandler();
        private readonly ManufacturerHandler manufacturerHandler = new ManufacturerHandler();

        public Figurine GetFigurine(String id)
        {
            return figurineHandler.GetFigurine(id);
        }

        public List<FigurineImage> GetFigurineImages(String figurineId)
        {
            return figurineImageHandler.GetFigurineImages(figurineId);
        }

        public Manufacturer GetManufacturerByFigurineId(String figurineId)
        {
            Figurine figurine = figurineHandler.GetFigurine(figurineId);
            if(figurine == null)
            {
                Console.WriteLine("Figurine not found");
            }
            return manufacturerHandler.GetManufacturer(figurine.ManufacturerID);
        }

    }
}