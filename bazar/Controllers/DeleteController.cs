using bazar.DAL.Repository;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bazar.Controllers
{
    public class DeleteController : Controller
    {
        bazarEntities db = new bazarEntities();
        // GET: Delete
        public ActionResult deletetblsizeShirtMale(string chartname)
        {
            var todo = db.tblsizeShirtMales.Where(x => x.chartName == chartname).ToList();
            foreach (var row in todo)
            {
                db.tblsizeShirtMales.Remove(row);
                db.SaveChanges();
            }
            
           
            return RedirectToAction("gettblsizeShirtNale","Detail");
        }
        public ActionResult deletetblsizePantMale(string chartname)
        {
            var todo = db.tblsizePantMales.Where(x => x.chartName == chartname).ToList();
            foreach (var row in todo)
            {
                db.tblsizePantMales.Remove(row);
                db.SaveChanges();
            }


            return RedirectToAction("gettblsizePantMale", "Detail");
        }
        public ActionResult deletetblsizeShirtFemale(string chartname)
        {
            var todo = db.tblsizeShirtFemales.Where(x => x.chartName == chartname).ToList();
            foreach (var row in todo)
            {
                db.tblsizeShirtFemales.Remove(row);
                db.SaveChanges();
            }


            return RedirectToAction("gettblsizeShirtNale", "Detail");
        }


        public ActionResult deletetblsizePantFemale(string chartname)
        {
            var todo = db.tblsizePantFemales.Where(x => x.chartName == chartname).ToList();
            foreach (var row in todo)
            {
                db.tblsizePantFemales.Remove(row);
                db.SaveChanges();
            }


            return RedirectToAction("gettblsizeShirtNale", "Detail");
        }

        public ActionResult deletetblmaleGarment(int id)
        {
            tblmaleGarmentaction delte = new tblmaleGarmentaction();
           
            delte.Delete(id);
            

            return RedirectToAction("gettblmaleGarment", "Detail");
        }
        public ActionResult deletetblshoe(int id)
        {
            var todo = db.tblshoes.Where(x => x.id== id).FirstOrDefault();
            db.tblshoes.Remove(todo);
            db.SaveChanges();


            return RedirectToAction("gettblshoe", "Detail");
        }
    }
}