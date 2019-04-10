using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruckUp3;

namespace TruckUp3.Controllers
{
    public class CARGAsController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: CARGAs
        public ActionResult Index()
        {
            var cARGA = db.CARGA.Include(c => c.CAMION);
            return View(cARGA.ToList());
        }

        // GET: CARGAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGA cARGA = db.CARGA.Find(id);
            if (cARGA == null)
            {
                return HttpNotFound();
            }
            return View(cARGA);
        }

        // GET: CARGAs/Create
        public ActionResult Create()
        {
            ViewBag.PATENTE = new SelectList(db.CAMION, "PATENTE", "RUT_CONDUCTOR");
            return View();
        }

        // POST: CARGAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CARGA,PATENTE,ORIGEN_CARGA,DESTINO_CARGA,DESCRIPCION_CARGA")] CARGA cARGA)
        {
            if (ModelState.IsValid)
            {
                db.CARGA.Add(cARGA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PATENTE = new SelectList(db.CAMION, "PATENTE", "RUT_CONDUCTOR", cARGA.PATENTE);
            return View(cARGA);
        }

        // GET: CARGAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGA cARGA = db.CARGA.Find(id);
            if (cARGA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PATENTE = new SelectList(db.CAMION, "PATENTE", "RUT_CONDUCTOR", cARGA.PATENTE);
            return View(cARGA);
        }

        // POST: CARGAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CARGA,PATENTE,ORIGEN_CARGA,DESTINO_CARGA,DESCRIPCION_CARGA")] CARGA cARGA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARGA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PATENTE = new SelectList(db.CAMION, "PATENTE", "RUT_CONDUCTOR", cARGA.PATENTE);
            return View(cARGA);
        }

        // GET: CARGAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGA cARGA = db.CARGA.Find(id);
            if (cARGA == null)
            {
                return HttpNotFound();
            }
            return View(cARGA);
        }

        // POST: CARGAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARGA cARGA = db.CARGA.Find(id);
            db.CARGA.Remove(cARGA);
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
