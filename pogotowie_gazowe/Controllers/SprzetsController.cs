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

    public class SprzetsController : Controller
    {
        private pgEntities1 db = new pgEntities1();

        // GET: Sprzets
        public ActionResult Index()
        {
            return View(db.Sprzet.ToList());
        }

        // GET: Sprzets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzet sprzet = db.Sprzet.Find(id);
            if (sprzet == null)
            {
                return HttpNotFound();
            }
            return View(sprzet);
        }

        // GET: Sprzets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sprzets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Sprzetu,Nazwa,Czy_uszkodzony")] Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                db.Sprzet.Add(sprzet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sprzet);
        }

        // GET: Sprzets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzet sprzet = db.Sprzet.Find(id);
            if (sprzet == null)
            {
                return HttpNotFound();
            }
            return View(sprzet);
        }

        // POST: Sprzets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Sprzetu,Nazwa,Czy_uszkodzony")] Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprzet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sprzet);
        }

        // GET: Sprzets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzet sprzet = db.Sprzet.Find(id);
            if (sprzet == null)
            {
                return HttpNotFound();
            }
            return View(sprzet);
        }

        // POST: Sprzets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sprzet sprzet = db.Sprzet.Find(id);
            db.Sprzet.Remove(sprzet);
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
