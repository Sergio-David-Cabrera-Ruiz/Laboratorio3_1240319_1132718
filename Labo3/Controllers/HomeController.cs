using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Labo3.Models;

namespace Labo3.Controllers
{
    public class HomeController : Controller
    {
        public static readonly LinkedList<Medicina> ListaMedicina = new LinkedList<Medicina>();
        public static LinkedList<Medicina> listmed = new LinkedList<Medicina>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Realizamos esta versión para facilitar la implementación del AVL más tarde.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sergio Cabrera y Helen Elvira.";

            return View();
        }
        //Prueba de cambios realizados
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase ArchivoSubido)
        {
            TempData["Mensaje"] = "Archivo Leido Correctamente";
            if ((ArchivoSubido == null) || (ArchivoSubido.ContentLength == 0))
            {
                ViewBag.Error = "Error: Debe seleccionar un archivo...";
                return View("Index");
            }
            else if (ArchivoSubido.FileName.EndsWith("csv"))
            {
                string archivo = Server.MapPath("~/Archivo/" + ArchivoSubido.FileName);
                if (System.IO.File.Exists(archivo)) System.IO.File.Delete(archivo);
                ArchivoSubido.SaveAs(archivo);
                string texto = System.IO.File.ReadAllText(archivo);
                try
                {
                    foreach (string row in texto.Split('\n'))
                    {
                        int cont = 0;
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (row.Split(',')[0] != "id")
                            {
                                foreach (var letra in row)
                                {
                                    if (letra == '"') cont++;
                                }
                                if (cont == 0)
                                {

                                    ListaMedicina.AddFirst(new Medicina
                                    {
                                        Id = row.Split(',')[0],
                                        Nombre = row.Split(',')[1],
                                        Descripcion = row.Split(',')[2],
                                        CasaProductora = row.Split(',')[3],
                                        Precio = row.Split(',')[4],
                                        Existencia = Convert.ToInt32(row.Split(',')[5])
                                    });
                                }
                                if (cont == 1)
                                {
                                    string texto1 = row.Split('"')[3];
                                    string texto2 = texto1.Replace(',', ';');
                                    string Linea = row.Replace(texto1, texto2);
                                    string ID = Linea.Split(',')[0];
                                    string EXISTENCIA = Linea.Split(',')[5];
                                    ListaMedicina.AddFirst(new Medicina
                                    {
                                        Id = ID.Split('"')[0],
                                        Nombre = Linea.Split(',')[1],
                                        Descripcion = Linea.Split(',')[2],
                                        CasaProductora = Linea.Split(',')[3],
                                        Precio = Linea.Split(',')[4],
                                        Existencia = Convert.ToInt32(EXISTENCIA.Split('"')[5])
                                    });
                                }
                                if (cont == 10)
                                {
                                    string texto1 = row.Split('"')[3];
                                    string texto2 = texto1.Replace(',', ';');
                                    string Linea = row.Replace(texto1, texto2);
                                    string texto3 = row.Split('"')[7];
                                    string texto4 = texto3.Replace(',', ';');
                                    Linea = Linea.Replace(texto3, texto4);
                                    string ID = Linea.Split(',')[0];
                                    string EXISTENCIA = Linea.Split(',')[5];
                                    ListaMedicina.AddFirst(new Medicina
                                    {
                                        Id = ID.Split('"')[0],
                                        Nombre = Linea.Split(',')[1],
                                        Descripcion = Linea.Split(',')[2],
                                        CasaProductora = Linea.Split(',')[3],
                                        Precio = Linea.Split(',')[4],
                                        Existencia = Convert.ToInt32(EXISTENCIA.Split('"')[5])
                                    });
                                }
                                if (cont == 14)
                                {
                                    string texto1 = row.Split('"')[3];
                                    string texto2 = texto1.Replace(',', ';');
                                    string Linea = row.Replace(texto1, texto2);
                                    string texto3 = row.Split('"')[7];
                                    string texto4 = texto3.Replace(',', ';');
                                    Linea = Linea.Replace(texto3, texto4);
                                    string texto5 = row.Split('"')[11];
                                    string texto6 = texto3.Replace(',', ';');
                                    Linea = Linea.Replace(texto5, texto6);
                                    string ID = Linea.Split(',')[0];
                                    string EXISTENCIA = Linea.Split(',')[5];
                                    ListaMedicina.AddFirst(new Medicina
                                    {
                                        Id = ID.Split('"')[1],
                                        Nombre = Linea.Split(',')[2],
                                        Descripcion = Linea.Split(',')[3],
                                        CasaProductora = Linea.Split(',')[4],
                                        Precio = Linea.Split(',')[5],
                                        Existencia = Convert.ToInt32(EXISTENCIA.Split('"')[0])
                                    });
                                }
                            }

                        }
                    }

                    ViewBag.Error = "PRESIONE LISTADO DE MEDICINAS ";
                    return View("Index");
                }
                catch (Exception)
                {
                    ViewBag.Error = "Error: Revise que su documento CSV tenga el formato de datos correcto ";
                    return View("Index");
                }

            }
            else
            {
                ViewBag.Error = "Error: Debe seleccionar un archivo csv";
                return View("Index");
            }

            //ARBOL BINARIO 
        }
        public ActionResult ListaMedica()
        {
            return View(ListaMedicina);
        }
        public ActionResult ingresocliente()
        {

            return View();
        }

        //delegados
        delegate string BuscarMedicina(List<Medicina> lis);

        public ActionResult Carrito(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return View(ListaMedicina);
            }
            else
            {
                ViewBag.Nombre = nombre;
                var c = ListaMedicina.Where(x => x.Nombre.Contains(nombre));

                listadodecompra();
                return View(c);
            }

        }
        public ActionResult agregarmedicina()
        {

            return View();
        }

        public ActionResult listadodecompra()
        {
            Random rnd = new Random();
            int numeroConDosCotas = rnd.Next(0, 15);

            return View(ListaMedicina);
        }
        //ARCHIVO CSV
        public void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }
    }
}