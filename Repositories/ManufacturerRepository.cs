using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Repositories
{
    public class ManufacturerRepository
    {
        private Database1Entities db = new Database1Entities();
        public void InsertManufacturer(Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return db.Manufacturers.ToList();
        }
    }
}