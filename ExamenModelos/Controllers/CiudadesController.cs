﻿using System;
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
    public class CiudadesController : Controller
    {
        private DanielaEntitiesExam db = new DanielaEntitiesExam();

        // GET: Ciudades
        public ActionResult Index()
        {
            var ciudades = db.Ciudades.Include(c => c.Departamentos);
            return View(ciudades.ToList());
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre");
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCiudad,Nombre,IdDepartamentos,Estado")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", ciudades.IdDepartamentos);
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", ciudades.IdDepartamentos);
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCiudad,Nombre,IdDepartamentos,Estado")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", ciudades.IdDepartamentos);
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudades ciudades = db.Ciudades.Find(id);
            db.Ciudades.Remove(ciudades);
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
