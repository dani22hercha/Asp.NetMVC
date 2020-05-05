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
    public class MercadosController : Controller
    {
        private DanielaEntitiesExam db = new DanielaEntitiesExam();

        // GET: Mercados
        public ActionResult Index()
        {
            var mercados = db.Mercados.Include(m => m.Propietarios);
            return View(mercados.ToList());
        }

        // GET: Mercados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercados mercados = db.Mercados.Find(id);
            if (mercados == null)
            {
                return HttpNotFound();
            }
            return View(mercados);
        }

        // GET: Mercados/Create
        public ActionResult Create()
        {
            ViewBag.IdPropietario = new SelectList(db.Propietarios, "IdPropietario", "Nombre");
            return View();
        }

        // POST: Mercados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMercado,FechaCracion,IdPropietario,Estado,Finalizado,Cancelado,Creado")] Mercados mercados)
        {
            if (ModelState.IsValid)
            {
                db.Mercados.Add(mercados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPropietario = new SelectList(db.Propietarios, "IdPropietario", "Nombre", mercados.IdPropietario);
            return View(mercados);
        }

        // GET: Mercados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercados mercados = db.Mercados.Find(id);
            if (mercados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPropietario = new SelectList(db.Propietarios, "IdPropietario", "Nombre", mercados.IdPropietario);
            return View(mercados);
        }

        // POST: Mercados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMercado,FechaCracion,IdPropietario,Estado,Finalizado,Cancelado,Creado")] Mercados mercados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mercados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPropietario = new SelectList(db.Propietarios, "IdPropietario", "Nombre", mercados.IdPropietario);
            return View(mercados);
        }

        // GET: Mercados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercados mercados = db.Mercados.Find(id);
            if (mercados == null)
            {
                return HttpNotFound();
            }
            return View(mercados);
        }

        // POST: Mercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mercados mercados = db.Mercados.Find(id);
            db.Mercados.Remove(mercados);
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
