using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bazar.Controllers
{
    public class CustomerController : Controller
    {
        bazarEntities db = new bazarEntities();
        
        // GET: Customer
        public ActionResult customerView()
        {
            
            var getCustomer = db.tblcreateUsers.ToList();
            return View(getCustomer);
        }
        public ActionResult getUsersShop(int id)
        {
            viewmodel gets = new viewmodel();
            var shoptype = db.tblcreateUsers.Where(x => x.id == id).FirstOrDefault();
            Session["shoptype"] = shoptype.shoptypeid;
            if (shoptype.shoptypeid == 1)
            {
             //hello
                gets.maleGarmmentList = db.tblmaleGarments.Where(x => x.createdById == id).ToList();
            }
            else
            {
               
                gets.femaleGarmmentList = db.tblfemaleGarments.Where(x => x.createdById == id).ToList();


            }
            Session["categories"] = db.tblcategories.ToList();
            var ss= db.tblcategories.ToList();
            ViewBag.check = null;
            Session["itemuserid"] = id;
            return View(gets);
        }
        [HttpPost]
        public ActionResult getUsersShop(string search,int shoptypeid)
        {
            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            if (shoptypeid == 1)
            {
                gets.spMaleGarmmentList = db.serachMaleGarment(search).Where(x => x.createdById == userid).ToList();

            }
            else {
                gets.spFemaleGarmmentList = db.serachFemaleGarment(search).Where(x => x.createdById == userid).ToList();

            }

            Session["categories"] = db.tblcategories.ToList();
            var ss = db.tblcategories.ToList();
            return View(gets);
        }
        public ActionResult getUsersShopCategoryItem(int categoryid)
        {
            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            TempData["categoryitem"] = db.tblmaleGarments.Where(x=>x.categoryid==categoryid && x.createdById==userid).ToList();


            Session["categories"] = db.tblcategories.ToList();
            var ss = db.tblcategories.ToList();
            return RedirectToAction("getUsersShop", "Customer",new { id=userid });
        }

        public ActionResult getProduct(int id, int userid,int categoryid)
        {
            var getSpecificGarment = db.tblmaleGarments.Where(x=>x.id==id).FirstOrDefault();
            List<tblsizeShirtMale> getsizeshirt = new List<tblsizeShirtMale>();
            List<tblsizePantMale> getsizepant = new List<tblsizePantMale>();
            Session["getshirtchartname"] = db.tblsizeShirtMales.Where(x=>x.chartName== getSpecificGarment.shirtsizechartid).ToList();
            var jj= db.tblsizeShirtMales.Where(x => x.chartName == getSpecificGarment.shirtsizechartid).ToList();
            if (categoryid == 1)
            {
                getsizeshirt = db.tblsizeShirtMales.Where(x => x.createdById == userid).ToList();
                Session["getsize"] = getsizeshirt;
            }
            if (categoryid == 2)
            {
                getsizepant = db.tblsizePantMales.Where(x => x.createdById == userid).ToList();
                Session["getsize"] = getsizepant;
            }
           
            return View(getSpecificGarment);
        }

        public ActionResult addCart(cart data)
        {
            if (Session["cart"] == null)
            {
                List<cart> li = new List<cart>();

                li.Add(data);
                Session["cart"] = li;
                Session["itemcount"] = li.Count();


                Session["count"] = 1;


            }
            else
            {
                List<cart> li = (List<cart>)Session["cart"];
                var check = li.Where(x => x.ids == data.ids).FirstOrDefault();
                if (check != null)
                {
                    check.price = data.price;
                    check.pic1 = data.pic1;
                    check.quantity = data.quantity;
                    check.size = data.size;
                }
                else
                {
                    li.Add(data);
                    Session["cart"] = li;
                    Session["itemcount"] = li.Count();
                }
               
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }

            return RedirectToAction("getUsersShop","Customer",new{id=data.userid});
        }

        public ActionResult deleteItem(int id)
        {
            
            List<cart> li = (List<cart>)Session["cart"];
            var row = li.Where(x => x.ids == id).FirstOrDefault();
            li.Remove(row);
            Session["cart"] = li;
            Session["itemcount"] = li.Count();
           

            return RedirectToAction("getCart", "Customer");
        }
        public ActionResult getCart()
        {

            return View();
        }
        public ActionResult getChart()
        {

            return View();
        }
       [HttpPost]
        public ActionResult GaugeChart()
        {
            List<object> data = new List<object>();
            List<string> test = db.tblmaleGarments.Select(x => x.shirtsizechartid).ToList();
            data.Add(test);

            List<int> test1 = db.tblmaleGarments.Select(x => x.id).ToList();
            data.Add(test1);

            return Json(data, JsonRequestBehavior.AllowGet);
            
        }

        public class GenderPopulation
        {
            public Nullable<double> id
            {
                get;
                set;
            } = 0;
            public Nullable<double> categoryid
            {
                get;
                set;
            } = 0;
           
        }

    }
}