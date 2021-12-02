using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.Controllers
{
    public class StudentScholarshipController : Controller
    {
        StudentScholarshipDAO studentscholarshipDAO = new StudentScholarshipDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(studentscholarshipDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(studentscholarshipDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] studentscholarship studentScholarship)
        {
            try
            {
                // TODO: Add insert logic here

                if (studentscholarshipDAO.AddRecord(studentScholarship))
                { return RedirectToAction("Index"); }
                else
                {
                    return View("Create");
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, studentscholarship studentScholarship)
        {
            try
            {
                // TODO: Add update logic here

                if (studentscholarshipDAO.UpdateRecord(id, studentScholarship))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, studentscholarship studentScholarship)
        {
            try
            {
                // TODO: Add delete logic here
                if (studentscholarshipDAO.DeleteRecord(id, studentScholarship))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}