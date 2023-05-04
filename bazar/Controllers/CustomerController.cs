using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

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
            Session["shop"] = db.tblshoptypes.Where(x=>x.id!=1 && x.id != 2 && x.id != 3).ToList();
            //   var getCustomer = db.tblcreateUsers.ToList();
            get.userList = db.tblcreateUsers.Where(x=>x.roleid!=5 && x.roleid != 1).ToList();

            return View(get);
        }
        [HttpPost]
        public ActionResult customerView(string search)
        {
            viewmodel get = new viewmodel();
            Session["market"] = db.tblmarkets.ToList();
            Session["shop"] = db.tblshoptypes.ToList();
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
            List<tblcustomerOrder> cart = new List<tblcustomerOrder>();
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
                    obj.size = item.size;
                    obj.status = "pending";

                    cart.Add(obj);


                    db.tblcustomerOrders.Add(obj);
                    db.SaveChanges();
                }
                Session["receipt"] = cart;
                //try
                //{
                //    if (ModelState.IsValid)
                //    {
                //        var senderEmail = new MailAddress("mtk212@yahoo.com", "Jamil");
                //        var receiverEmail = new MailAddress("ktahakhan8@gmail.com", "Receiver");
                //        var password = "Your Email Password here";
                //        var sub = "subject";
                //        var body = "message";
                //        var smtp = new SmtpClient
                //        {
                //            Host = "smtp.gmail.com",
                //            Port = 587,
                //            EnableSsl = true,
                //            DeliveryMethod = SmtpDeliveryMethod.Network,
                //            UseDefaultCredentials = false,
                //            Credentials = new NetworkCredential(senderEmail.Address, password)
                //        };
                //        using (var mess = new MailMessage(senderEmail, receiverEmail)
                //        {
                //            Subject = sub,
                //            Body = body
                //        })
                //        {
                //            smtp.Send(mess);
                //        }
                //        return View();
                //    }
                //}
                //catch (Exception)
                //{
                //    ViewBag.Error = "Some Error";
                //}
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

        public ActionResult semail()
        {
            try
            {
               
                {
                    var senderEmail = new MailAddress("ktahakhan8@gmail.com", "Jamil");
                    var receiverEmail = new MailAddress("mtk212@yahoo.com", "Receiver");
                    var password = "okoxdnbhxitekqny";
                    var sub = "subject";
                    var body = "message";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("ktahakhan8@gmail.com", password),
                       
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        
                        smtp.Send(mess);
                    }
                    return RedirectToAction("customerView", "Customer");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
                return RedirectToAction("customerView", "Customer");
            }
            return RedirectToAction("customerView", "Customer");
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
        public ActionResult getShoptype(int shoptypeid)
        {

            viewmodel gets = new viewmodel();
            var userid = Convert.ToInt32(Session["itemuserid"]);
            TempData["marketshop"] = db.tblcreateUsers.Where(x => x.shoptypeid == shoptypeid).ToList();

            var obj = db.tblshoptypes.Where(x => x.id == shoptypeid).FirstOrDefault();

            TempData["searchedMarket"] = obj.shoptypeName;

            return RedirectToAction("customerView", "Customer");
        }
        [HttpGet]
       
        [Route("yourshop/{ shopname ?}")]
        public ActionResult getUsersShop(string shopname)
        {
            viewmodel gets = new viewmodel();
         
            
            var shoptype = db.tblcreateUsers.Where(x => x.name == shopname).FirstOrDefault();
            Session["shoptype"] = shoptype.shoptypeid;
            Session["shoplogo"] = shoptype.logo;
            Session["shopname"] = shoptype.name;
            ViewBag.shoplogo = shoptype.logo;
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
            //Session["categories"] = db.tblcategories.Where(x => x.shoptypeId == shoptype.shoptypeid).ToList();
            ViewBag.categories = db.tblcategories.Where(x => x.shoptypeId == shoptype.shoptypeid).ToList();
            var ss = db.tblcategories.ToList();
            ViewBag.check = null;
            Session["itemuserid"] = shoptype.id;
            var getcustomerreviews = db.getCustomerReviews(shoptype.id).ToList();
            gets.spGetCustomerReviews = getcustomerreviews;
            return View(gets);
            //return View();
        }
        [HttpPost]
        //[Route("getUsersShop")]
        public ActionResult getUsersShop(string search,string shoptypeid,string usersid)
        {/////
            viewmodel gets = new viewmodel();
            //var userid = Convert.ToInt32(Session["itemuserid"]);

            var userid = Convert.ToInt32(usersid);
            var shoptype = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();
            Session["shoptype"] = shoptype.shoptypeid;
            Session["shoplogo"] = shoptype.logo;
            Session["shopname"] = shoptype.name;
         
            ViewBag.shoplogo = shoptype.logo;
           

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
            ViewBag.categories = db.tblcategories.Where(x => x.shoptypeId == shoptype.shoptypeid).ToList();
            //Session["categories"] = db.tblcategories.ToList();
            var ss = db.tblcategories.ToList();
            return View(gets);
        }

       
        public ActionResult getUsersShopCategoryItem(int categoryid, string usersid)
        {
            viewmodel gets = new viewmodel();
            //var userid = Convert.ToInt32(Session["itemuserid"]);
            var userid = Convert.ToInt32(usersid);
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

            var shoptype = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();
            ViewBag.categories = db.tblcategories.Where(x => x.shoptypeId == shoptype.shoptypeid).ToList();
            ViewBag.shoplogo = shoptype.logo;
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
            string midmesg = "";
            
            var obj=db.tbl_template.FirstOrDefault();

            string uppermesg =obj.uppermesg;
            string endmesg = obj.endmesg;

            string mesg = "";
            try
            {

                {
                    var senderEmail = new MailAddress("ktahakhan8@gmail.com", "Jamil");
                    var receiverEmail = new MailAddress("mtk212@yahoo.com", "Receiver");
                    var password = "okoxdnbhxitekqny";
                    var sub = "subject";
                    string table = "<table><tr><td>id</td><td>Name</td><td>Price</td></tr></table>";
                    

                    MailDefinition md = new MailDefinition();
                    md.From = "test@domain.example";
                    md.IsBodyHtml = true;
                    md.Subject = "Test of MailDefinition";
                    //md.IsBodyHtml = true;
                    foreach (var rows in Session["cart"] as List<bazar.DAL.Data.cart>)
                    {

                        midmesg = midmesg + "<tr><td> <p style='font - size:14px; margin: 0; padding: 10px; border: solid 1px #ddd;font-weight:bold;'><span style='display:block;font-size:13px;font-weight:normal;'>" + rows.clothname + "[by" + rows.brandname + "]</span>" + "Rs:" + rows.price + "</p>" + "</td></tr>";
                            


                    }
                    mesg = uppermesg + midmesg + endmesg;
                    //uppermesg = "<table  width='100%' cellpadding='0' cellspacing='0'>"+
                    //      "  <tbody>"+
                    //           " <tr>"+
                    //                "<td>"+
                    //                   "<table width='100%' cellpadding='0' cellspacing='0'>"+
                    //                        "<tbody>"+
                    //                            "<tr>"+
                    //                                "<td  style='text-align:center'>"+
                    //                                    "<h2>Thanks for using our app</h2>"+
                    //                                "</td>"+
                    //                            "</tr>"+
                    //                            "<tr>"+
                    //                               "<td >"+
                    //                                    "<table>"+
                    //                                        "<tbody>"+
                    //                                            "<tr>"+
                    //                                                <td>EShop<br>enddate</td>
                    //                                            </tr>
                    //                                            <tr>
                    //                                                <td>
                    //                                                    <table class="invoice-items" cellpadding="0" cellspacing="0">
                    //                                                        <tbody>";
                    //mesg=mesg+ <tr> <td> <table class="invoice-items" cellpadding="0" cellspacing="0"> <tbody>



                    //foreach (var rows in Session["cart"] as List<bazar.DAL.Data.cart>)
                    //{

                    //    mesg = mesg + "<tr>  <td>@rows.clothname <span style='color: orange'> [by" + rows.brandname + "]</span></td>" +
                    //        "<td class='alignright''> Rs:" + rows.price + " </td> </tr>";


                    //}

                    var body = table;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("ktahakhan8@gmail.com", password),

                    };

                    
                    body = mesg;
                    foreach (var rows in Session["receipt"] as List<bazar.Models.tblcustomerOrder>)
                   {
                        body = body.Replace("customername", rows.customername);
                        body = body.Replace("customernumber", rows.mobileNo);
                        body = body.Replace("customeraddress", rows.addresss);
                        body = body.Replace("totalamount", Convert.ToString(@Session["total"]));
                        body = body.Replace("orderdate", DateTime.Now.ToString());
                        break;
                    }                   
                   
                    //using (var mess = new MailMessage(senderEmail, receiverEmail)
                    //{
                    //    Subject = sub,
                    //    Body = Convert.ToString(body)
                    //})
                    ListDictionary replacements = new ListDictionary();
                    MailMessage msg = md.CreateMailMessage("mtk212@yahoo.com", replacements, body, new System.Web.UI.Control());
                    {

                        smtp.Send(msg);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
                
            }

            return View();
        }

        //public ActionResult getReviews(int userid)
        //{
        //    viewmodel getReviews = new viewmodel();
        //    var getcustomerreviews = db.getCustomerReviews(userid).ToList();
        //    getReviews.spGetCustomerReviews = getcustomerreviews;
        //    return View(getReviews);
        //}

        [HttpPost]
        public ActionResult checkNumber(string number, string review, string userid,string rating)
        {
            int ownerid = Convert.ToInt32(userid);
            var check = db.tblcustomerOrders.Where(x => x.status == "recieved" && x.mobileNo == number && x.ownerId==ownerid&& x.rating == null).FirstOrDefault();
            if (check == null && rating == null)
            {
                return Json(new { messege = "notfound" });
            }
            else if (check != null && rating == null)
            {
                return Json(new { messege = "found" });
            }
            else if (rating != null)
            {
                var list = db.tblcustomerOrders.Where(x => x.status == "recieved" && x.mobileNo == number && x.ownerId == ownerid && x.rating == null).ToList();
                foreach (var i in list)
                {
                    i.rating = Convert.ToInt32(rating);
                    i.reviews = review;
                    db.SaveChanges();

                }
                return Json(new { messege = "congo" });
            }


            //return RedirectToAction("receipt", "Customer");
            return Json(new { messege = "success" });
            
            
            
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