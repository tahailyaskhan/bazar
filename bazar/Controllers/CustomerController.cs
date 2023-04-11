using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bazar.Controllers
{
    public class CustomerController : Controller
    {
        bazarEntities db = new bazarEntities();

        // GET: Customer
        public ActionResult customerView()
        {
            viewmodel get = new viewmodel();
            Session["market"] = db.tblmarkets.ToList();
            //   var getCustomer = db.tblcreateUsers.ToList();
            get.userList = db.tblcreateUsers.ToList();

            return View(get);
        }
        [HttpPost]
        public ActionResult customerView(string search)
        {
            viewmodel get = new viewmodel();
            Session["market"] = db.tblmarkets.ToList();
            get.spUserList = db.serachUser(search).ToList();

            //var getCustomer = db.tblcreateUsers.Where(x=>x.name==search).ToList();
            return View(get);

        }
        public ActionResult checkout()
        {
            ViewBag.success = "fail";
            return View();
        }
        [HttpPost]
        public ActionResult checkout(customerInfo data)
        {
            tblcustomerOrder obj = new tblcustomerOrder();

            List<cart> cartlist = Session["cart"] as List<cart>;
            if (cartlist != null)
            {
                foreach (var item in cartlist)
                {
                    obj.customername = data.firstname;
                    obj.addresss = data.addresss;
                    obj.cityname = data.city;
                    obj.Email = data.email;
                    obj.mobileNo = data.tel;
                    obj.ownerId = item.userid;
                    obj.counts = item.quantity;
                    obj.price = item.price;
                    obj.orderId = item.ids;
                    obj.status = "pending";
                    db.tblcustomerOrders.Add(obj);
                    db.SaveChanges();
                }
                //return RedirectToAction("receipt", "Customer");
                return Json(new { messege = "success" });
            }
            else
            {
                return Json(new { messege = "fail" });
            }
            //ViewBag.success = "success";
            //return View();
        }
        [HttpGet]
        public ActionResult getMarketShop(int marketid)
        {

            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            TempData["marketshop"] = db.tblcreateUsers.Where(x => x.marketid == marketid).ToList();

            var obj = db.tblmarkets.Where(x => x.id == marketid).FirstOrDefault();

            TempData["searchedMarket"] = obj.marketName;

            return RedirectToAction("customerView", "Customer");
        }
        [HttpGet]
        [Route("{ shopname ?}")]
        public ActionResult getUsersShop(string shopname)
        {
            viewmodel gets = new viewmodel();
            var shoptype = db.tblcreateUsers.Where(x => x.name == shopname).FirstOrDefault();
            Session["shoptype"] = shoptype.shoptypeid;
            Session["shoplogo"] = shoptype.logo;
            Session["shopname"] = shoptype.name;
            if (shoptype.shoptypeid == 1)
            {
                //hello
                //gets.maleGarmmentList = db.tblmaleGarments.Where(x => x.createdById == id).ToList();
                gets.maleGarmmentList = db.tblmaleGarments.Where(x => x.createdById == shoptype.id).ToList();
            }
            if (shoptype.shoptypeid == 2)
            {

                //gets.femaleGarmmentList = db.tblfemaleGarments.Where(x => x.createdById == id).ToList();
                gets.femaleGarmmentList = db.tblfemaleGarments.Where(x => x.createdById == shoptype.id).ToList();


            }
            if (shoptype.shoptypeid == 3)
            {
                //hello
                //gets.shoeList = db.tblshoes.Where(x => x.createdById == id).ToList();
                gets.shoeList = db.tblshoes.Where(x => x.createdById == shoptype.id).ToList();
            }
            Session["categories"] = db.tblcategories.Where(x => x.shoptypeId == shoptype.shoptypeid).ToList();
            var ss = db.tblcategories.ToList();
            ViewBag.check = null;
            Session["itemuserid"] = shoptype.id;
            return View(gets);
            //return View();
        }
        [HttpPost]
        [Route("getUsersShop")]
        public ActionResult getUsersShop(string search,string shoptypeid)
        {
            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            if (Convert.ToInt32(shoptypeid) == 1)
            {
                gets.spMaleGarmmentList = db.serachMaleGarment(search).Where(x => x.createdById == userid).ToList();

            }
            if (Convert.ToInt32(shoptypeid) == 2)
            {
                gets.spFemaleGarmmentList = db.serachFemaleGarment(search).Where(x => x.createdById == userid).ToList();

            }
            if (Convert.ToInt32(shoptypeid) == 3)
            {
                gets.spShoeList = db.serachShoe(search).Where(x => x.createdById == userid).ToList();

            }
            //Session["categories"] = db.tblcategories.ToList();
            var ss = db.tblcategories.ToList();
            return View(gets);
        }

       
        public ActionResult getUsersShopCategoryItem(int categoryid)
        {
            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            var shopname = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();
            if (categoryid == 1 || categoryid==2) {

                TempData["categoryitem"] = db.tblmaleGarments.Where(x => x.categoryid == categoryid && x.createdById == userid).ToList();

            }
            if (categoryid == 3 || categoryid == 4)
            {

                TempData["categoryfemaleitem"] = db.tblfemaleGarments.Where(x => x.categoryid == categoryid && x.createdById == userid).ToList();

            }
            if (categoryid == 5 || categoryid == 6)
            {

                TempData["categoryshoesitem"] = db.tblshoes.Where(x => x.categoryid == categoryid && x.createdById == userid).ToList();

            }


            //Session["categories"] = db.tblcategories.ToList();
            //var ss = db.tblcategories.ToList();
            //return RedirectToAction("getUsersShop", "Customer",new { id=userid });
          
            return RedirectToAction("getUsersShop", "Customer", new { shopname = shopname.name });
        }

        public ActionResult getProduct(int id, int userid,int categoryid)
        {
            viewmodel obj = new viewmodel();
            tblmaleGarment getSpecificGarment = new tblmaleGarment();
            tblfemaleGarment getSpecificfeGarment = new tblfemaleGarment();
            if (categoryid == 1 || categoryid == 2)
            {
                obj.maleGarmentObj  = db.tblmaleGarments.Where(x => x.id == id).FirstOrDefault();
            }
            if (categoryid == 3 || categoryid == 4)
            {
               obj.femaleGarmentObj = db.tblfemaleGarments.Where(x => x.id == id).FirstOrDefault();

            }
            if (categoryid == 5 || categoryid == 6)
            {
                obj.shoeObj = db.tblshoes.Where(x => x.id == id).FirstOrDefault();
            }
            List<tblsizeShirtMale> getsizeshirt = new List<tblsizeShirtMale>();
            List<tblsizePantMale> getsizepant = new List<tblsizePantMale>();
            List<tblsizeShirtFemale> getsizeshirtfemale = new List<tblsizeShirtFemale>();
            List<tblsizePantFemale> getsizepantfemale = new List<tblsizePantFemale>();
            Session["getshirtchartname"] = db.tblsizeShirtMales.Where(x=>x.chartName== getSpecificGarment.shirtsizechartid).ToList();
            var jj= db.tblsizeShirtMales.Where(x => x.chartName == getSpecificGarment.shirtsizechartid).ToList();
            if (categoryid == 1)
            {
                getsizeshirt = db.tblsizeShirtMales.Where(x => x.createdById == userid).ToList();
               obj.maleShirtSizeList = db.tblsizeShirtMales.Where(x => x.chartName == obj.maleGarmentObj.shirtsizechartid).ToList();
            }
            if (categoryid == 2)
            {
                getsizepant = db.tblsizePantMales.Where(x => x.createdById == userid).ToList();
                obj.malePantSizeList = db.tblsizePantMales.Where(x => x.chartName == obj.maleGarmentObj.pantsizechartid).ToList();
            }
            if (categoryid == 3)
            {
                getsizeshirtfemale = db.tblsizeShirtFemales.Where(x => x.createdById == userid).ToList();
                obj.femaleShirtSizeList = db.tblsizeShirtFemales.Where(x => x.chartName == obj.femaleGarmentObj.shirtsizechartnameid).ToList();
            }
            if (categoryid == 4)
            {
                getsizepantfemale = db.tblsizePantFemales.Where(x => x.chartName == getSpecificfeGarment.shirtsizechartnameid).ToList();
                obj.femalePantSizeList = db.tblsizePantFemales.Where(x => x.chartName == obj.femaleGarmentObj.pantsizechartnameid).ToList();
            }



            return View(obj);
        }

        public ActionResult addCart(cart data)
        {
         
            if (Session["cart"] == null)
            {
                List<cart> li = new List<cart>();
                var obj = db.tblcreateUsers.Where(x => x.id == data.userid).FirstOrDefault();

                data.brandname = obj.name;
                data.date = DateTime.Now.ToString();
                data.price = data.price * data.quantity;
                
                li.Add(data);
                Session["cart"] = li;
                Session["itemcount"] = li.Count();
                Session["total"]= data.price * data.quantity;

                Session["count"] = 1;


            }
            else
            {
                List<cart> li = (List<cart>)Session["cart"];
                int total = 0;
                var check = li.Where(x => x.ids == data.ids && x.userid==data.userid).FirstOrDefault();
                if (check != null)
                {
                    check.price = data.price*data.quantity;
                    check.pic1 = data.pic1;
                    check.quantity = data.quantity;
                    check.size = data.size;
                }
                else
                {
                    var obj = db.tblcreateUsers.Where(x => x.id == data.userid).FirstOrDefault();
                    data.date = DateTime.Now.ToString();
                    data.brandname = obj.name;
                    data.price = data.price * data.quantity;
                    li.Add(data);
                    Session["cart"] = li;
                    Session["itemcount"] = li.Count();
                }

                foreach (var item in li)
                {
                    total = total + item.price;
                }
                Session["total"] = total;
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            var shopname = db.tblcreateUsers.Where(x => x.id == data.userid).FirstOrDefault();
            return RedirectToAction("getUsersShop", "Customer", new { shopname = shopname.name });
            //return RedirectToAction("getUsersShop","Customer",new{id=data.userid});
        }

        public ActionResult deleteItem(int id,int userid)
        {
            
            List<cart> li = (List<cart>)Session["cart"];
            int total = 0;
            var row = li.Where(x => x.ids == id && x.userid==userid).FirstOrDefault();
            li.Remove(row);
            Session["cart"] = li;
            Session["itemcount"] = li.Count();

            foreach (var item in li)
            {
                total = total + item.price;
            }
            Session["total"] = total;
            return RedirectToAction("getCart", "Customer");
        }
        public ActionResult getCart()
        {

            return View();
        }

        public ActionResult receipt()
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