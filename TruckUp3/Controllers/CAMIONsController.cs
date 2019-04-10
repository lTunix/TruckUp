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
    public class CAMIONsController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: CAMIONs
        public ActionResult Index()
        {
            var cAMION = db.CAMION.Include(c => c.CONDUCTOR);
            return View(cAMION.ToList());
        }

        // GET: CAMIONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMION cAMION = db.CAMION.Find(id);
            if (cAMION == null)
            {
                return HttpNotFound();
            }
            return View(cAMION);
        }

        // GET: CAMIONs/Create
        public ActionResult Create()
        {
            ViewBag.RUT_CONDUCTOR = new SelectList(db.CONDUCTOR, "RUT_CONDUCTOR", "NOMBRE_CONDUCTOR");
            return View();
        }

        // POST: CAMIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PATENTE,RUT_CONDUCTOR,NRO_RAMPLAS,NRO_EJES")] CAMION cAMION)
        {
            if (ModelState.IsValid)
            {
                db.CAMION.Add(cAMION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_CONDUCTOR = new SelectList(db.CONDUCTOR, "RUT_CONDUCTOR", "NOMBRE_CONDUCTOR", cAMION.RUT_CONDUCTOR);
            return View(cAMION);
        }

        // GET: CAMIONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMION cAMION = db.CAMION.Find(id);
            if (cAMION == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_CONDUCTOR = new SelectList(db.CONDUCTOR, "RUT_CONDUCTOR", "NOMBRE_CONDUCTOR", cAMION.RUT_CONDUCTOR);
            return View(cAMION);
        }

        // POST: CAMIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PATENTE,RUT_CONDUCTOR,NRO_RAMPLAS,NRO_EJES")] CAMION cAMION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUT_CONDUCTOR = new SelectList(db.CONDUCTOR, "RUT_CONDUCTOR", "NOMBRE_CONDUCTOR", cAMION.RUT_CONDUCTOR);
            return View(cAMION);
        }

        // GET: CAMIONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMION cAMION = db.CAMION.Find(id);
            if (cAMION == null)
            {
                return HttpNotFound();
            }
            return View(cAMION);
        }

        // POST: CAMIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CAMION cAMION = db.CAMION.Find(id);
            db.CAMION.Remove(cAMION);
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
