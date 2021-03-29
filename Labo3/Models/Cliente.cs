using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labo3.Models
{
    public class Cliente
    {
        public static implicit operator string (Cliente v)
        {
            throw new NotImplementedException();
        }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
    }
}