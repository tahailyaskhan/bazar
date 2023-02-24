using bazar.DAL.Repository;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bazar.Controllers
{
    public class EditController : Controller
    {
        bazarEntities db = new bazarEntities();
        // GET: Edit
        public ActionResult edittblmaleGarment(int id)
        {
            tblmaleGarmentaction a = new tblmaleGarmentaction();
            tblmaleGarment real = new tblmaleGarment();
            var obj = a.GetById(id);
            return Json(new { ErrorCode = "000", data = obj });
            //  return View(obj);
        }
    }
}