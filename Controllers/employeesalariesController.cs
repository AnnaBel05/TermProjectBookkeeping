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
    public class employeesalariesController : Controller
    {
        private bookkeepingEntities2 db = new bookkeepingEntities2();

        // GET: employeesalaries
        [Authorize]
        public ActionResult Index()
        {
            return View(db.employeesalary.ToList());
        }

        // GET: employeesalaries/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeesalary employeesalary = db.employeesalary.Find(id);
            if (employeesalary == null)
            {
                return HttpNotFound();
            }
            return View(employeesalary);
        }

        // GET: employeesalaries/Create
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeesalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult Create([Bind(Include = "id,employee,overwork,sickdays,bonus,overall,hourspermonth")] employeesalary employeesalary)
        {
            if (ModelState.IsValid)
            {
                db.employeesalary.Add(employeesalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeesalary);
        }

        // GET: employeesalaries/Edit/5
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeesalary employeesalary = db.employeesalary.Find(id);
            if (employeesalary == null)
            {
                return HttpNotFound();
            }
            return View(employeesalary);
        }

        // POST: employeesalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult Edit([Bind(Include = "id,employee,overwork,sickdays,bonus,overall,hourspermonth")] employeesalary employeesalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeesalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeesalary);
        }

        // GET: employeesalaries/Delete/5
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeesalary employeesalary = db.employeesalary.Find(id);
            if (employeesalary == null)
            {
                return HttpNotFound();
            }
            return View(employeesalary);
        }

        // POST: employeesalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult DeleteConfirmed(int id)
        {
            employeesalary employeesalary = db.employeesalary.Find(id);
            db.employeesalary.Remove(employeesalary);
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

        [Authorize (Roles = "Главный бухгалтер, Суперюзер")]
        public ActionResult AssignSalary()
        {
            using (db)
            {
                List<salaryfund> funds = db.salaryfund.ToList();
                List<employeesalary> salaries = db.employeesalary.ToList();

                DateTime maxDate = funds[1].formationdate;
                salaryfund useable = new salaryfund();
                foreach (var i in funds)
                {
                    if (i.formationdate > maxDate)
                    {
                        maxDate = i.formationdate;
                        useable = i;
                    }
                }

                foreach (var i in salaries)
                {
                    i.overall = i.hourspermonth * useable.worktime;
                    if (i.overwork == true)
                    {
                        i.overall += (i.hourspermonth - 160) * useable.overwork;
                    }
                    if (i.sickdays == true)
                    {
                        i.overall += (160 - i.hourspermonth) * useable.sickdays;
                    }
                    if (i.bonus == true)
                    {
                        i.overall += 3000; //обращение к сервису сотрудников за информацией о категориях и т.п.
                    }
                    useable.totalsum -= i.overall;
                }

                foreach (var i in funds)
                {
                    if (useable == i)
                    {
                        i.totalsum = useable.totalsum;
                    }
                }

                db.SaveChanges();

                return View(db.employeesalary.ToList());
            }
        }
    }
}
