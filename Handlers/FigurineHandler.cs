using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Handlers
{
    public class FigurineHandler
    {
        private FigurineFactory factory = new FigurineFactory();
        private FigurineRepository repo = new FigurineRepository();

        public Figurine InsertFigurine(String name, String description, String series, String character, String manufacturerId, int price, int stock)
        {
            Figurine figurine = factory.ExtractFigurine(name, description, series, character, manufacturerId, price, stock);
            repo.InsertFigurine(figurine);
            return figurine;
        }

        public Figurine GetFigurine(String id)
        {
            return repo.GetFigurine(id);
        }

        public bool DeleteFigurine(String id)
        {
            return repo.DeleteFigurine(id);
        }

        public List<Figurine> GetFigurines()
        {
            return repo.GetFigurines();
        }
    }
}