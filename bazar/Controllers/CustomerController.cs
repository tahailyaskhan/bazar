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
        int itemuserid;
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
             //ds
                gets.maleGarmmentList = db.tblmaleGarments.Where(x => x.createdById == id).ToList();
            }
            if (shoptype.shoptypeid == 3)
            {
                //hello
                //ds
                gets.shoeList = db.tblshoes.Where(x => x.createdById == id).ToList();
            }
            else
            {
               
                gets.femaleGarmmentList = db.tblfemaleGarments.Where(x => x.createdById == id).ToList();


            }
            Session["categories"] = db.tblcategories.ToList();
            gets.categorylist= db.tblcategories.Where(x=>x.shoptypeId==shoptype.shoptypeid).ToList();
            var ss= db.tblcategories.ToList();
            ViewBag.check = null;
            Session["itemuserid"] = id;
            itemuserid = id;
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
            if (shoptypeid == 3)
            {
                gets.spShoeList = db.serachShoes(search).Where(x => x.createdById == userid).ToList();

            }
            else {
                gets.spFemaleGarmmentList = db.serachFemaleGarment(search).Where(x => x.createdById == userid).ToList();

            }
            gets.categorylist = db.tblcategories.Where(x => x.shoptypeId == shoptypeid).ToList();
            Session["categories"] = db.tblcategories.ToList();
            var ss = db.tblcategories.ToList();
            return View(gets);
        }
        public ActionResult getUsersShopCategoryItem(int categoryid)
        {
            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            //var userid = itemuserid;
            if (categoryid == 1 || categoryid == 2)
            {
                TempData["categoryitemmale"] = db.tblmaleGarments.Where(x => x.categoryid == categoryid && x.createdById == userid).ToList();
            }
            if (categoryid == 5 || categoryid == 6)
            {
                TempData["categoryitemshoe"] = db.tblshoes.Where(x => x.categoryid == categoryid && x.createdById == userid).ToList();
            }
            else
            {
                TempData["categoryitemfemale"] = db.tblfemaleGarments.Where(x => x.categoryid == categoryid && x.createdById == userid).ToList();
            }
          
            //Session["categories"] = db.tblcategories.ToList();
            //var ss = db.tblcategories.ToList();
            return RedirectToAction("getUsersShop", "Customer",new { id=userid });
        }

        public ActionResult getProduct(int id, int userid,int categoryid)
        {
            var shoptype = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();
            viewmodel ss = new viewmodel();
            List<tblsizeShirtMale> getsizeshirt = new List<tblsizeShirtMale>();
            List<tblsizePantMale> getsizepant = new List<tblsizePantMale>();
            List<tblsizeShirtFemale> getsizeshirtfe = new List<tblsizeShirtFemale>();
            List<tblsizePantFemale> getsizepantfe = new List<tblsizePantFemale>();
            if (shoptype.shoptypeid == 1)
            {
                tblmaleGarment getSpecificGarment = db.tblmaleGarments.Where(x => x.id == id).FirstOrDefault();
                ss.maleGarmmentobj = getSpecificGarment;
               
                var jj = db.tblsizeShirtMales.Where(x => x.chartName == getSpecificGarment.shirtsizechartid).ToList();
                if (categoryid == 1)
                {
                   ss.tblsizeShirtMalelist= db.tblsizeShirtMales.Where(x => x.chartName == getSpecificGarment.shirtsizechartid).ToList();

                    getsizeshirt = db.tblsizeShirtMales.Where(x => x.createdById == userid).ToList();
                    Session["getsize"] = getsizeshirt;
                }
                if (categoryid == 2)
                {
                    ss.tblsizePantMalelist = db.tblsizePantMales.Where(x => x.chartName == getSpecificGarment.shirtsizechartid).ToList();

                    getsizepant = db.tblsizePantMales.Where(x => x.createdById == userid).ToList();
                    Session["getsize"] = getsizepant;
                }
            }

            if (shoptype.shoptypeid == 3)
            {

                tblshoe getSpecificshoe = db.tblshoes.Where(x => x.id == id).FirstOrDefault();
                ss.shoeobj = getSpecificshoe;
            }
            if(shoptype.shoptypeid == 2)
            {

                tblfemaleGarment getSpecificGarment = db.tblfemaleGarments.Where(x => x.id == id).FirstOrDefault();
                ss.femaleGarmmentobj = getSpecificGarment;

                var jj = db.tblsizeShirtMales.Where(x => x.chartName == getSpecificGarment.shirtsizechartnameid).ToList();
                if (categoryid == 1)
                {
                    ss.tblsizeShirtFemalelist = db.tblsizeShirtFemales.Where(x => x.chartName == getSpecificGarment.shirtsizechartnameid).ToList();

                    getsizeshirtfe = db.tblsizeShirtFemales.Where(x => x.createdById == userid).ToList();
                    Session["getsize"] = getsizeshirt;
                }
                if (categoryid == 2)
                {
                    ss.tblsizePantFemalelist = db.tblsizePantFemales.Where(x => x.chartName == getSpecificGarment.shirtsizechartnameid).ToList();

                    getsizepantfe = db.tblsizePantFemales.Where(x => x.createdById == userid).ToList();
                    Session["getsize"] = getsizepant;
                }
            }
           
            return View(ss);
        }

        public ActionResult addCart(cart data)
        {
            int total = 0;
            if (Session["cart"] == null)
            {
                List<cart> li = new List<cart>();
                data.price= data.price * data.quantity;
                li.Add(data);
                Session["cart"] = li;
                Session["itemcount"] = li.Count();
                Session["cartTotal"] = data.price; 
                
                Session["count"] = 1;


            }
            else
            {
                List<cart> li = (List<cart>)Session["cart"];
                var check = li.Where(x => x.ids== data.ids).FirstOrDefault();
                if (check != null)
                {
                    check.price = data.price* data.quantity;
                    check.pic1 = data.pic1;
                    check.quantity = data.quantity;
                    check.size = data.size;
                    foreach (var item in li)
                    {
                        total = total + item.price;
                     
                    }
                    Session["cartTotal"] =total;
                }
                else
                {
                    data.price = data.price * data.quantity;
                    li.Add(data);
                    Session["cart"] = li;
                    Session["itemcount"] = li.Count();
                    foreach (var item in li)
                    {
                        total = total + item.price;

                    }
                    Session["cartTotal"] = total;

                }
               
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }

            return RedirectToAction("getUsersShop","Customer",new{id=data.userid});
        }

        public ActionResult deleteItem(int id)
        {
            int total = 0;
            List<cart> li = (List<cart>)Session["cart"];
            var row = li.Where(x => x.ids == id).FirstOrDefault();
            li.Remove(row);
            Session["cart"] = li;
            Session["itemcount"] = li.Count();
            foreach (var item in li)
            {
                total = total + item.price;

            }
            Session["cartTotal"] = total;

            return RedirectToAction("getCart", "Customer");
        }
        public ActionResult getCart()
        {

            return View();
        }

        public ActionResult checkout()
        {

            return View();
        }

        public ActionResult orderReceipt(customerInfo data)
        {
            List<cart> li = (List<cart>)Session["cart"];
            tblcustomerOrder obj = new tblcustomerOrder();
           
                foreach (var item in li)
                {
                   
                    obj.orderId=item.ids;
                    obj.ownerId = item.userid;
                    obj.counts = item.quantity;
                    obj.size = item.size;
                    obj.price = item.price;
                    obj.customername = data.firstname;
                    obj.Email = data.email;
                    obj.cityname = data.city;
                    obj.addresss = data.adddress;
                    obj.mobileNo = data.tel;
                    db.tblcustomerOrders.Add(obj);
                    db.SaveChanges();

                }
            

           
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