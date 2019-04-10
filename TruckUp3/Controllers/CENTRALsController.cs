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
    public class CENTRALsController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: CENTRALs
        public ActionResult Index()
        {
            var cENTRAL = db.CENTRAL.Include(c => c.COMUNA);
            return View(cENTRAL.ToList());
        }

        // GET: CENTRALs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRAL cENTRAL = db.CENTRAL.Find(id);
            if (cENTRAL == null)
            {
                return HttpNotFound();
            }
            return View(cENTRAL);
        }

        // GET: CENTRALs/Create
        public ActionResult Create()
        {
            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA");
            return View();
        }

        // POST: CENTRALs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CENTRAL,ID_COMUNA,DIRECCION_CENTRAL,TELEFONO_CENTRAL,EMAIL_CENTRAL")] CENTRAL cENTRAL)
        {
            if (ModelState.IsValid)
            {
                db.CENTRAL.Add(cENTRAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA", cENTRAL.ID_COMUNA);
            return View(cENTRAL);
        }

        // GET: CENTRALs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRAL cENTRAL = db.CENTRAL.Find(id);
            if (cENTRAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA", cENTRAL.ID_COMUNA);
            return View(cENTRAL);
        }

        // POST: CENTRALs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CENTRAL,ID_COMUNA,DIRECCION_CENTRAL,TELEFONO_CENTRAL,EMAIL_CENTRAL")] CENTRAL cENTRAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cENTRAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMUNA = new SelectList(db.COMUNA, "ID_COMUNA", "NOMBRE_COMUNA", cENTRAL.ID_COMUNA);
            return View(cENTRAL);
        }

        // GET: CENTRALs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRAL cENTRAL = db.CENTRAL.Find(id);
            if (cENTRAL == null)
            {
                return HttpNotFound();
            }
            return View(cENTRAL);
        }

        // POST: CENTRALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CENTRAL cENTRAL = db.CENTRAL.Find(id);
            db.CENTRAL.Remove(cENTRAL);
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
