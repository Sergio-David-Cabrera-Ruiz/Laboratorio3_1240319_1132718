using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labo3.Models
{
    public class Medicina
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CasaProductora { get; set; }
        public int Existencia { get; set; }
        public string Precio { get; set; }
    }
}