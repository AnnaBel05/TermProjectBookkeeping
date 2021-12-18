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
    public class userinfoesController : Controller
    {
        private bookkeepingEntities2 db = new bookkeepingEntities2();

        // GET: userinfoes
        public ActionResult Index()
        {
            var userinfo = db.userinfo.Include(u => u.userrole);
            return View(userinfo.ToList());
        }

        // GET: userinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userinfo userinfo = db.userinfo.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // GET: userinfoes/Create
        public ActionResult Create()
        {
            ViewBag.userroleid = new SelectList(db.userrole, "id", "rolename");
            return View();
        }

        // POST: userinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,lastname,username,patronymic,userroleid,email,password")] userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.userinfo.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userroleid = new SelectList(db.userrole, "id", "rolename", userinfo.userroleid);
            return View(userinfo);
        }

        // GET: userinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userinfo userinfo = db.userinfo.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.userroleid = new SelectList(db.userrole, "id", "rolename", userinfo.userroleid);
            return View(userinfo);
        }

        // POST: userinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,lastname,username,patronymic,userroleid,email,password")] userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userroleid = new SelectList(db.userrole, "id", "rolename", userinfo.userroleid);
            return View(userinfo);
        }

        // GET: userinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userinfo userinfo = db.userinfo.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: userinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userinfo userinfo = db.userinfo.Find(id);
            db.userinfo.Remove(userinfo);
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
