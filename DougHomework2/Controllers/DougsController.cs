using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DougHomework2.Models;

namespace DougHomework2.Controllers
{
    public class DougsController : Controller
    {
        private DougHomework2Context db = new DougHomework2Context();

        // GET: Dougs
        public ActionResult Index()
        {
            return View(db.Dougs.ToList());
        }

        // GET: Dougs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doug doug = db.Dougs.Find(id);
            if (doug == null)
            {
                return HttpNotFound();
            }
            return View(doug);
        }

        // GET: Dougs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dougs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DougId,Name")] Doug doug)
        {
            if (ModelState.IsValid)
            {
                db.Dougs.Add(doug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doug);
        }

        // GET: Dougs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doug doug = db.Dougs.Find(id);
            if (doug == null)
            {
                return HttpNotFound();
            }
            return View(doug);
        }

        // POST: Dougs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DougId,Name")] Doug doug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doug);
        }

        // GET: Dougs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doug doug = db.Dougs.Find(id);
            if (doug == null)
            {
                return HttpNotFound();
            }
            return View(doug);
        }

        // POST: Dougs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doug doug = db.Dougs.Find(id);
            db.Dougs.Remove(doug);
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
