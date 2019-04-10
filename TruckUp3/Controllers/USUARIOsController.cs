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
    public class USUARIOsController : Controller
    {
        private TruckUp3Entities db = new TruckUp3Entities();

        // GET: USUARIOs
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.ROL);
            return View(uSUARIO.ToList());
        }

        // GET: USUARIOs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "TIPO_ROL");
            return View();
        }

        // POST: USUARIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_USUARIO,ID_ROL,NOMBRE_USUARIO,APELLIDOPAT_USUARIO,APELLIDOMAT_USUARIO,TELEFONO_USUARIO,CORREO_USUARIO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "TIPO_ROL", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "TIPO_ROL", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_USUARIO,ID_ROL,NOMBRE_USUARIO,APELLIDOPAT_USUARIO,APELLIDOMAT_USUARIO,TELEFONO_USUARIO,CORREO_USUARIO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "TIPO_ROL", uSUARIO.ID_ROL);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
