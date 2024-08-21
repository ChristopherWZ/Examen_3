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
    public class PasaportesController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: Pasaportes
        public ActionResult Index()
        {
            var pasaportes = db.Pasaportes.Include(p => p.Viajero);
            return View(pasaportes.ToList());
        }

        // GET: Pasaportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasaporte pasaporte = db.Pasaportes.Find(id);
            if (pasaporte == null)
            {
                return HttpNotFound();
            }
            return View(pasaporte);
        }

        // GET: Pasaportes/Create
        public ActionResult Create()
        {
            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre");
            return View();
        }

        // POST: Pasaportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PasaporteId,NumeroPasaporte,FechaEmision,FechaExpiracion,ViajeroId")] Pasaporte pasaporte)
        {
            if (ModelState.IsValid)
            {
                db.Pasaportes.Add(pasaporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre", pasaporte.ViajeroId);
            return View(pasaporte);
        }

        // GET: Pasaportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasaporte pasaporte = db.Pasaportes.Find(id);
            if (pasaporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre", pasaporte.ViajeroId);
            return View(pasaporte);
        }

        // POST: Pasaportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PasaporteId,NumeroPasaporte,FechaEmision,FechaExpiracion,ViajeroId")] Pasaporte pasaporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasaporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre", pasaporte.ViajeroId);
            return View(pasaporte);
        }

        // GET: Pasaportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasaporte pasaporte = db.Pasaportes.Find(id);
            if (pasaporte == null)
            {
                return HttpNotFound();
            }
            return View(pasaporte);
        }

        // POST: Pasaportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pasaporte pasaporte = db.Pasaportes.Find(id);
            db.Pasaportes.Remove(pasaporte);
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
