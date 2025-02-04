using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class FigurineFactory
    {
        public Figurine ExtractFigurine(String name, String description, String series, String character, String manufacturerId, int price, int stock)
        {
            Figurine figurine = new Figurine();
            figurine.Id = Guid.NewGuid().ToString();
            figurine.Name = name;
            figurine.Description = description;
            figurine.Series = series;
            figurine.Character = character;
            figurine.ManufacturerID = manufacturerId;
            figurine.Stock = stock;
            figurine.Price = price;
            figurine.CreatedAt = DateTime.Now;
            figurine.UpdatedAt = DateTime.Now;
            return figurine;
        }
    }
}