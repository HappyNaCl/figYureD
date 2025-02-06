using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Repositories
{
    public class FigurineRepository
    {
        private Database1Entities db = new Database1Entities();

        public void InsertFigurine(Figurine figurine)
        {
            db.Figurines.Add(figurine);
            db.SaveChanges();
        }
        
        public bool UpdateFigurine(String id, String name, String desc, String character, String series, int price, int quantity)
        {
            Figurine figurine = db.Figurines.Find(id);
            figurine.Name = name;
            figurine.Description = desc;
            figurine.Character = character;
            figurine.Series = series;
            figurine.Price = price;
            figurine.Stock = quantity;
            return db.SaveChanges() != 0;
        }

        public Figurine GetFigurine(String id)
        {
            return db.Figurines.Find(id);
        }

        public bool DeleteFigurine(String id)
        {
            Figurine figurine = db.Figurines.Find(id);
            db.Figurines.Remove(figurine);
            return db.SaveChanges() != 0;
        }

        public List<Figurine> GetFigurines()
        {
            return db.Figurines.ToList();
        }
    }
}