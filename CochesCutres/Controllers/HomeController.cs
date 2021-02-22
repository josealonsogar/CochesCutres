using CochesCutres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CochesCutres.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GestionVehiculo gv = new GestionVehiculo();
            return View(gv.GetAll());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            GestionVehiculo gv = new GestionVehiculo();
            Vehiculo v = new Vehiculo
            {
                marca = collection["marca"].ToString(),
                modelo = collection["modelo"].ToString(),
                numPuertas = int.Parse(collection["numPuertas"].ToString()),
                color = collection["color"].ToString(),
                kilometros = int.Parse(collection["kilometros"].ToString()),
                tipoVehiculo = collection["tipoVehiculo"].ToString(),
                garantia = int.Parse(collection["garantia"].ToString()),
                stock = bool.Parse(collection["stock"].ToString()),
                fotografia = collection["fotografia"].ToString()
            };
            gv.Alta(v);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Modificacion(int id)
        {
            GestionVehiculo gv = new GestionVehiculo();
            Vehiculo v = gv.GetVehiculo(id);
            return View(v);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            GestionVehiculo gv = new GestionVehiculo();
            Vehiculo v = new Vehiculo
            {
                marca = collection["marca"].ToString(),
                modelo = collection["modelo"].ToString(),
                numPuertas = int.Parse(collection["numPuertas"].ToString()),
                color = collection["color"].ToString(),
                kilometros = int.Parse(collection["kilometros"].ToString()),
                tipoVehiculo = collection["tipoVehiculo"].ToString(),
                garantia = int.Parse(collection["garantia"].ToString()),
                stock = bool.Parse(collection["stock"].ToString()),
                fotografia = collection["fotografia"].ToString()
            };
            gv.Modificar(v);
            return RedirectToAction("Index");
        }
    }
}