using CochesCutres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CochesCutres.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            GestionCliente gc = new GestionCliente();
            return View(gc.GetAll());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            GestionCliente gc = new GestionCliente();
            Cliente c = new Cliente
            {
                nif = collection["nif"].ToString(),
                nombre = collection["nombre"].ToString(),
                apellidos = collection["apellidos"].ToString(),
                telefono = collection["telefono"].ToString(),
                direccion = collection["direccion"].ToString(),
                email = collection["email"].ToString()
            };
            gc.Alta(c);
            return RedirectToAction("Index");
        }
    }
}