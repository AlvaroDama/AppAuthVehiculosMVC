using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppVehiculosMVC.Models;

namespace AppVehiculosMVC.Controllers
{
    public class VehiculoController : Controller
    {

        VehiculosEntities db = new VehiculosEntities();

        // GET: Vehiculo
        public ActionResult Index(int id)
        {
            ViewBag.idTipo = id;
            ViewData["Title"] = db.TipoVehiculo.Find(id).Nombre;

            var data = db.Vehiculo.Where(o => o.Id.Equals(id));

            return View(data);
        }

        public ActionResult Buscar(int idTipo, int campo, string contenido)
        {
            //como es IQueryable permite enlazar los where en distintas lineas de código
            var data = db.Vehiculo.Where(o => o.Id.Equals(idTipo));

            if (campo == 1)
            {
                data = data.Where(o => o.Matricula.Contains(contenido));
            }
            else
            {
                data = data.Where(o => o.Marca.Contains(contenido));
            }

            return PartialView("_listado", data.ToList());
        }
        
        [HttpPost]
        public ActionResult Alta(Vehiculo model)
        {
            
            db.Vehiculo.Add(model);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
               
            //siempre que se vayan a enviar datos en JSon, MVC no deja enviarlos por GET por defecto.
            //se aconseja enviarlos por Post.
            return Json(model);
            
           
        }
    }
}