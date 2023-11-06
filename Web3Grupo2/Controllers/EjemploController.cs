using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Web3Grupo2.Models;
using Web3Grupo2.Repositories;

namespace Web3Grupo2.Controllers
{
    public class EjemploController : Controller
    {
        private IEjemploCollection db = new EjemploCollection();
        // GET: EjemploController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EjemploController/Details/5

        public ActionResult Details(string id)
        {
            var ejemplo = db.GetEjemploById(id);
            if (ejemplo == null)
            {
                return NotFound(); // Maneja el caso en que el elemento no existe
            }

            return View(ejemplo);
        }
        public ActionResult Listado()
        {
            var ejemplos = db.GetAllEjemplos(); // Supongamos que tienes un método "GetEjemplos" en tu base de datos que obtiene todos los elementos "Ejemplo".
            return View(ejemplos);
        }

        // GET: EjemploController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EjemploController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            try
            {
                /*ObjectId nuevoObjectId = ObjectId.GenerateNewId();
                persona.Casa = new Direccion
                {
                    Id= nuevoObjectId,
                    Calle = persona.Casa.Calle,
                    Altura = persona.Casa.Altura
                };*/
                
                db.InsertEjemplo(persona);
                return RedirectToAction("Listado");
            }
            catch
            {
                return View();
            }
        }

        // GET: EjemploController/Edit/5
        public ActionResult Edit(string id)
        {
            var ejemplo = db.GetEjemploById(id);
            if (ejemplo == null)
            {
                return NotFound(); // Maneja el caso en que el elemento no existe
            }

            return View(ejemplo);
        }

        // POST: EjemploController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Persona modificado)
        {

            var ejemplo = db.GetEjemploById(id);
            
            if (ejemplo == null)
            {                
                return NotFound(); 
            }
            ejemplo.Nombre = modificado.Nombre;
            ejemplo.Apellido = modificado.Apellido;
            ejemplo.Casa = modificado.Casa;
            
            db.UpdateEjemplo(ejemplo);

            return RedirectToAction("Listado");

        }

      

        // POST: EjemploController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {

            var ejemplo = db.GetEjemploById(id);

            if (ejemplo == null)
            {
                return NotFound();
            }
            
            db.DeleteEjemplo(ejemplo);

            return RedirectToAction("Listado");


        }
    }
}
