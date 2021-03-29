using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab0_1240319_1132718.Models;
namespace Lab0_1240319_1132718.Datos
{
    public static class BdDInicializador
    {
        public static void Initialize (ContextoNegocio contexto)
        {
            contexto.Database.EnsureCreated();

            // Look for any students.
            if (contexto.Clientes.Any())
            {
                return;   // DB has been seeded
            }

            var clientes = new Cliente[]
            {

                new Cliente{Nombre="Billy",Apellido="Ferguson",Telefono ="05768239"},
                new Cliente{Nombre="Alex",Apellido="Padilla",Telefono ="68394705"},
                new Cliente{Nombre="Juan",Apellido="Gonzales",Telefono ="75236019"},
                new Cliente{Nombre="Pedro",Apellido="Aguilar",Telefono ="71489023"},
                new Cliente{Nombre="Enrique",Apellido="Segoviano",Telefono ="58889828"},
                new Cliente{Nombre="Mike",Apellido="Hawk",Telefono ="54180276"},
            };
            foreach (Cliente s in clientes)
            {
                contexto.Clientes.Add(s);
            }
            contexto.SaveChanges();
            foreach (Cliente s in clientes)
            {
                clientes[s] =     
            }
            var productos = new Producto[]
            {
                new Producto{ProductoID=1050, ClienteID=1, Tipo_=Producto.Tipo.Automovil},
                new Producto{ProductoID=4200, ClienteID=2, Tipo_=Producto.Tipo.VidaCot},
                new Producto{ProductoID=7896, ClienteID=3, Tipo_=Producto.Tipo.Cocina},
                new Producto{ProductoID=1111, ClienteID=4, Tipo_=Producto.Tipo.Limpieza},
                new Producto{ProductoID=2345, ClienteID=6, Tipo_=Producto.Tipo.Limpieza},
                new Producto{ProductoID=2626, ClienteID=5, Tipo_=Producto.Tipo.VidaCot},
                new Producto{ProductoID=8008, ClienteID=5, Tipo_=Producto.Tipo.VidaCot},
                new Producto{ProductoID=5450, ClienteID=2, Tipo_=Producto.Tipo.Cocina},
                new Producto{ProductoID=1800, ClienteID=2, Tipo_=Producto.Tipo.VidaCot},
                new Producto{ProductoID=1993, ClienteID=3, Tipo_=Producto.Tipo.Cocina},

           };
            foreach (Producto c in productos)
            {
                contexto.Productos.Add(c);
            }
            contexto.SaveChanges();


        }
    }
}
