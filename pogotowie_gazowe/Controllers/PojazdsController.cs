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

    public class PojazdsController : Controller
    {
        private pgEntities1 db = new pgEntities1();

        // GET: Pojazds
        public ActionResult Index()
        {
            var pojazd = db.Pojazd.Include(p => p.Pracownik);
            return View(pojazd.ToList());
        }

        // GET: Pojazds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazd pojazd = db.Pojazd.Find(id);
            if (pojazd == null)
            {
                return HttpNotFound();
            }
            return View(pojazd);
        }

        // GET: Pojazds/Create
        public ActionResult Create()
        {
            ViewBag.ID_Pracownika = new SelectList(db.Pracownik, "ID_Pracownika", "Imię");
            return View();
        }

        // POST: Pojazds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Marka,Model,Data_zakupu,Rocznik,ID_Pojazdu,ID_Pracownika")] Pojazd pojazd)
        {
            if (ModelState.IsValid)
            {
                db.Pojazd.Add(pojazd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Pracownika = new SelectList(db.Pracownik, "ID_Pracownika", "Imię", pojazd.ID_Pracownika);
            return View(pojazd);
        }

        // GET: Pojazds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazd pojazd = db.Pojazd.Find(id);
            if (pojazd == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Pracownika = new SelectList(db.Pracownik, "ID_Pracownika", "Imię", pojazd.ID_Pracownika);
            return View(pojazd);
        }

        // POST: Pojazds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Marka,Model,Data_zakupu,Rocznik,ID_Pojazdu,ID_Pracownika")] Pojazd pojazd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pojazd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Pracownika = new SelectList(db.Pracownik, "ID_Pracownika", "Imię", pojazd.ID_Pracownika);
            return View(pojazd);
        }

        // GET: Pojazds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazd pojazd = db.Pojazd.Find(id);
            if (pojazd == null)
            {
                return HttpNotFound();
            }
            return View(pojazd);
        }

        // POST: Pojazds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pojazd pojazd = db.Pojazd.Find(id);
            db.Pojazd.Remove(pojazd);
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
