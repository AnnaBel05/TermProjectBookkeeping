using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.Controllers
{
    public class ScholarshipFundController : Controller
    {
        ScholarshipFundDAO scholarshipfundDAO = new ScholarshipFundDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(scholarshipfundDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(scholarshipfundDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] scholarshipfund scholarshipFund)
        {
            try
            {
                // TODO: Add insert logic here

                if (scholarshipfundDAO.AddRecord(scholarshipFund))
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
        public ActionResult Edit(int id, scholarshipfund scholarshipFund)
        {
            try
            {
                // TODO: Add update logic here

                if (scholarshipfundDAO.UpdateRecord(id, scholarshipFund))
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
        public ActionResult Delete(int id, scholarshipfund scholarshipFund)
        {
            try
            {
                // TODO: Add delete logic here
                if (scholarshipfundDAO.DeleteRecord(id, scholarshipFund))
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