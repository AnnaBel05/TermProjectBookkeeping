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
    public class scholarshipfundsController : Controller
    {
        private bookkeepingEntities2 db = new bookkeepingEntities2();

        // GET: scholarshipfunds
        [Authorize]
        public ActionResult Index()
        {
            return View(db.scholarshipfund.ToList());
        }

        // GET: scholarshipfunds/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scholarshipfund scholarshipfund = db.scholarshipfund.Find(id);
            if (scholarshipfund == null)
            {
                return HttpNotFound();
            }
            return View(scholarshipfund);
        }

        // GET: scholarshipfunds/Create
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: scholarshipfunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Create([Bind(Include = "id,formationdate,scholarshipsocial,scholarshipgreat,scholarshipgreatperfect,scholarshipperfect,basescholarship,totalsum")] scholarshipfund scholarshipfund)
        {
            if (ModelState.IsValid)
            {
                db.scholarshipfund.Add(scholarshipfund);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scholarshipfund);
        }

        // GET: scholarshipfunds/Edit/5
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scholarshipfund scholarshipfund = db.scholarshipfund.Find(id);
            if (scholarshipfund == null)
            {
                return HttpNotFound();
            }
            return View(scholarshipfund);
        }

        // POST: scholarshipfunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult Edit([Bind(Include = "id,formationdate,scholarshipsocial,scholarshipgreat,scholarshipgreatperfect,scholarshipperfect,basescholarship,totalsum")] scholarshipfund scholarshipfund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scholarshipfund).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scholarshipfund);
        }

        // GET: scholarshipfunds/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scholarshipfund scholarshipfund = db.scholarshipfund.Find(id);
            if (scholarshipfund == null)
            {
                return HttpNotFound();
            }
            return View(scholarshipfund);
        }

        // POST: scholarshipfunds/Delete/5
        [Authorize(Roles = "Главный бухгалтер, Суперюзер")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scholarshipfund scholarshipfund = db.scholarshipfund.Find(id);
            db.scholarshipfund.Remove(scholarshipfund);
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
