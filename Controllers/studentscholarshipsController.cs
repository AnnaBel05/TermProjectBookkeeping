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
    public class studentscholarshipsController : Controller
    {
        private bookkeepingEntities2 db = new bookkeepingEntities2();

        // GET: studentscholarships
        public ActionResult Index()
        {
            return View(db.studentscholarship.ToList());
        }

        // GET: studentscholarships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentscholarship studentscholarship = db.studentscholarship.Find(id);
            if (studentscholarship == null)
            {
                return HttpNotFound();
            }
            return View(studentscholarship);
        }

        // GET: studentscholarships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: studentscholarships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,student,grades,ifsocial,ifsocialhelp,scholarshiptype")] studentscholarship studentscholarship)
        {
            if (ModelState.IsValid)
            {
                db.studentscholarship.Add(studentscholarship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentscholarship);
        }

        // GET: studentscholarships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentscholarship studentscholarship = db.studentscholarship.Find(id);
            if (studentscholarship == null)
            {
                return HttpNotFound();
            }
            return View(studentscholarship);
        }

        // POST: studentscholarships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,student,grades,ifsocial,ifsocialhelp,scholarshiptype")] studentscholarship studentscholarship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentscholarship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentscholarship);
        }

        // GET: studentscholarships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentscholarship studentscholarship = db.studentscholarship.Find(id);
            if (studentscholarship == null)
            {
                return HttpNotFound();
            }
            return View(studentscholarship);
        }

        // POST: studentscholarships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentscholarship studentscholarship = db.studentscholarship.Find(id);
            db.studentscholarship.Remove(studentscholarship);
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

        public ActionResult AssignScholarship()
        {
            using (db)
            {
                List<studentscholarship> scholarships = db.studentscholarship.ToList();
                List<scholarshipfund> funds = db.scholarshipfund.ToList();

                DateTime maxDate = funds[1].formationdate;
                scholarshipfund useable = new scholarshipfund();
                foreach (scholarshipfund i in funds)
                {
                    if (i.formationdate > maxDate)
                    {
                        maxDate = i.formationdate;
                        useable = i;
                    }
                }

                foreach (studentscholarship i in scholarships)
                {
                    i.scholarshiptype = useable.basescholarship;

                    if (i.grades == 4)
                    {
                        i.scholarshiptype = useable.scholarshipgreat;
                    }
                    else if (i.grades == 45)
                    {
                        i.scholarshiptype = useable.scholarshipgreatperfect;
                    }
                    else if (i.grades == 5)
                    {
                        i.scholarshiptype = useable.scholarshipgreatperfect;
                    }
                    else if (i.grades == 3)
                    {
                        i.scholarshiptype = 0;
                    }

                    if (i.ifsocial == true)
                    {
                        i.scholarshiptype += useable.scholarshipsocial;
                    }

                    if (i.ifsocialhelp == true)
                    {
                        i.scholarshiptype += useable.scholarshipsocial * 3;
                    }

                    useable.totalsum -= i.scholarshiptype;
                }

                foreach (scholarshipfund i in funds)
                {
                    if (useable == i)
                    {
                        i.totalsum = useable.totalsum;
                    }
                }
                db.SaveChanges();

                return View(db.studentscholarship.ToList());
            } 
        }
    }
}
