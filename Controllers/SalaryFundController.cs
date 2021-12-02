using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.Controllers
{
    public class SalaryFundController : Controller
    {
        SalaryFundDAO salaryfundDAO = new SalaryFundDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(salaryfundDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(salaryfundDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] salaryfund salaryFund)
        {
            try
            {
                // TODO: Add insert logic here

                if (salaryfundDAO.AddRecord(salaryFund))
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
        public ActionResult Edit(int id, salaryfund salaryFund)
        {
            try
            {
                // TODO: Add update logic here

                if (salaryfundDAO.UpdateRecord(id, salaryFund))
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
        public ActionResult Delete(int id, salaryfund salaryFund)
        {
            try
            {
                // TODO: Add delete logic here
                if (salaryfundDAO.DeleteRecord(id, salaryFund))
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