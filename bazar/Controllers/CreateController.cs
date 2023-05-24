using bazar.DAL.Data;
using bazar.DAL.Repository;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bazar.Controllers
{
    public class CreateController : Controller
    {
        bazarEntities db = new bazarEntities();
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addtblsizeShirtMale(tblsizeShirtMaleField data)
        {
            tblsizeShirtMaleaction repo = new tblsizeShirtMaleaction();
            try
            {
                var checkchart = db.tblsizeShirtMales.Where(x => x.chartName == data.chartName.ToString()).FirstOrDefault();
               
                if (checkchart == null)
                {
                    tblsizeShirtMale ci = new tblsizeShirtMale();
                    ci.collar = data.xscollar;
                    ci.chest = data.xschest;
                    ci.sleeveLength = data.xssleeveLength;
                    ci.shirtLength = data.xsshirtLength;
                    ci.sizeName = "xsmall";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);



                    ci.collar = data.scollar;
                    ci.chest = data.schest;
                    ci.sleeveLength = data.ssleeveLength;
                    ci.shirtLength = data.sshirtLength;
                    ci.sizeName = "small";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.collar = data.mcollar;
                    ci.chest = data.mchest;
                    ci.sleeveLength = data.msleeveLength;
                    ci.shirtLength = data.mshirtLength;
                    ci.sizeName = "medium";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);



                    ci.collar = data.lcollar;
                    ci.chest = data.lchest;
                    ci.sleeveLength = data.lsleeveLength;
                    ci.shirtLength = data.lshirtLength;
                    ci.sizeName = "large";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                    ci.collar = data.xlcollar;
                    ci.chest = data.xlchest;
                    ci.sleeveLength = data.xlsleeveLength;
                    ci.shirtLength = data.xlshirtLength;
                    ci.sizeName = "xllarge";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                    TempData["successstatusshirt"] = "success";
                    return Json(new{ messege ="success"});
                  //  return RedirectToAction("Index", "Home");
                }

                else
                {
                    TempData["successstatusshirt"] = "exist";
                    //return RedirectToAction("Index", "Home");
                    return Json(new { messege = "exist" });
                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.Message.ToString(); 
                //return RedirectToAction("Index", "Home");
                return Json(new { messege = "exception", exception=ex.Message });
            }
        }
        public ActionResult addtblsizePantMale(tblsizePantMaleclass data)
        {
            tblsizePantMaleaction repo = new tblsizePantMaleaction();
            try
            {
                var checkchart = db.tblsizePantMales.Where(x => x.chartName == data.chartName.ToString()).FirstOrDefault();

                if (checkchart == null)
                {
                    tblsizePantMale ci = new tblsizePantMale();
                    ci.waist = data.xswaist;
                    ci.pantlength = data.xspantlength;
                    ci.sizeName = "xsmall";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.waist = data.swaist;
                    ci.sizeName = "small";
                    ci.pantlength = data.spantlength;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.waist = data.mwaist;
                    ci.pantlength = data.mpantlength;
                    ci.sizeName = "medium";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.waist = data.lwaist;
                    ci.pantlength = data.lpantlength;
                    ci.sizeName = "large";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);



                    ci.waist = data.xlwaist;
                    ci.sizeName = "xlarge";
                    ci.pantlength = data.xlpantlength;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);
                   

                    return Json(new { messege = "success" });

                }
                else
                {

                    return Json(new { messege = "exist" });

                }
            }
            catch (Exception ex)

            {
                Session["exception"] = ex.Message.ToString();
                return Json(new { messege = "exception", exception=ex.Message.ToString() });
                //return View();
            }
        }

        public ActionResult addtblsizeShoeMale(tblsizeShirtMaleField data)
        {
            tblsizeShirtMaleaction repo = new tblsizeShirtMaleaction();
            try
            {
                var checkchart = db.tblsizeShirtMales.Where(x => x.chartName == data.chartName.ToString()).FirstOrDefault();

                if (checkchart == null)
                {
                    tblsizeShoe ci = new tblsizeShoe();
                    ci.sizeNumber = Convert.ToString(data.xscollar);
                   
                    ci.sizeName = "5";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    
                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();




                    ci.sizeNumber = Convert.ToString(data.scollar);

                    ci.sizeName = "6";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();


                    ci.sizeNumber = Convert.ToString(data.mcollar);

                    ci.sizeName = "7";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();



                    ci.sizeNumber = Convert.ToString(data.lcollar);

                    ci.sizeName = "8";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();

                    ci.sizeNumber = Convert.ToString(data.xlcollar);

                    ci.sizeName = "9";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();


                    ci.sizeNumber = Convert.ToString(data.xllcollar);

                    ci.sizeName = "10";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();


                    ci.sizeNumber = Convert.ToString(data.xlllcollar);

                    ci.sizeName = "11";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();

                    TempData["successstatusshirt"] = "success";
                    return Json(new { messege = "success" });
                    //  return RedirectToAction("Index", "Home");
                }

                else
                {
                    TempData["successstatusshirt"] = "exist";
                    //return RedirectToAction("Index", "Home");
                    return Json(new { messege = "exist" });
                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("Index", "Home");
            }
        }


          public ActionResult addtblsizeShoeFemale(tblsizeShirtMaleField data)
        {
            tblsizeShirtMaleaction repo = new tblsizeShirtMaleaction();
            try
            {
                var checkchart = db.tblsizeShirtMales.Where(x => x.chartName == data.chartName.ToString()).FirstOrDefault();

                if (checkchart == null)
                {
                    tblsizeShoe ci = new tblsizeShoe();
                    ci.sizeNumber = Convert.ToString(data.xscollar);
                   
                    ci.sizeName = "3";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    
                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();




                    ci.sizeNumber = Convert.ToString(data.scollar);

                    ci.sizeName = "4";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();


                    ci.sizeNumber = Convert.ToString(data.mcollar);

                    ci.sizeName = "5";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();



                    ci.sizeNumber = Convert.ToString(data.lcollar);

                    ci.sizeName = "6";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();

                    ci.sizeNumber = Convert.ToString(data.xlcollar);

                    ci.sizeName = "7";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();


                    ci.sizeNumber = Convert.ToString(data.xllcollar);

                    ci.sizeName = "8";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();


                    ci.sizeNumber = Convert.ToString(data.xlllcollar);

                    ci.sizeName = "9";
                    ci.createdById = Convert.ToInt32(Session["userid"]);

                    ci.chartname = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShoes.Add(ci);
                    db.SaveChanges();

                    TempData["successstatusshirt"] = "success";
                    return Json(new { messege = "success" });
                    //  return RedirectToAction("Index", "Home");
                }

                else
                {
                    TempData["successstatusshirt"] = "exist";
                    //return RedirectToAction("Index", "Home");
                    return Json(new { messege = "exist" });
                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult addtbluser(userclass data)
        {
          
            try
            {
                Random rnd = new Random();
                string filename = "";
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                var checkusername = db.tblcreateUsers.Where(x => x.username == data.username.ToString()).FirstOrDefault();
                var checkshopname = db.tblcreateUsers.Where(x => x.shopname == data.shopname.ToString()).FirstOrDefault();
                string ServerSavePath = "";
                if (checkusername== null && checkshopname == null) 
                {
                    tblcreateUser ci = new tblcreateUser();
                    ci.username = data.username;
                    ci.password = data.password;
                    ci.email = data.email;
                    ci.cnic = data.cnic;
                    ci.shopname = data.shopname;
                    ci.name = data.shopname;
                    ci.addresss = data.address;
                    ci.roleid = data.roleid;
                    ci.marketid = data.marketid;
                    ci.shoptypeid = data.shoptypeid;
                    string keypath=ConfigurationManager.AppSettings["keypathprofilepic"];
                    string httpurl= ConfigurationManager.AppSettings["httpurl"];

                    string path = @keypath + data.username;  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }

                    if (data.pics1 != null)

                    {
                        var InputFileName = Path.GetFileName(data.pics1.FileName);
                 
                        var InputFileName2 = num + Session["userid"].ToString()+InputFileName  ;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "profilepic/"+ username + "/") + InputFileName2);
                
                        
                        //Save file to server folder  
                        data.pics1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "profilepic" }, StringSplitOptions.None);
                        string paths = httpurl + "/profilepic/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.profilepic = s;
                        //ci.pic1 = filename;
                        
                    }
                   if (data.pics2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pics2.FileName);
                       
                      
                        var InputFileName2 = num + Session["userid"].ToString()+InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "profilepic/" + username + "/") + InputFileName2);

                        //Save file to server folder  
                        data.pics2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "profilepic" }, StringSplitOptions.None);
                        string paths = httpurl + "/profilepic/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.logo = s;
                        //ci.pic2 = filename;
                        
                    }
                    
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;

                    db.tblcreateUsers.Add(ci);
                    db.SaveChanges();
                   

                    return Json(new { messege = "success" });

                    //return RedirectToAction("viewtblmaleGarment", "Home");
                }

                else
                {
                    // Session["checkchartname"] = "exist";
                    //  return RedirectToAction("viewtblmaleGarment", "Home");
                    return Json(new { messege = "exist" });

                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString();
                return Json(new { messege = "exception" });

                //return RedirectToAction("viewtblmaleGarment", "Home");
            }
        }
        public ActionResult addtblmaleGarment(tblmaleGarmentclass data)
        {
            tblmaleGarmentaction repo = new tblmaleGarmentaction();
            try
            {
                Random rnd = new Random();
                string filename = "";
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                var checkclothname = db.tblmaleGarments.Where(x => x.clothname == data.clothname.ToString()).FirstOrDefault();
                string ServerSavePath = "";
                if (checkclothname== null)
                {
                    tblmaleGarment ci = new tblmaleGarment();
                    ci.clothname = data.clothname;
                    ci.categoryid = data.categoryid;
                    if (data.shirtsizechartid != null)
                    {
                        ci.shirtsizechartid = data.shirtsizechartid.ToString();
                    }
                    if (data.pantsizechartid != null)
                    {
                        ci.pantsizechartid = data.pantsizechartid.ToString();
                    }
                        ci.xsmall = data.xsmall;
                    ci.small = data.small;
                    ci.medium = data.medium;
                    ci.large = data.large;
                    ci.xlarge = data.xlarge;
                    ci.xxlarge = data.xxlarge;
                    string keypath=ConfigurationManager.AppSettings["keypath"];
                    string httpurl= ConfigurationManager.AppSettings["httpurl"];

                    string path = @keypath +username;  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }

                    if (data.pic1 != null)

                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);
                 
                        var InputFileName2 = num + Session["userid"].ToString()+InputFileName  ;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "MaleGarments/"+ username + "/") + InputFileName2);
                
                        
                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "MaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/MaleGarments/"+ ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic1 = s;
                        //ci.pic1 = filename;
                        
                    }
                   if (data.pic2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic2.FileName);
                       
                      
                        var InputFileName2 = num + Session["userid"].ToString()+InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "MaleGarments/"+username + "/") + InputFileName2);

                        //Save file to server folder  
                        data.pic2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "MaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/MaleGarments/"+ ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic2 = s;
                        //ci.pic2 = filename;
                        
                    }
                    ci.price = data.price;
                    ci.detail = data.detail;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                    return Json(new { messege = "success" });

                    //return RedirectToAction("viewtblmaleGarment", "Home");
                }

                else
                {
                    // Session["checkchartname"] = "exist";
                    //  return RedirectToAction("viewtblmaleGarment", "Home");
                    return Json(new { messege = "exist" });

                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.Message.ToString();
                return Json(new { messege = "exception", exception = ex.Message.ToString() });

                //return RedirectToAction("viewtblmaleGarment", "Home");
            }
        }

        public ActionResult addtblMarket(string marketname)
        {
            tblmarket ci = new tblmarket();
            ci.marketName = marketname;
            ci.isActive = true;
            ci.createdDate = DateTime.Now;
            db.tblmarkets.Add(ci);
            return RedirectToAction("viewtblMarket", "Home");

        }

        public ActionResult addtblRole(string rolename)
        {
            tblrole ci = new tblrole();
            ci.roleName =rolename;
            ci.isActive = true;
            ci.createdDate = DateTime.Now;
            db.tblroles.Add(ci);
            return RedirectToAction("viewtblRole", "Home");

        }
        public ActionResult addtblShoptype(string shoptypename)
        {
            tblshoptype ci = new tblshoptype();
            ci.shoptypeName = shoptypename;
            ci.isActive = true;
            ci.createdDate = DateTime.Now;
            db.tblshoptypes.Add(ci);
            return RedirectToAction("viewtblShoptype", "Home");

        }
        public ActionResult addtblsizeShirtFemale(tblsizeShirtFemaleclass data)
        {
            tblsizeShirtFemaleaction ci = new tblsizeShirtFemaleaction();

            string result =ci.Add(data);
            if (result == "success")
            {
                return Json(new { messege = "success" });


            }
            else if (result == "fail")
            {
                return Json(new { messege = "exist" });


            }

            else 
            {
                Session["exception"] = result;
                return Json(new { messege = "exception", exception = result });
            }
           // return RedirectToAction("viewtblsizeShirtFemale", "Home");  

        }

        public ActionResult addtblsizePantFemale(tblsizePantFemaleclass data)
        {
            tblsizePantFemaleaction ci = new tblsizePantFemaleaction();

            ci.Add(data);
            return RedirectToAction("viewtblsizePantFemale", "Home");

        }

        public ActionResult addtblfemaleGarment(tblfemaleGarmentclass data)
        {
            tblfemaleGarmentaction repo = new tblfemaleGarmentaction();
            try
            {
                string filename = "";
                Random rnd = new Random();
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                string ServerSavePath = "";
                var checkclothname = db.tblfemaleGarments.Where(x => x.clothname == data.clothname.ToString()).FirstOrDefault();

                if (checkclothname == null)
                {
                    tblfemaleGarment ci = new tblfemaleGarment();
                    ci.clothname = data.clothname;
                    ci.categoryid = data.categoryid;
                    if (data.shirtsizechartnameid == null)
                    {
                        ci.shirtsizechartnameid = null;
                    }
                    else {
                        ci.shirtsizechartnameid = data.shirtsizechartnameid.ToString();
                    }
                    if (data.pantsizechartnameid == null)
                    {
                        ci.pantsizechartnameid = null;
                    }
                    else
                    {
                        ci.pantsizechartnameid = data.pantsizechartnameid.ToString();
                    }
                    ci.xsmall = data.xsmall;
                    ci.small = data.small;
                    ci.medium = data.medium;
                    ci.large = data.large;
                    ci.xlarge = data.xlarge;
                    ci.xxlarge = data.xxlarge;


                    string keypath = ConfigurationManager.AppSettings["keypathfemale"];
                    string httpurl = ConfigurationManager.AppSettings["httpurl"];

                    string path = @keypath + username;  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }

                    if (data.pic1 != null)

                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "FemaleGarments/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "FemaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/FemaleGarments/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic1 = s;
                        //ci.pic1 = filename;

                    }
                    if (data.pic2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic2.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "FemaleGarments/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "FemaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/FemaleGarments/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic2 = s;
                        //ci.pic2 = filename;

                    }
                    if (data.pic3 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic3.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "FemaleGarments/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic3.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "FemaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/FemaleGarments/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic3 = s;
                        //ci.pic2 = filename;

                    }
                    if (data.pic4 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic4.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "FemaleGarments/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic4.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "FemaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/FemaleGarments/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic4 = s;
                        //ci.pic2 = filename;

                    }
                    ci.price = data.price;
                    ci.detail = data.detail;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                    return Json(new { messege = "success" });
                    //return RedirectToAction("viewtblfemaleGarment", "Home");
                }

                else
                {
                    //Session["checkchartname"] = "exist";
                    //return RedirectToAction("viewtblfemaleGarment", "Home");
                    return Json(new { messege = "exception" });
                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("viewtblfemaleGarment", "Home");
            }
        }


        public ActionResult addtblShoe(tblshoeclass data)
        {
            tblfemaleGarmentaction repo = new tblfemaleGarmentaction();
            try
            {
                
                string filename = "";
                Random rnd = new Random();
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                string ServerSavePath = "";


                var checkclothname = db.tblshoes.Where(x => x.shoename == data.shoename.ToString()).FirstOrDefault();

                if (checkclothname == null)
                {
                    tblshoe ci = new tblshoe();
                    ci.shoename = data.shoename;
                    ci.categoryid = data.categoryid;
                    ci.sizechartname = data.shirtsizechartnameid;
                    ci.xsmall = data.xsmall;
                    ci.small = data.small;
                    ci.medium = data.medium;
                    ci.large = data.large;
                    ci.xlarge = data.xlarge;
                    ci.xxlarge = data.xxlarge;
                    ci.xxxlarge = data.xxxlarge;


                    string keypath = ConfigurationManager.AppSettings["keypathshoe"];
                    string httpurl = ConfigurationManager.AppSettings["httpurl"];

                    string path = @keypath + username;  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }

                    if (data.pic1 != null)

                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "Shoes/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "Shoes" }, StringSplitOptions.None);
                        string paths = httpurl + "/Shoes/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic1 = s;
                        //ci.pic1 = filename;

                    }
                    if (data.pic2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic2.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "Shoes/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "Shoes" }, StringSplitOptions.None);
                        string paths = httpurl + "/Shoes/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic2 = s;
                        //ci.pic2 = filename;

                    }
                    if (data.pic3 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic3.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "Shoes/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic3.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "Shoes" }, StringSplitOptions.None);
                        string paths = httpurl + "/Shoes/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic3 = s;
                        //ci.pic2 = filename;

                    }

                    ci.price = data.price;
                    ci.detail = data.detail;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    db.tblshoes.Add(ci);
                    db.SaveChanges();


                    return RedirectToAction("viewtblshoe", "Home");
                }

                else
                {
                    Session["checkchartname"] = "exist";
                    return RedirectToAction("viewtblshoe", "Home");

                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("viewtblshoe", "Home");
            }
        }

        public ActionResult addtblgeneral(tblgeneralclass data)
        {
            tblfemaleGarmentaction repo = new tblfemaleGarmentaction();
            try
            {

                string filename = "";
                Random rnd = new Random();
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                string ServerSavePath = "";


                var checkclothname = db.tblgenerals.Where(x => x.productname == data.productname.ToString()).FirstOrDefault();

                if (checkclothname == null)
                {
                    tblgeneral ci = new tblgeneral();
                    ci.productname = data.productname;

                    
                 


                    string keypath = ConfigurationManager.AppSettings["keypathgeneral"];
                    string httpurl = ConfigurationManager.AppSettings["httpurl"];

                    string path = @keypath + username;  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }

                    if(data.pic1 != null)

                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "Generals/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "Generals" }, StringSplitOptions.None);
                        string paths = httpurl + "/Generals/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic1 = s;
                        //ci.pic1 = filename;

                    }
                    if (data.pic2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic2.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "Generals/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "Generals" }, StringSplitOptions.None);
                        string paths = httpurl + "/Generals/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic2 = s;
                        //ci.pic2 = filename;

                    }
                    if (data.pic3 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic3.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "Generals/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic3.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "Generals" }, StringSplitOptions.None);
                        string paths = httpurl + "/Generals/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic3 = s;
                        //ci.pic2 = filename;

                    }

                    ci.price = data.price;
                    ci.detail = data.detail;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    db.tblgenerals.Add(ci);
                    db.SaveChanges();


                    return RedirectToAction("viewtblgeneral", "Home");
                }

                else
                {
                    //Session["checkchartname"] = "exist";
                    return RedirectToAction("viewtblgeneral", "Home");

                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("viewtblgeneral", "Home");
            }
        }
        //end
    }
}