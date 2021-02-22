using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class Vehiculo
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int numPuertas { get; set; }
        public string color { get; set; }
        public int kilometros { get; set; }
        public string tipoVehiculo { get; set; }
        public int garantia { get; set; }
        public bool stock { get; set; } // Si es 0, no está en stock; si es 1, sí.
        public string fotografia { get; set; }
    }
}