using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class CompraVenta
    {
        public DateTime fecha { get; set; }
        public bool tipo { get; set; } // Si es 0, es compra; si es 1, es venta
        public string empleado { get; set; } // NIF del empleado
        public string cliente { get; set; } // NIF del cliente
        public float precio { get; set; }
    }
}