using bazar.DAL.Contacts;
using bazar.DAL.Data;
using bazar.DAL.Repository;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bazar.Controllers
{
    [CustomAuthenticationFilter]

    public class HomeController : Controller
    {
        bazarEntities db = new bazarEntities();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewtblsizePantMale()
        {
            return View();
        }


        public ActionResult viewtblmaleGarment()
        {
            return View();
        }

        public ActionResult viewtblsizeShirtFemale()
        {
            return View();
        }

        public ActionResult viewtblsizePantFemale()
        {
            
            return View();
        }

        public ActionResult viewtblfemaleGarment()
        {
            return View();
        }



        public ActionResult viewtblshoe()
        {
            return View();
        }

        public ActionResult viewtbluser()
        {
            return View();
        }

        public ActionResult viewtblMarket()
        {

            bazarEntities db = new bazarEntities();
            var mar = db.tblmarkets.ToList();
            



            return View(mar);
        }

        public ActionResult viewtblRole()
        {

            bazarEntities db = new bazarEntities();
            var mar = db.tblroles.ToList();




            return View(mar);
        }

        public ActionResult viewtblShoptype()
        {

            bazarEntities db = new bazarEntities();
            var mar = db.tblshoptypes.ToList();




            return View(mar);
        }

        public ActionResult viewtblgeneral()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";
            return View();
        }

        public ActionResult riderView()
        {
            return View();
        }
    }
}