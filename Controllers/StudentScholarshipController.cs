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

    public class StudentScholarshipController : Controller
    {
        StudentScholarshipDAO studentscholarshipDAO = new StudentScholarshipDAO();
        ScholarshipFundDAO scholarshipfundDAO = new ScholarshipFundDAO();

        [Authorize]
        // GET: PurchaseList
        public ActionResult Index()
        {
            return View(studentscholarshipDAO.GetAllRecords());
        }

        [Authorize]
        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(studentscholarshipDAO.GetRecord(id));
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

        [Authorize]
        // GET: PurchaseList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        // GET: PurchaseList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles ="Главный бухгалтер")]
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

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Authorize(Roles = "Главный бухгалтер")]
        public ActionResult AssignScholarship()
        {

            log4net.Config.XmlConfigurator.Configure();
            log.Info("Start SEFOINS;GH;GH;GHD;GEH;UW method");

            List<studentscholarship> scholarships = studentscholarshipDAO.GetAllRecords();
            List<scholarshipfund> funds = scholarshipfundDAO.GetAllRecords();

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

            log.Info("foreach");

            foreach (studentscholarship i in scholarships)
            {
                if (i.grades == 4)
                {
                    i.scholarshiptype = useable.scholarshipgreat;
                }
                else if (i.grades == 45) {
                    i.scholarshiptype = useable.scholarshipgreatperfect;
                }
                else if (i.grades == 5) {
                    i.scholarshiptype = useable.scholarshipgreatperfect;
                }
                else if (i.grades == 3) {
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
            }

            return View(scholarships);
        }
    }
}