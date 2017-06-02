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
    public class DouglasController : Controller
    {
        private DougHomework2Context db = new DougHomework2Context();

        // GET: Douglas
        public ActionResult Index()
        {
            var douglas = db.Douglas.Include(d => d.Doug);
            return View(douglas.ToList());
        }

        // GET: Douglas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Douglas douglas = db.Douglas.Find(id);
            if (douglas == null)
            {
                return HttpNotFound();
            }
            return View(douglas);
        }

        // GET: Douglas/Create
        public ActionResult Create()
        {
            ViewBag.DougId = new SelectList(db.Dougs, "DougId", "Name");
            return View();
        }

        // POST: Douglas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DouglasId,DougLevel,DougMasteries,Name,DougId")] Douglas douglas)
        {
            if (ModelState.IsValid)
            {
                db.Douglas.Add(douglas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DougId = new SelectList(db.Dougs, "DougId", "Name", douglas.DougId);
            return View(douglas);
        }

        // GET: Douglas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Douglas douglas = db.Douglas.Find(id);
            if (douglas == null)
            {
                return HttpNotFound();
            }
            ViewBag.DougId = new SelectList(db.Dougs, "DougId", "Name", douglas.DougId);
            return View(douglas);
        }

        // POST: Douglas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DouglasId,DougLevel,DougMasteries,Name,DougId")] Douglas douglas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(douglas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DougId = new SelectList(db.Dougs, "DougId", "Name", douglas.DougId);
            return View(douglas);
        }

        // GET: Douglas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Douglas douglas = db.Douglas.Find(id);
            if (douglas == null)
            {
                return HttpNotFound();
            }
            return View(douglas);
        }

        // POST: Douglas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Douglas douglas = db.Douglas.Find(id);
            db.Douglas.Remove(douglas);
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
