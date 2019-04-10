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
    public class HOJA_DE_RUTAController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: HOJA_DE_RUTA
        public ActionResult Index()
        {
            var hOJA_DE_RUTA = db.HOJA_DE_RUTA.Include(h => h.CARGA).Include(h => h.CASETA_PUERTO).Include(h => h.CENTRAL);
            return View(hOJA_DE_RUTA.ToList());
        }

        // GET: HOJA_DE_RUTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOJA_DE_RUTA hOJA_DE_RUTA = db.HOJA_DE_RUTA.Find(id);
            if (hOJA_DE_RUTA == null)
            {
                return HttpNotFound();
            }
            return View(hOJA_DE_RUTA);
        }

        // GET: HOJA_DE_RUTA/Create
        public ActionResult Create()
        {
            ViewBag.ID_CARGA = new SelectList(db.CARGA, "ID_CARGA", "PATENTE");
            ViewBag.ID_CASETA = new SelectList(db.CASETA_PUERTO, "ID_CASETA", "DIRECCION_CASETA");
            ViewBag.ID_CENTRAL = new SelectList(db.CENTRAL, "ID_CENTRAL", "DIRECCION_CENTRAL");
            return View();
        }

        // POST: HOJA_DE_RUTA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HOJA,ID_CENTRAL,ID_CASETA,ID_CARGA,INICIO_RUTA,DESTINO_RUTA,FECHA,FECHA_HORA_LLEGADA")] HOJA_DE_RUTA hOJA_DE_RUTA)
        {
            if (ModelState.IsValid)
            {
                db.HOJA_DE_RUTA.Add(hOJA_DE_RUTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CARGA = new SelectList(db.CARGA, "ID_CARGA", "PATENTE", hOJA_DE_RUTA.ID_CARGA);
            ViewBag.ID_CASETA = new SelectList(db.CASETA_PUERTO, "ID_CASETA", "DIRECCION_CASETA", hOJA_DE_RUTA.ID_CASETA);
            ViewBag.ID_CENTRAL = new SelectList(db.CENTRAL, "ID_CENTRAL", "DIRECCION_CENTRAL", hOJA_DE_RUTA.ID_CENTRAL);
            return View(hOJA_DE_RUTA);
        }

        // GET: HOJA_DE_RUTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOJA_DE_RUTA hOJA_DE_RUTA = db.HOJA_DE_RUTA.Find(id);
            if (hOJA_DE_RUTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CARGA = new SelectList(db.CARGA, "ID_CARGA", "PATENTE", hOJA_DE_RUTA.ID_CARGA);
            ViewBag.ID_CASETA = new SelectList(db.CASETA_PUERTO, "ID_CASETA", "DIRECCION_CASETA", hOJA_DE_RUTA.ID_CASETA);
            ViewBag.ID_CENTRAL = new SelectList(db.CENTRAL, "ID_CENTRAL", "DIRECCION_CENTRAL", hOJA_DE_RUTA.ID_CENTRAL);
            return View(hOJA_DE_RUTA);
        }

        // POST: HOJA_DE_RUTA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HOJA,ID_CENTRAL,ID_CASETA,ID_CARGA,INICIO_RUTA,DESTINO_RUTA,FECHA,FECHA_HORA_LLEGADA")] HOJA_DE_RUTA hOJA_DE_RUTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOJA_DE_RUTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CARGA = new SelectList(db.CARGA, "ID_CARGA", "PATENTE", hOJA_DE_RUTA.ID_CARGA);
            ViewBag.ID_CASETA = new SelectList(db.CASETA_PUERTO, "ID_CASETA", "DIRECCION_CASETA", hOJA_DE_RUTA.ID_CASETA);
            ViewBag.ID_CENTRAL = new SelectList(db.CENTRAL, "ID_CENTRAL", "DIRECCION_CENTRAL", hOJA_DE_RUTA.ID_CENTRAL);
            return View(hOJA_DE_RUTA);
        }

        // GET: HOJA_DE_RUTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOJA_DE_RUTA hOJA_DE_RUTA = db.HOJA_DE_RUTA.Find(id);
            if (hOJA_DE_RUTA == null)
            {
                return HttpNotFound();
            }
            return View(hOJA_DE_RUTA);
        }

        // POST: HOJA_DE_RUTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOJA_DE_RUTA hOJA_DE_RUTA = db.HOJA_DE_RUTA.Find(id);
            db.HOJA_DE_RUTA.Remove(hOJA_DE_RUTA);
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
