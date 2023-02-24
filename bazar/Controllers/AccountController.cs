using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bazar.Controllers
{
    public class AccountController : Controller
    {
        bazarEntities db = new bazarEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            var check = db.tblcreateUsers.Where(x => x.username == login.username && x.password == login.password).FirstOrDefault();
                if (check!=null)
                {
                    Session["Username"] = login.username;
                    Session["userid"] = check.id;
                    Session["shoptype"]=check.shoptypeid;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(login);
                }

           
            return View(login);
        }
    }
}