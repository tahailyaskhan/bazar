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
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult updatetblmaleGarment(tblmaleGarmentclass data)
        {
            bazarEntities db = new bazarEntities();
            tblmaleGarmentaction repo = new tblmaleGarmentaction();
            try
            {
                Random rnd = new Random();
                int num = rnd.Next();
                string ServerSavePath = "";
                string filename = "";
                string username = Session["Username"].ToString();
                var ci = db.tblmaleGarments.Where(x => x.id == data.id).FirstOrDefault();

                //var checkclothname1 = db.tblmaleGarments.Where(x => x.id==data.id && x.clothname == data.clothname.ToString()).ToList();

                //if(checkclothname > 0 && checkclothname1==null)
                
               // if (checkclothname == null)
                {
                    
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

                    string keypath = ConfigurationManager.AppSettings["keypath"];
                    string httpurl = ConfigurationManager.AppSettings["httpurl"];

                     
                    //string path = @"C:\Users\Taha\source\repos\bazar\bazar\MaleGarments\" + "taha";  // Give the specific path  
                    //if (!(Directory.Exists(path)))
                    //{
                    //    Directory.CreateDirectory(path);

                    //}

                    if (data.pic1 != null)

                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);

                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "MaleGarments/" + username + "/") + InputFileName2);


                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "MaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/MaleGarments/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic1 = s;
                        //ci.pic1 = filename;

                    }
                    if (data.pic2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic2.FileName);


                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "MaleGarments/" + username + "/") + InputFileName2);

                        //Save file to server folder  
                        data.pic2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "MaleGarments" }, StringSplitOptions.None);
                        string paths = httpurl + "/MaleGarments/" + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic2 = s;
                        //ci.pic2 = filename;

                    }
                    ci.price = data.price;
                    ci.detail = data.detail;
                  
                    ci.createdDate = DateTime.Now;

                    db.SaveChanges();


                    TempData["success"] = "success";
                    return RedirectToAction("gettblmaleGarment", "Detail");
                }

                //else
                //{
                //    Session["checkchartname"] = "exist";
                //    return RedirectToAction("viewtblmaleGarment", "Home");

                //}
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("gettblmaleGarment", "Detail");
            }
        }


          public ActionResult updatetblfemaleGarment(tblfemaleGarmentclass data)
        {
            bazarEntities db = new bazarEntities();
            tblfemaleGarmentaction repo = new tblfemaleGarmentaction();
            try
            {
                
                string filename = "";
                Random rnd = new Random();
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                string ServerSavePath = "";

                var ci = db.tblfemaleGarments.Where(x => x.id == data.id).FirstOrDefault();

                //var checkclothname1 = db.tblmaleGarments.Where(x => x.id==data.id && x.clothname == data.clothname.ToString()).ToList();

                //if(checkclothname > 0 && checkclothname1==null)
                
               // if (checkclothname == null)
                {
                    
                    ci.clothname = data.clothname;
                    ci.categoryid = data.categoryid;
                    if (data.shirtsizechartnameid == null)
                    {
                        ci.shirtsizechartnameid = null;
                    }
                    else
                    {
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

                    //string path = @keypath + username;  // Give the specific path  
                    //if (!(Directory.Exists(path)))
                    //{
                    //    Directory.CreateDirectory(path);

                    //}

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
                  
                    ci.createdDate = DateTime.Now;

                    db.SaveChanges();
                    


                    return RedirectToAction("gettblfemaleGarment", "Detail");
                }

                //else
                //{
                //    Session["checkchartname"] = "exist";
                //    return RedirectToAction("viewtblmaleGarment", "Home");

                //}
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("gettblfemaleGarment", "Detail");
            }
        }

         public ActionResult updatetblshoe(tblshoeclass data)
        {
            bazarEntities db = new bazarEntities();
            tblfemaleGarmentaction repo = new tblfemaleGarmentaction();
            try
            {
              
                string filename = "";
                Random rnd = new Random();
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                string ServerSavePath = "";


                var ci = db.tblshoes.Where(x => x.id == data.id).FirstOrDefault();

                //var checkclothname1 = db.tblmaleGarments.Where(x => x.id==data.id && x.clothname == data.clothname.ToString()).ToList();

                //if(checkclothname > 0 && checkclothname1==null)
                
               // if (checkclothname == null)
                {
                    
                    ci.shoename = data.shoename;

                    ci.xsmall = data.xsmall;
                    ci.small = data.small;
                    ci.medium = data.medium;
                    ci.large = data.large;
                    ci.xlarge = data.xlarge;
                    ci.xxlarge = data.xxlarge;


                    string keypath = ConfigurationManager.AppSettings["keypathshoe"];
                    string httpurl = ConfigurationManager.AppSettings["httpurl"];

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
                 
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    
                    db.SaveChanges();



                    return RedirectToAction("gettblshoe", "Detail");
                }

                //else
                //{
                //    Session["checkchartname"] = "exist";
                //    return RedirectToAction("viewtblmaleGarment", "Home");

                //}
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("gettblshoe", "Detail");
            }
        }


          public ActionResult updatetblgeneral(tblgeneralclass data)
        {
            bazarEntities db = new bazarEntities();
           
            try
            {
              
                string filename = "";
                Random rnd = new Random();
                int num = rnd.Next();
                string username = Session["Username"].ToString();
                string ServerSavePath = "";


                var ci = db.tblgenerals.Where(x => x.id == data.id).FirstOrDefault();

                //var checkclothname1 = db.tblmaleGarments.Where(x => x.id==data.id && x.clothname == data.clothname.ToString()).ToList();

                //if(checkclothname > 0 && checkclothname1==null)
                
               // if (checkclothname == null)
                {
                    
                    ci.productname = data.productname;

               


                    string keypath = ConfigurationManager.AppSettings["keypathgeneral"];
                    string httpurl = ConfigurationManager.AppSettings["httpurl"];

                    if (data.pic1 != null)

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
                 
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    
                    db.SaveChanges();



                    return RedirectToAction("gettblgeneral", "Detail");
                }

                //else
                //{
                //    Session["checkchartname"] = "exist";
                //    return RedirectToAction("viewtblmaleGarment", "Home");

                //}
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("gettblgeneral", "Detail");
            }
        }





        //end
    }
}