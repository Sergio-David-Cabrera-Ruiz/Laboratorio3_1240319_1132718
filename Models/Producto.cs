using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab0_1240319_1132718.Models
{
    public class Producto
    {
        public enum Tipo
        {
            Cocina, Limpieza, Automovil, VidaCot
        }
        public int ProductoID { get; set; }
        public int ClienteID { get; set; }
        public Tipo? Tipo_ { get; set; }
    }
}
