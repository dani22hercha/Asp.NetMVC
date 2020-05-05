using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenModelos.Models;

namespace ExamenModelos.Controllers
{
    public class ApartamentosController : Controller
    {
        private DanielaEntitiesExam db = new DanielaEntitiesExam();

        // GET: Apartamentos
        public ActionResult Index()
        {
            var apartamentos = db.Apartamentos.Include(a => a.Unidad_recidencial);
            return View(apartamentos.ToList());
        }

        // GET: Apartamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartamentos apartamentos = db.Apartamentos.Find(id);
            if (apartamentos == null)
            {
                return HttpNotFound();
            }
            return View(apartamentos);
        }

        // GET: Apartamentos/Create
        public ActionResult Create()
        {
            ViewBag.Unidad = new SelectList(db.Unidad_recidencial, "IdUnidad", "Nombre");
            return View();
        }

        // POST: Apartamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdApartamento,NumeroApart,Piso,Bloque,Unidad,Estado")] Apartamentos apartamentos)
        {
            if (ModelState.IsValid)
            {
                db.Apartamentos.Add(apartamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Unidad = new SelectList(db.Unidad_recidencial, "IdUnidad", "Nombre", apartamentos.Unidad);
            return View(apartamentos);
        }

        // GET: Apartamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartamentos apartamentos = db.Apartamentos.Find(id);
            if (apartamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Unidad = new SelectList(db.Unidad_recidencial, "IdUnidad", "Nombre", apartamentos.Unidad);
            return View(apartamentos);
        }

        // POST: Apartamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdApartamento,NumeroApart,Piso,Bloque,Unidad,Estado")] Apartamentos apartamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Unidad = new SelectList(db.Unidad_recidencial, "IdUnidad", "Nombre", apartamentos.Unidad);
            return View(apartamentos);
        }

        // GET: Apartamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartamentos apartamentos = db.Apartamentos.Find(id);
            if (apartamentos == null)
            {
                return HttpNotFound();
            }
            return View(apartamentos);
        }

        // POST: Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartamentos apartamentos = db.Apartamentos.Find(id);
            db.Apartamentos.Remove(apartamentos);
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
