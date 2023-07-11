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

    public class AwariasController : Controller
    {
        private pgEntities1 db = new pgEntities1();

        // GET: Awarias
        public ActionResult Index()
        {
            var awaria = db.Awaria.Include(a => a.Pojazd).Include(a => a.Sprzet);
            return View(awaria.ToList());
        }

        // GET: Awarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awaria awaria = db.Awaria.Find(id);
            if (awaria == null)
            {
                return HttpNotFound();
            }
            return View(awaria);
        }

        // GET: Awarias/Create
        public ActionResult Create()
        {
            ViewBag.ID_Pojazdu = new SelectList(db.Pojazd, "ID_Pojazdu", "Marka");
            ViewBag.ID_Sprzetu = new SelectList(db.Sprzet, "ID_Sprzetu", "Nazwa");
            return View();
        }

        // POST: Awarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Powód,Data,Miejsce,ID_Awarii,ID_Pojazdu,ID_Sprzetu")] Awaria awaria)
        {
            if (ModelState.IsValid)
            {
                db.Awaria.Add(awaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Pojazdu = new SelectList(db.Pojazd, "ID_Pojazdu", "Marka", awaria.ID_Pojazdu);
            ViewBag.ID_Sprzetu = new SelectList(db.Sprzet, "ID_Sprzetu", "Nazwa", awaria.ID_Sprzetu);
            return View(awaria);
        }

        // GET: Awarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awaria awaria = db.Awaria.Find(id);
            if (awaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Pojazdu = new SelectList(db.Pojazd, "ID_Pojazdu", "Marka", awaria.ID_Pojazdu);
            ViewBag.ID_Sprzetu = new SelectList(db.Sprzet, "ID_Sprzetu", "Nazwa", awaria.ID_Sprzetu);
            return View(awaria);
        }

        // POST: Awarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Powód,Data,Miejsce,ID_Awarii,ID_Pojazdu,ID_Sprzetu")] Awaria awaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(awaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Pojazdu = new SelectList(db.Pojazd, "ID_Pojazdu", "Marka", awaria.ID_Pojazdu);
            ViewBag.ID_Sprzetu = new SelectList(db.Sprzet, "ID_Sprzetu", "Nazwa", awaria.ID_Sprzetu);
            return View(awaria);
        }

        // GET: Awarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awaria awaria = db.Awaria.Find(id);
            if (awaria == null)
            {
                return HttpNotFound();
            }
            return View(awaria);
        }

        // POST: Awarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Awaria awaria = db.Awaria.Find(id);
            db.Awaria.Remove(awaria);
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
