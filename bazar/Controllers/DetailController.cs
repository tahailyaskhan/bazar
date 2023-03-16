using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace bazar.Controllers
{
    [CustomAuthenticationFilter]

    public class DetailController : Controller
    {
        // GET: Detail
         bazarEntities db = new bazarEntities();
        int userid = Convert.ToInt32(System.Web.HttpContext.Current.Session["userid"]);
            public ActionResult getCategories()
            {
               
                int inputter = Convert.ToInt32(Session["inputterType"]);
                var shoptype = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();

                var CategoryTypes = (from pd in db.tblcategories
                                                       
                                     select new
                                     {
                                        pd.id,
                                        pd.categoryName,
                                        pd.shoptypeId
                                     }).Where(x=>x.shoptypeId==shoptype.shoptypeid).ToList();

               
                return Json(new { ErrorCode = "000", CategoryTypes= CategoryTypes });


            }

        public ActionResult getSizeList(int categoryid)
        {

            if (categoryid == 1)
            {


                var GetAllBtUserName=(from us in db.tblsizeShirtMales
                 select new
                 {
                     us.createdById,
                     us.chartName
                 }).Where(x=>x.createdById== userid).Distinct().ToList();
                return Json(new { ErrorCode = "000", GetAllBtUserName });
            }
           if(categoryid == 2)
            {

                var GetAllBtUserName=(from us in db.tblsizePantMales
                 select new
                 {
                     us.createdById,
                     us.chartName
                 }).Where(x => x.createdById == userid).Distinct().ToList();
                return Json(new { ErrorCode = "000", GetAllBtUserName });
            }
            return Json(new { ErrorCode = "001" });
        }

        public ActionResult getSizeListFemale(int categoryid)
        {

            if (categoryid == 3)
            {


                var GetAllBtUserName = (from us in db.tblsizeShirtFemales
                                        select new
                                        {
                                            us.createdById,
                                            us.chartName
                                        }).Where(x => x.createdById == userid).Distinct().ToList();
                return Json(new { ErrorCode = "000", GetAllBtUserName });
            }
            if(categoryid == 4)
            {

                var GetAllBtUserName = (from us in db.tblsizePantFemales
                                        select new
                                        {
                                            us.createdById,
                                            us.chartName
                                        }).Where(x => x.createdById == userid).Distinct().ToList();
                return Json(new { ErrorCode = "000", GetAllBtUserName });
            }

            return Json(new { ErrorCode = "001" });
        }
        // Views 
        public ActionResult gettblsizeShirtNale()
        {

           List<getchartnameclass> getchartname  = (from us in db.tblsizeShirtMales
                                                      select new getchartnameclass
                                                      {
                                                       chartname= us.chartName
                                                      }).Distinct().ToList();
            Session["getchartname"] = getchartname;
            var getsize = db.tblsizeShirtMales.ToList();

            return View(getsize);
            


        }

        public ActionResult gettblsizePantMale()
        {

            List<getchartnameclass> getchartname = (from us in db.tblsizePantMales
                                                    select new getchartnameclass
                                                    {
                                                        
                                                        chartname = us.chartName
                                                    }).Distinct().ToList();
            Session["getchartname"] = getchartname;
            var getsize = db.tblsizePantMales.ToList();

            return View(getsize);



        }
        public ActionResult gettblsizeShirtFemale()
        {

            List<getchartnameclass> getchartname = (from us in db.tblsizeShirtFemales
                                                    select new getchartnameclass
                                                    {
                                                        chartname = us.chartName
                                                    }).Distinct().ToList();
            Session["getfemalechartname"] = getchartname;
            var getsize = db.tblsizeShirtFemales.ToList();

            return View(getsize);



        }


        public ActionResult gettblsizePantFemale()
        {

            List<getchartnameclass> getchartname = (from us in db.tblsizePantFemales
                                                    select new getchartnameclass
                                                    {
                                                        chartname = us.chartName
                                                    }).Distinct().ToList();
            Session["getfemalechartname"] = getchartname;
            var getsize = db.tblsizePantFemales.ToList();

            return View(getsize);



        }
        public ActionResult gettblmaleGarment()
        {

            List<tblmaleGarmentclass> getgarment = (from pd in db.tblmaleGarments
                                               join sub in db.tblcategories on pd.categoryid equals sub.id
                                               select new tblmaleGarmentclass
                                               {
                                                   id=pd.id,
                                                   clothname = pd.clothname,
                                                   categoryid=pd.categoryid,
                                                   shirtsizechartid=pd.shirtsizechartid,
                                                   pantsizechartid=pd.pantsizechartid,
                                                   xsmall=pd.xsmall,
                                                   small=pd.small,
                                                   medium=pd.medium,
                                                   large=pd.large,
                                                   xlarge=pd.xlarge,
                                                   xxlarge=pd.xxlarge,
                                                   detail=pd.detail,
                                                   price=pd.price,
                                                   categoryname=sub.categoryName,
                                                   pic11=pd.pic1,
                                                   pic22=pd.pic2,
                                                   createdById=pd.createdById
                                                   
                                               }).Where(x=>x.createdById==userid).ToList();
        
                   //var s=        (from pd in db.tblmaleGarments                                                       
                   //                  select new tblmaleGarmentclass
                   //                  {
                   //                    clothname= pd.clothname,
                   //                     pd.categoryName
                   //                  }).ToList();


            //foreach (var row in otherattrlist)
            //{
            //    otherlist.Add(new bt { SubAttribute = row.SubAttribute, Category = row.Category, oRating = row.Rating, Comment = row.Comment });

            //}
            return View(getgarment);



        }


        public ActionResult gettblfemaleGarment()
        {

            List<tblfemaleGarmentclass> getgarment = (from pd in db.tblfemaleGarments
                                                    join sub in db.tblcategories on pd.categoryid equals sub.id
                                                    select new tblfemaleGarmentclass
                                                    {
                                                        id = pd.id,
                                                        clothname = pd.clothname,
                                                        categoryid = pd.categoryid,
                                                        shirtsizechartnameid = pd.shirtsizechartnameid,
                                                        pantsizechartnameid = pd.pantsizechartnameid,
                                                        xsmall = pd.xsmall,
                                                        small = pd.small,
                                                        medium = pd.medium,
                                                        large = pd.large,
                                                        xlarge = pd.xlarge,
                                                        xxlarge = pd.xxlarge,
                                                        detail = pd.detail,
                                                        price = pd.price,
                                                        categoryname = sub.categoryName,
                                                        pic11 = pd.pic1,
                                                        pic22 = pd.pic2,
                                                        pic33 = pd.pic3,
                                                        pic44 = pd.pic4

                                                    }).ToList();

            //var s=        (from pd in db.tblmaleGarments                                                       
            //                  select new tblmaleGarmentclass
            //                  {
            //                    clothname= pd.clothname,
            //                     pd.categoryName
            //                  }).ToList();


            //foreach (var row in otherattrlist)
            //{
            //    otherlist.Add(new bt { SubAttribute = row.SubAttribute, Category = row.Category, oRating = row.Rating, Comment = row.Comment });

            //}
            return View(getgarment);



        }

        public ActionResult gettblshoe()
        {

            List<tblshoeclass> getgarment = (from pd in db.tblshoes
                                                      select new tblshoeclass
                                                      {
                                                          id = pd.id,
                                                          shoename = pd.shoename,
                                                          xsmall = pd.xsmall,
                                                          small = pd.small,
                                                          medium = pd.medium,
                                                          large = pd.large,
                                                          xlarge = pd.xlarge,
                                                          xxlarge = pd.xxlarge,
                                                          detail = pd.detail,
                                                          price = pd.price,
                                                          pic11 = pd.pic1,
                                                          pic22 = pd.pic2,
                                                          pic33 = pd.pic3,
                                                         

                                                      }).ToList();

                    return View(getgarment);



        }

        public ActionResult changeStatus(int orderid)
        {
            int userid = Convert.ToInt32(Session["userid"]);
            List<tblcustomerorder> customerorderlist = new List<tblcustomerorder>();
            tblcustomerOrder getorder = db.tblcustomerOrders.Where(x => x.ownerId == userid && x.id==orderid).FirstOrDefault();
            var shoptype = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();

            if (getorder != null)
            {

                getorder.status = "done";
                db.SaveChanges();
            }
           

            return RedirectToAction("gettblorder", "Detail");
        }
            public ActionResult gettblorder()
        {
            int userid = Convert.ToInt32(Session["userid"]);
            List<tblcustomerorder> customerorderlist = new List<tblcustomerorder>();
            List<tblcustomerOrder> getorder = db.tblcustomerOrders.Where(x=>x.ownerId==userid).ToList();
            var shoptype = db.tblcreateUsers.Where(x => x.id == userid).FirstOrDefault();
            foreach (var row in getorder)
            {
                
                if (shoptype.shoptypeid == 1)
                {
                    var obj = db.tblmaleGarments.Where(x => x.id == row.orderId ).FirstOrDefault();
                    if (obj != null)
                    {
                        customerorderlist.Add(new tblcustomerorder
                        {
                            id = row.id,
                            orderId = row.orderId,
                            clothname = obj.clothname,
                            counts = row.counts,
                            cityname = row.cityname
                        ,
                            addresss = row.addresss,
                            size = row.size,
                            mobileNo = row.mobileNo,
                            Email = row.Email,
                            status = row.status,
                            reviews = row.reviews,
                            rating = row.rating,

                            pic = obj.pic1
                        });
                    }
                }
                if (shoptype.shoptypeid == 2)
                {
                    var obj = db.tblfemaleGarments.Where(x => x.id == row.orderId).FirstOrDefault();
                    if (obj != null)
                    {
                        customerorderlist.Add(new tblcustomerorder
                        {
                            id = row.id,
                            orderId = row.orderId,
                            clothname = obj.clothname,
                            counts = row.counts,
                            cityname = row.cityname
                        ,
                            addresss = row.addresss,
                            size = row.size,
                            mobileNo = row.mobileNo,
                            Email = row.Email,
                            status = row.status,
                            reviews = row.reviews,
                            rating = row.rating,

                            pic = obj.pic1
                        });
                    }
                }
                if (shoptype.shoptypeid == 3)
                {
                    var obj = db.tblshoes.Where(x => x.id == row.orderId).FirstOrDefault();
                    if (obj != null)
                    {
                        customerorderlist.Add(new tblcustomerorder
                        {
                            id = row.id,
                            orderId = row.orderId,
                            clothname = obj.shoename,
                            counts = row.counts,
                            cityname = row.cityname
                        ,
                            addresss = row.addresss,
                            size = row.size,
                            mobileNo = row.mobileNo,
                            Email = row.Email,
                            status = row.status,
                            reviews = row.reviews,
                            rating = row.rating,

                            pic = obj.pic1
                        });
                    }
                }
            }
            return View(customerorderlist);
        }
        //end

    }
}