using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class CourantsController : Controller
    {
        private biblioEntities db = new biblioEntities();

        // GET: Courants
        public ActionResult Index()
        {
            return View(db.Courants.ToList());
        }

        // GET: Courants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courant courant = db.Courants.Find(id);
            if (courant == null)
            {
                return HttpNotFound();
            }
            return View(courant);
        }

        // GET: Courants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courants/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_courant,libelle_courant")] Courant courant)
        {
            if (ModelState.IsValid)
            {
                db.Courants.Add(courant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courant);
        }

        // GET: Courants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courant courant = db.Courants.Find(id);
            if (courant == null)
            {
                return HttpNotFound();
            }
            return View(courant);
        }

        // POST: Courants/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_courant,libelle_courant")] Courant courant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courant);
        }

        // GET: Courants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courant courant = db.Courants.Find(id);
            if (courant == null)
            {
                return HttpNotFound();
            }
            return View(courant);
        }

        // POST: Courants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courant courant = db.Courants.Find(id);
            db.Courants.Remove(courant);
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
