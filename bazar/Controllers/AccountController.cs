using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace bazar.Controllers
{
    public class AccountController : Controller
    {
        bazarEntities db = new bazarEntities();
        // GET: Account
        public ActionResult Login()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";
            Session.Clear();
            // Session.RemoveAll();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            var check = db.tblcreateUsers.Where(x => x.username == login.username && x.password == login.password).FirstOrDefault();
            if (check != null)
            {
                Session["Username"] = login.username;
                Session["userid"] = check.id;
                Session["shoptype"] = check.shoptypeid;
                Session["roleid"] = check.roleid;
                Session["login"] = "login";

                HttpContext.Cache["login"] = DateTime.Now;
                FormsAuthentication.SetAuthCookie(login.username, false);

                if (check.roleid == 2)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (check.roleid == 3)
                {
                    return RedirectToAction("viewtblsizeShirtFemale", "Home");
                }

                if (check.roleid == 4)
                {
                    return RedirectToAction("viewtblshoe", "Home");
                }

                if (check.roleid == 5)
                {
                    return RedirectToAction("riderView", "Detail");
                }
                if (check.roleid == 6)
                {
                    return RedirectToAction("viewtblgeneral", "Home");
                }
                if (check.roleid == 1)
                {
                    return RedirectToAction("viewtbluser", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid User Name or Password");
                return View(login);
            }

           
            return View(login);
        }

        [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        
        public ActionResult LogOut()
        {
            Session["Username"] = null;
            Session["userid"] = null;
            Session["shoptype"] = null;
            Session["roleid"] = null;
            Session["login"] = "login";

            Response.AppendHeader("Cache-Control", "no-store");
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            //Response.Cache.SetNoStore();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            FormsAuthentication.SignOut();
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            //Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Account");
        }

        }
}