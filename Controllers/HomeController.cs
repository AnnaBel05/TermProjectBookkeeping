using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.Models;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.Controllers
{
    public class HomeController : Controller
    {

        EmployeeSalaryDAO employeeSalaryDAO = new EmployeeSalaryDAO();
        PurchaseListDAO purchaseListDAO = new PurchaseListDAO();
        SalaryFundDAO salaryFundDAO = new SalaryFundDAO();
        ScholarshipFundDAO scholarshipFundDAO = new ScholarshipFundDAO();
        StudentScholarshipDAO studentScholarshipDAO = new StudentScholarshipDAO();
        UserInfoDAO userInfoDAO = new UserInfoDAO();
        UserRoleDAO userRoleDAO = new UserRoleDAO();
        
        // GET: Home
        public ActionResult Index()
        {
            return View(purchaseListDAO.GetAllRecords());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(purchaseListDAO.GetRecord(id));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] PurchaseList purchaseList)
        {
            try
            {
                // TODO: Add insert logic here

                if (purchaseListDAO.AddRecord(purchaseList))
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

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PurchaseList purchaseList)
        {
            try
            {
                // TODO: Add update logic here

                if (purchaseListDAO.UpdateRecord(id, purchaseList))
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PurchaseList purchaseList)
        {
            try
            {
                // TODO: Add delete logic here
                if (purchaseListDAO.DeleteRecord(id, purchaseList))
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
