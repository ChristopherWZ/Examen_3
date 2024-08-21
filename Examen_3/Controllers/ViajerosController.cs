using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen_3;

namespace Examen_3.Views
{
    public class ViajerosController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: Viajeros
        public ActionResult Index()
        {
            return View(db.Viajeros.ToList());
        }

        // GET: Viajeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajero viajero = db.Viajeros.Find(id);
            if (viajero == null)
            {
                return HttpNotFound();
            }
            return View(viajero);
        }

        // GET: Viajeros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viajeros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ViajeroId,Nombre,Apellido,FechaNacimiento,Nacionalidad")] Viajero viajero)
        {
            if (ModelState.IsValid)
            {
                db.Viajeros.Add(viajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viajero);
        }

        // GET: Viajeros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajero viajero = db.Viajeros.Find(id);
            if (viajero == null)
            {
                return HttpNotFound();
            }
            return View(viajero);
        }

        // POST: Viajeros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ViajeroId,Nombre,Apellido,FechaNacimiento,Nacionalidad")] Viajero viajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viajero);
        }

        // GET: Viajeros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajero viajero = db.Viajeros.Find(id);
            if (viajero == null)
            {
                return HttpNotFound();
            }
            return View(viajero);
        }

        // POST: Viajeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viajero viajero = db.Viajeros.Find(id);
            db.Viajeros.Remove(viajero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
