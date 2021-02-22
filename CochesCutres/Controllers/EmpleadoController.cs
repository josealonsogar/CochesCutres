using CochesCutres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CochesCutres.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            GestionEmpleado ge = new GestionEmpleado();
            return View(ge.GetAll());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            GestionEmpleado ge = new GestionEmpleado();
            Empleado e = new Empleado
            {
                nif = collection["nif"].ToString(),
                nombre = collection["nombre"].ToString(),
                apellidos = collection["apellidos"].ToString(),
                telefono = collection["telefono"].ToString(),
                direccion = collection["direccion"].ToString(),
                email = collection["email"].ToString()
            };
            ge.Alta(e);
            return RedirectToAction("Index");
        }
    }
}