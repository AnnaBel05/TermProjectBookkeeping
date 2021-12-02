using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using TermProjectBookkeeping.Models;
using TermProjectBookkeeping;
using TermProjectBookkeeping.DAO;
using TermProjectBookkeeping.ViewModel;

namespace TermProjectBookkeeping.Controllers
{
    public class HomeController : Controller
    {
        bookkeepingEntities2 bookkeepingEntities = new bookkeepingEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {

            return View();
        }

        public ActionResult PurchaseList()
        {

            return View("/PurchaseList/Index");
        }

    }
}
