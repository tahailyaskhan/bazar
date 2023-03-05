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
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);



                    ci.collar = data.scollar;
                    ci.chest = data.schest;
                    ci.sleeveLength = data.ssleeveLength;
                    ci.shirtLength = data.sshirtLength;
                    ci.sizeName = "small";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.collar = data.mcollar;
                    ci.chest = data.mchest;
                    ci.sleeveLength = data.msleeveLength;
                    ci.shirtLength = data.mshirtLength;
                    ci.sizeName = "medium";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);



                    ci.collar = data.lcollar;
                    ci.chest = data.lchest;
                    ci.sleeveLength = data.lsleeveLength;
                    ci.shirtLength = data.lshirtLength;
                    ci.sizeName = "large";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                    ci.collar = data.xlcollar;
                    ci.chest = data.xlchest;
                    ci.sleeveLength = data.xlsleeveLength;
                    ci.shirtLength = data.xlshirtLength;
                    ci.sizeName = "xllarge";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                  
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    Session["checkchartname"] = "exist";
                    return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("Index", "Home");
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
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.waist = data.swaist;
                    ci.sizeName = "small";
                    ci.pantlength = data.spantlength;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.waist = data.mwaist;
                    ci.pantlength = data.mpantlength;
                    ci.sizeName = "medium";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    ci.waist = data.lwaist;
                    ci.pantlength = data.lpantlength;
                    ci.sizeName = "large";
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);



                    ci.waist = data.xlwaist;
                    ci.sizeName = "xlarge";
                    ci.pantlength = data.xlpantlength;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.unitId = data.unit;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);

                    return RedirectToAction("viewtblsizePantMale", "Home");

                }
                else
                {
                    Session["checkchartname"] = "exist";
                    return RedirectToAction("viewtblsizePantMale", "Home");

                }
            }
            catch (Exception ex)

            {
                Session["exception"] = ex.InnerException.ToString();
                return View();
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


                    string path = @"C:\Users\Taha\source\repos\bazar\bazar\MaleGarments\" +username;  // Give the specific path  
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
                        string paths = "https://localhost:44326" + "/MaleGarments/"+username + ImgPath[1];
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
                        string paths = "https://localhost:44326" + "/MaleGarments/"+username + ImgPath[1];
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


                    return RedirectToAction("viewtblmaleGarment", "Home");
                }

                else
                {
                    Session["checkchartname"] = "exist";
                    return RedirectToAction("viewtblmaleGarment", "Home");

                }
            }
            catch (Exception ex)
            {

                Session["exception"] = ex.InnerException.ToString(); ;
                return RedirectToAction("viewtblmaleGarment", "Home");
            }
        }



        public ActionResult addtblsizeShirtFemale(tblsizeShirtFemaleclass data)
        {
            tblsizeShirtFemaleaction ci = new tblsizeShirtFemaleaction();

            ci.Add(data);
            return RedirectToAction("viewtblsizeShirtFemale", "Home");  

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
                Random rnd = new Random();
                string filename = "";
                string ServerSavePath = "";
                int num = rnd.Next();
                string username = Session["Username"].ToString();
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


                    //string path = @"C:\Users\Taha\source\repos\bazar\bazar\MaleGarments\" + "female"+@"\";  // Give the specific path  
                    //if (!(Directory.Exists(path)))
                    //{
                    //    Directory.CreateDirectory(path);

                    //}

                    string path = @"C:\Users\Taha\source\repos\bazar\bazar\FemaleGarments\" + username;  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }
                    //C:\\Users\\Taha\\source\\repos\\bazar\\bazar\\female\\Capture8.PNG

                    if (data.pic1 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);


                        var InputFileName2 = num + Session["userid"].ToString() + InputFileName;
                        ServerSavePath = Path.Combine(Server.MapPath("~/" + "FeFemaleGarments/" + username + "/") + InputFileName2);

                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;

                        string[] ImgPath = filename.Split(new[] { "FemaleGarments" }, StringSplitOptions.None);
                        string paths = "https://localhost:44326" + "/FemaleGarments/" + username + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic1 = s;

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
                        string paths = "https://localhost:44326" + "/FemaleGarments/" + username + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic2 = s;

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
                        string paths = "https://localhost:44326" + "/FemaleGarments/" + username + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic3 = s;

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
                        string paths = "https://localhost:44326" + "/FemaleGarments/" + username + ImgPath[1];
                        string s = paths.Replace("\\", "/");
                        ci.pic4 = s;
                    }
                    ci.price = data.price;
                    ci.detail = data.detail;
                    ci.createdById = Convert.ToInt32(Session["userid"]);
                    ci.isActive = true;
                    ci.createdDate = DateTime.Now;
                    repo.Create(ci);


                    return RedirectToAction("viewtblfemaleGarment", "Home");
                }

                else
                {
                    Session["checkchartname"] = "exist";
                    return RedirectToAction("viewtblfemaleGarment", "Home");

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
                var checkclothname = db.tblshoes.Where(x => x.shoename == data.shoename.ToString()).FirstOrDefault();

                if (checkclothname == null)
                {
                    tblshoe ci = new tblshoe();
                    ci.shoename = data.shoename;
                
                    ci.xsmall = data.xsmall;
                    ci.small = data.small;
                    ci.medium = data.medium;
                    ci.large = data.large;
                    ci.xlarge = data.xlarge;
                    ci.xxlarge = data.xxlarge;


                    string path = @"C:\Users\Taha\source\repos\bazar\bazar\MaleGarments\" + "taha";  // Give the specific path  
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);

                    }

                    if (data.pic1 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic1.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/" + "taha" + "/") + InputFileName);
                        //Save file to server folder  
                        data.pic1.SaveAs(ServerSavePath);
                        filename = ServerSavePath;
                        ci.pic1 = filename;

                    }
                    if (data.pic2 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic2.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/" + "taha" + "/") + InputFileName);
                        //Save file to server folder  
                        data.pic2.SaveAs(ServerSavePath);
                        filename = ServerSavePath;
                        ci.pic2 = filename;

                    }

                    if (data.pic3 != null)
                    {
                        var InputFileName = Path.GetFileName(data.pic3.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/" + "taha" + "/") + InputFileName);
                        //Save file to server folder  
                        data.pic3.SaveAs(ServerSavePath);
                        filename = ServerSavePath;
                        ci.pic3= filename;

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
        //end
    }
}