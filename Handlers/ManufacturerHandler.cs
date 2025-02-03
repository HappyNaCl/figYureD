using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Factories;
using figYureD.Repositories;

namespace figYureD.Handlers
{
    public class ManufacturerHandler
    {
        private ManufacturerFactory factory = new ManufacturerFactory();
        private ManufacturerRepository repo = new ManufacturerRepository();

        public void InsertManufacturer(String name)
        {
            Manufacturer manufacturer = factory.ExtractManufacturer(name);
            repo.InsertManufacturer(manufacturer);
        }

        public List<Manufacturer> GetManufacturers()
        {
            return repo.GetManufacturers();
        }

        public Manufacturer GetManufacturer(String id)
        {
            return repo.GetManufacturer(id);
        }

        public bool UpdateManufacturer(String id, String name)
        {
            return repo.UpdateManufacturer(id, name);
        }

        public bool DeleteManufacturer(String id)
        {
            return repo.DeleteManufacturer(id);
        }
    }
}