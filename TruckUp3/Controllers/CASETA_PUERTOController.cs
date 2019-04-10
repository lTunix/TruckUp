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
    public class CASETA_PUERTOController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: CASETA_PUERTO
        public ActionResult Index()
        {
            var cASETA_PUERTO = db.CASETA_PUERTO.Include(c => c.REGION);
            return View(cASETA_PUERTO.ToList());
        }

        // GET: CASETA_PUERTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CASETA_PUERTO cASETA_PUERTO = db.CASETA_PUERTO.Find(id);
            if (cASETA_PUERTO == null)
            {
                return HttpNotFound();
            }
            return View(cASETA_PUERTO);
        }

        // GET: CASETA_PUERTO/Create
        public ActionResult Create()
        {
            ViewBag.ID_REGION = new SelectList(db.REGION, "ID_REGION", "NOMBRE_REGION");
            return View();
        }

        // POST: CASETA_PUERTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CASETA,ID_REGION,DIRECCION_CASETA,TELEFONO_CASETA")] CASETA_PUERTO cASETA_PUERTO)
        {
            if (ModelState.IsValid)
            {
                db.CASETA_PUERTO.Add(cASETA_PUERTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_REGION = new SelectList(db.REGION, "ID_REGION", "NOMBRE_REGION", cASETA_PUERTO.ID_REGION);
            return View(cASETA_PUERTO);
        }

        // GET: CASETA_PUERTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CASETA_PUERTO cASETA_PUERTO = db.CASETA_PUERTO.Find(id);
            if (cASETA_PUERTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_REGION = new SelectList(db.REGION, "ID_REGION", "NOMBRE_REGION", cASETA_PUERTO.ID_REGION);
            return View(cASETA_PUERTO);
        }

        // POST: CASETA_PUERTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CASETA,ID_REGION,DIRECCION_CASETA,TELEFONO_CASETA")] CASETA_PUERTO cASETA_PUERTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cASETA_PUERTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_REGION = new SelectList(db.REGION, "ID_REGION", "NOMBRE_REGION", cASETA_PUERTO.ID_REGION);
            return View(cASETA_PUERTO);
        }

        // GET: CASETA_PUERTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CASETA_PUERTO cASETA_PUERTO = db.CASETA_PUERTO.Find(id);
            if (cASETA_PUERTO == null)
            {
                return HttpNotFound();
            }
            return View(cASETA_PUERTO);
        }

        // POST: CASETA_PUERTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CASETA_PUERTO cASETA_PUERTO = db.CASETA_PUERTO.Find(id);
            db.CASETA_PUERTO.Remove(cASETA_PUERTO);
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
