using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace figYureD.Factories
{
    public class ManufacturerFactory
    {
        public Manufacturer ExtractManufacturer(String name)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Id = System.Guid.NewGuid().ToString();
            manufacturer.Name = name;
            manufacturer.CreatedAt = DateTime.Now;
            manufacturer.UpdatedAt = DateTime.Now;
            return manufacturer;
        }
    }
}