using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping;

namespace TermProjectBookkeeping.Controllers
{
    public class salaryfundsController : Controller
    {
        private bookkeepingEntities2 db = new bookkeepingEntities2();

        // GET: salaryfunds
        [Authorize]
        public ActionResult Index()
        {
            return View(db.salaryfund.ToList());
        }

        // GET: salaryfunds/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salaryfund salaryfund = db.salaryfund.Find(id);
            if (salaryfund == null)
            {
                return HttpNotFound();
            }
            return View(salaryfund);
        }

        // GET: salaryfunds/Create
        [Authorize (Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: salaryfunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,worktime,overwork,sickdays,totalsum,formationdate")] salaryfund salaryfund)
        {
            if (ModelState.IsValid)
            {
                db.salaryfund.Add(salaryfund);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryfund);
        }

        // GET: salaryfunds/Edit/5
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salaryfund salaryfund = db.salaryfund.Find(id);
            if (salaryfund == null)
            {
                return HttpNotFound();
            }
            return View(salaryfund);
        }

        // POST: salaryfunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Edit([Bind(Include = "id,worktime,overwork,sickdays,totalsum,formationdate")] salaryfund salaryfund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryfund).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryfund);
        }

        // GET: salaryfunds/Delete/5
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salaryfund salaryfund = db.salaryfund.Find(id);
            if (salaryfund == null)
            {
                return HttpNotFound();
            }
            return View(salaryfund);
        }

        // POST: salaryfunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult DeleteConfirmed(int id)
        {
            salaryfund salaryfund = db.salaryfund.Find(id);
            db.salaryfund.Remove(salaryfund);
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
