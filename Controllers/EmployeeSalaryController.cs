using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.DAO;

using log4net;
using log4net.Config;

namespace TermProjectBookkeeping.Controllers
{

    public class EmployeeSalaryController : Controller
    {
        EmployeeSalaryDAO employeesalaryDAO = new EmployeeSalaryDAO();
        SalaryFundDAO salaryFundDAO = new SalaryFundDAO();

        [Authorize]
        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(employeesalaryDAO.GetAllRecords());
        }

        [Authorize]
        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(employeesalaryDAO.GetRecord(id));
        }
        [Authorize]
        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        // GET: PurchaseList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        // GET: PurchaseList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize]
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

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Authorize]
        public ActionResult AssignSalary()
        {

            log4net.Config.XmlConfigurator.Configure();
            log.Info("Start SEFOINS;GH;GH;GHD;GEH;UW method");

            List<salaryfund> funds = salaryFundDAO.GetAllRecords();
            List<employeesalary> salaries = employeesalaryDAO.GetAllRecords();

            //List<studentscholarship> scholarships = studentscholarshipDAO.GetAllRecords();
            //List<scholarshipfund> funds = scholarshipfundDAO.GetAllRecords();

            DateTime maxDate = funds[1].formationdate;
            salaryfund useable = new salaryfund();
            foreach (salaryfund i in funds)
            {
                if (i.formationdate > maxDate)
                {
                    maxDate = i.formationdate;
                    useable = i;
                }
            }

            log.Info("foreach");

            foreach (employeesalary i in salaries)
            {
                i.overall = i.hourspermonth * useable.worktime;
                if (i.overwork == true) 
                { 
                    i.overall += (i.hourspermonth - 160) * useable.overwork; 
                }
                if (i.sickdays == true )
                {
                    i.overall += (160 - i.hourspermonth) * useable.sickdays;
                }
                if (i.bonus == true)
                {
                    i.overall += 3000; //обращение к сервису сотрудников за информацией о категориях и т.п.
                }
                useable.totalsum -= i.overall;
            }

            foreach (salaryfund i in funds)
            {
                if (useable == i)
                {
                    i.totalsum = useable.totalsum;
                }
            }

            return View(salaries);
        }
    }
}