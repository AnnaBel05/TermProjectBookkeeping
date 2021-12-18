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
        private bookkeepingEntities2 db = new bookkeepingEntities2();
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(userinfo userinfoObj)
        {
            using (db)
            {
                db.userinfo.Add(userinfoObj);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();

            /*if (userinfoDAO.AddRecord(userinfoObj))
            { return RedirectToAction("Index", "Home"); }
            else
            {
                return RedirectToAction("Error", "Shared");
            }*/
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (db)
            {
                var user = db.userinfo.Where(a => a.email == login.Email && a.password == login.Password).FirstOrDefault();
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
                else
                {
                    return View();
                }
            }


            /*List<userinfo> userlist = userinfoDAO.GetAllRecords();
            //List<userinfo> checkinfo = new List<userinfo>();
            bool checkinfo = false;
            foreach (userinfo check in userlist)
            {
                if ((check.email == login.Email) && (check.password == login.Password))
                {
                    checkinfo = true;
                }
                else checkinfo = false;
            }
            
            //var user = userlist.Where(a => a.email == login.Email && a.password == login.Password);
            if (checkinfo == true)
            {
                /*var Ticket = new FormsAuthenticationTicket(login.Email, true, 3000);
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                cookie.Expires = DateTime.Now.AddHours(3000);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);*/

                /*FormsAuthentication.SetAuthCookie(login.Email, true);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }*/
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}