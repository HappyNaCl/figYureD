using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        
        public Manufacturer GetManufacturer(String id)
        {
            return (from mf in db.Manufacturers where mf.Id == id select mf).FirstOrDefault();
        }

        public bool UpdateManufacturer(String id, String name)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            manufacturer.Name = name;
            manufacturer.UpdatedAt = DateTime.Now;
            return db.SaveChanges() != 0;
        }

        public bool DeleteManufacturer(String id)
        {
            db.Manufacturers.Remove(db.Manufacturers.Find(id));
            return db.SaveChanges() != 0;
        }
    }
}