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
    public class PropietariosController : Controller
    {
        private DanielaEntitiesExam db = new DanielaEntitiesExam();

        // GET: Propietarios
        public ActionResult Index()
        {
            var propietarios = db.Propietarios.Include(p => p.Apartamentos);
            return View(propietarios.ToList());
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietarios propietarios = db.Propietarios.Find(id);
            if (propietarios == null)
            {
                return HttpNotFound();
            }
            return View(propietarios);
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            ViewBag.IDAparatamento = new SelectList(db.Apartamentos, "IdApartamento", "IdApartamento");
            return View();
        }

        // POST: Propietarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPropietario,Nombre,Apellidos,Telefono,IDAparatamento")] Propietarios propietarios)
        {
            if (ModelState.IsValid)
            {
                db.Propietarios.Add(propietarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAparatamento = new SelectList(db.Apartamentos, "IdApartamento", "IdApartamento", propietarios.IDAparatamento);
            return View(propietarios);
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietarios propietarios = db.Propietarios.Find(id);
            if (propietarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAparatamento = new SelectList(db.Apartamentos, "IdApartamento", "IdApartamento", propietarios.IDAparatamento);
            return View(propietarios);
        }

        // POST: Propietarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPropietario,Nombre,Apellidos,Telefono,IDAparatamento")] Propietarios propietarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propietarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAparatamento = new SelectList(db.Apartamentos, "IdApartamento", "IdApartamento", propietarios.IDAparatamento);
            return View(propietarios);
        }

        // GET: Propietarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietarios propietarios = db.Propietarios.Find(id);
            if (propietarios == null)
            {
                return HttpNotFound();
            }
            return View(propietarios);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propietarios propietarios = db.Propietarios.Find(id);
            db.Propietarios.Remove(propietarios);
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
