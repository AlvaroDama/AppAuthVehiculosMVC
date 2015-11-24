using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppVehiculosMVC.Models;

namespace AppVehiculosMVC.Controllers
{
    public class TipoVehiculoController : Controller
    {

        VehiculosEntities db = new VehiculosEntities();

        // GET: TipoVehiculo
        public ActionResult Index()
        {
            var data = db.TipoVehiculo.ToList();
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new TipoVehiculo());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(TipoVehiculo model)
        {
            if (ModelState.IsValid)
            {
                db.TipoVehiculo.Add(model);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return RedirectToAction("Index");
            }

            return View(new TipoVehiculo());
        }
    }
}