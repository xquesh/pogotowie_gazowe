using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pogotowie_gazowe;

namespace pogotowie_gazowe.Controllers
{

    public class PracowniksController : Controller
    {
        private pgEntities1 db = new pgEntities1();

        // GET: Pracowniks
        public ActionResult Index()
        {
            return View(db.Pracownik.ToList());
        }

        // GET: Pracowniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracowniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pracowniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Pracownika,Imię,Nazwisko,Funkcja,Szef")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Pracownik.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pracownik);
        }

        // GET: Pracowniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracowniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Pracownika,Imię,Nazwisko,Funkcja,Szef")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pracownik);
        }

        // GET: Pracowniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = db.Pracownik.Find(id);
            db.Pracownik.Remove(pracownik);
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

        public ActionResult Show(int? id)
        {
            Pracownik pracownik = db.Pracownik.Find(id);
            pracownik.ID_Pracownika = (int)id;
            var pojazd = from p in db.Pojazd select p;
            pojazd = pojazd.Where(p => p.Pracownik.Imię.Contains(pracownik.Imię));
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pojazd.ToList());
        }
    }
}
