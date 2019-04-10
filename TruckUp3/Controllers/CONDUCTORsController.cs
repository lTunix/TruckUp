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
    public class CONDUCTORsController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: CONDUCTORs
        public ActionResult Index()
        {
            return View(db.CONDUCTOR.ToList());
        }

        // GET: CONDUCTORs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONDUCTOR cONDUCTOR = db.CONDUCTOR.Find(id);
            if (cONDUCTOR == null)
            {
                return HttpNotFound();
            }
            return View(cONDUCTOR);
        }

        // GET: CONDUCTORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONDUCTORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_CONDUCTOR,NOMBRE_CONDUCTOR,APELLIDOPAT_CONDUCTOR,APELLIDOMAT_CONDUCTOR,TELEFONO_CONDUCTOR")] CONDUCTOR cONDUCTOR)
        {
            if (ModelState.IsValid)
            {
                db.CONDUCTOR.Add(cONDUCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cONDUCTOR);
        }

        // GET: CONDUCTORs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONDUCTOR cONDUCTOR = db.CONDUCTOR.Find(id);
            if (cONDUCTOR == null)
            {
                return HttpNotFound();
            }
            return View(cONDUCTOR);
        }

        // POST: CONDUCTORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_CONDUCTOR,NOMBRE_CONDUCTOR,APELLIDOPAT_CONDUCTOR,APELLIDOMAT_CONDUCTOR,TELEFONO_CONDUCTOR")] CONDUCTOR cONDUCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONDUCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cONDUCTOR);
        }

        // GET: CONDUCTORs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONDUCTOR cONDUCTOR = db.CONDUCTOR.Find(id);
            if (cONDUCTOR == null)
            {
                return HttpNotFound();
            }
            return View(cONDUCTOR);
        }

        // POST: CONDUCTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CONDUCTOR cONDUCTOR = db.CONDUCTOR.Find(id);
            db.CONDUCTOR.Remove(cONDUCTOR);
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
