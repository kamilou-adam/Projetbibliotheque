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
    public class LivresController : Controller
    {
        private biblioEntities db = new biblioEntities();

        // GET: Livres
        public ActionResult Index(String id_genre, String searchString)
        {
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "libelle_genre");
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Livres
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.id_Genre = new SelectList(GenreLst);

            var livres = from m in db.Livres
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                livres = livres.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(id_genre))
            {
                livres = livres.Where(x => x.Genre == movieGenre);
            }

            return View(Livres);
        }

        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            ViewBag.id_auteur = new SelectList(db.Auteurs, "id_auteur", "nom_auteur");
            ViewBag.id_courant = new SelectList(db.Courants, "id_courant", "libelle_courant");
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "libelle_genre");
            return View();
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_livre,titre,langue,nbre_page,image_livre,date_parution,id_auteur,id_genre,id_courant")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Livres.Add(livre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_auteur = new SelectList(db.Auteurs, "id_auteur", "nom_auteur", livre.id_auteur);
            ViewBag.id_courant = new SelectList(db.Courants, "id_courant", "libelle_courant", livre.id_courant);
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "libelle_genre", livre.id_genre);
            return View(livre);
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_auteur = new SelectList(db.Auteurs, "id_auteur", "nom_auteur", livre.id_auteur);
            ViewBag.id_courant = new SelectList(db.Courants, "id_courant", "libelle_courant", livre.id_courant);
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "libelle_genre", livre.id_genre);
            return View(livre);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_livre,titre,langue,nbre_page,image_livre,date_parution,id_auteur,id_genre,id_courant")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_auteur = new SelectList(db.Auteurs, "id_auteur", "nom_auteur", livre.id_auteur);
            ViewBag.id_courant = new SelectList(db.Courants, "id_courant", "libelle_courant", livre.id_courant);
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "libelle_genre", livre.id_genre);
            return View(livre);
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livre livre = db.Livres.Find(id);
            db.Livres.Remove(livre);
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
