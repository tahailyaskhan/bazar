﻿using bazar.DAL.Contacts;
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
    }
}