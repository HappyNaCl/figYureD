using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using figYureD.Handlers;

namespace figYureD.Controllers
{
    public class ManufacturerController
    {
        private readonly ManufacturerHandler handler = new ManufacturerHandler();

        public String InsertManufacturer(String name)
        {
            name = name.Trim();
            
            if (name.Length < 0)
            {
                return "Please fill all fields!";
            }
            if (name.Length < 8 || name.Length > 36)
            {
                return "Name must be between 8 and 36 characters!";
            }
            handler.InsertManufacturer(name);
            return "SUCCESS";
        }

        public List<Manufacturer> GetManufacturers()
        {
            return handler.GetManufacturers();
        }
    }
}