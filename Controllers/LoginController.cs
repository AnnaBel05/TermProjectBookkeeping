using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TermProjectBookkeeping.DAO;
using TermProjectBookkeeping.Models;

namespace TermProjectBookkeeping.Controllers
{
    public class LoginController : Controller
    {
        UserInfoDAO userinfoDAO = new UserInfoDAO();
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(userinfo userinfoObj)
        {
            userinfoDAO.AddRecord(userinfoObj);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            List<userinfo> userlist = userinfoDAO.GetAllRecords();
            var user = userlist.Where(a => a.email == login.Email && a.password == login.Password);
            if (user != null)
            {
                var Ticket = new FormsAuthenticationTicket(login.Email, true, 3000);
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                cookie.Expires = DateTime.Now.AddHours(3000);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            return View(); ;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}