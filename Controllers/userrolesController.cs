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
    public class userrolesController : Controller
    {
        private bookkeepingEntities2 db = new bookkeepingEntities2();

        // GET: userroles
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Index()
        {
            return View(db.userrole.ToList());
        }

        // GET: userroles/Details/5
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userrole userrole = db.userrole.Find(id);
            if (userrole == null)
            {
                return HttpNotFound();
            }
            return View(userrole);
        }

        // GET: userroles/Create
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: userroles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Create([Bind(Include = "id,rolename")] userrole userrole)
        {
            if (ModelState.IsValid)
            {
                db.userrole.Add(userrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userrole);
        }

        // GET: userroles/Edit/5
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userrole userrole = db.userrole.Find(id);
            if (userrole == null)
            {
                return HttpNotFound();
            }
            return View(userrole);
        }

        // POST: userroles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Edit([Bind(Include = "id,rolename")] userrole userrole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userrole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userrole);
        }

        // GET: userroles/Delete/5
        [Authorize(Roles = "Суперюзер")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userrole userrole = db.userrole.Find(id);
            if (userrole == null)
            {
                return HttpNotFound();
            }
            return View(userrole);
        }

        // POST: userroles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Суперюзер")]
        public ActionResult DeleteConfirmed(int id)
        {
            userrole userrole = db.userrole.Find(id);
            db.userrole.Remove(userrole);
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
