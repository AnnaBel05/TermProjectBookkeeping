using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        EmployeeSalaryDAO employeesalaryDAO = new EmployeeSalaryDAO();

        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(employeesalaryDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(employeesalaryDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] employeesalary employeeSalary)
        {
            try
            {
                // TODO: Add insert logic here

                if (employeesalaryDAO.AddRecord(employeeSalary))
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
        public ActionResult Edit(int id, employeesalary employeeSalary)
        {
            try
            {
                // TODO: Add update logic here

                if (employeesalaryDAO.UpdateRecord(id, employeeSalary))
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
        public ActionResult Delete(int id, employeesalary employeeSalary)
        {
            try
            {
                // TODO: Add delete logic here
                if (employeesalaryDAO.DeleteRecord(id, employeeSalary))
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