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
    public class EntradasController : Controller
    {
        private MigracionEntities db = new MigracionEntities();

        // GET: Entradas
        public ActionResult Index()
        {
            var entradas = db.Entradas.Include(e => e.Viajero);
            return View(entradas.ToList());
        }

        // GET: Entradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre");
            return View();
        }

        // POST: Entradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntradaId,ViajeroId,FechaEntrada,LugarEntrada")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entradas.Add(entrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre", entrada.ViajeroId);
            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre", entrada.ViajeroId);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntradaId,ViajeroId,FechaEntrada,LugarEntrada")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ViajeroId = new SelectList(db.Viajeros, "ViajeroId", "Nombre", entrada.ViajeroId);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrada entrada = db.Entradas.Find(id);
            db.Entradas.Remove(entrada);
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
