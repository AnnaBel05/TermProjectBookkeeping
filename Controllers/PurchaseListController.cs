using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.Controllers
{
    public class PurchaseListController : Controller
    {
        PurchaseListDAO purchaseListDAO = new PurchaseListDAO();

        // GET: PurchaseList
        [Authorize]
        public ActionResult Index()
        {
            return View(purchaseListDAO.GetAllRecords());
        }

        // GET: PurchaseList/Details/5
        public ActionResult Details(int id)
        {
            return View(purchaseListDAO.GetRecord(id));
        }

        // GET: PurchaseList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseList/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] purchaselist purchaseList)
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

        // GET: PurchaseList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, purchaselist purchaseList)
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

        // GET: PurchaseList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, purchaselist purchaseList)
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