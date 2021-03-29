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
    }
}