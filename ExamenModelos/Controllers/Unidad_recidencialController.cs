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
    public class Unidad_recidencialController : Controller
    {
        private DanielaEntitiesExam db = new DanielaEntitiesExam();

        // GET: Unidad_recidencial
        public ActionResult Index()
        {
            var unidad_recidencial = db.Unidad_recidencial.Include(u => u.Ciudades);
            return View(unidad_recidencial.ToList());
        }

        // GET: Unidad_recidencial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad_recidencial unidad_recidencial = db.Unidad_recidencial.Find(id);
            if (unidad_recidencial == null)
            {
                return HttpNotFound();
            }
            return View(unidad_recidencial);
        }

        // GET: Unidad_recidencial/Create
        public ActionResult Create()
        {
            ViewBag.IDCiudad = new SelectList(db.Ciudades, "IdCiudad", "Nombre");
            return View();
        }

        // POST: Unidad_recidencial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUnidad,Nombre,Direccion,Telefono,IDCiudad,Estado")] Unidad_recidencial unidad_recidencial)
        {
            if (ModelState.IsValid)
            {
                db.Unidad_recidencial.Add(unidad_recidencial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCiudad = new SelectList(db.Ciudades, "IdCiudad", "Nombre", unidad_recidencial.IDCiudad);
            return View(unidad_recidencial);
        }

        // GET: Unidad_recidencial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad_recidencial unidad_recidencial = db.Unidad_recidencial.Find(id);
            if (unidad_recidencial == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCiudad = new SelectList(db.Ciudades, "IdCiudad", "Nombre", unidad_recidencial.IDCiudad);
            return View(unidad_recidencial);
        }

        // POST: Unidad_recidencial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUnidad,Nombre,Direccion,Telefono,IDCiudad,Estado")] Unidad_recidencial unidad_recidencial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidad_recidencial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCiudad = new SelectList(db.Ciudades, "IdCiudad", "Nombre", unidad_recidencial.IDCiudad);
            return View(unidad_recidencial);
        }

        // GET: Unidad_recidencial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad_recidencial unidad_recidencial = db.Unidad_recidencial.Find(id);
            if (unidad_recidencial == null)
            {
                return HttpNotFound();
            }
            return View(unidad_recidencial);
        }

        // POST: Unidad_recidencial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidad_recidencial unidad_recidencial = db.Unidad_recidencial.Find(id);
            db.Unidad_recidencial.Remove(unidad_recidencial);
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
