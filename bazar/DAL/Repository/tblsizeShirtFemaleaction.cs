using bazar.DAL.Contacts;
using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblsizeShirtFemaleaction : IRepository<tblsizeShirtFemale>
    {
        bazarEntities db = new bazarEntities();

        public string Add(tblsizeShirtFemaleclass data)
        {
            try
            {
                var checkchart = db.tblsizeShirtFemales.Where(x => x.chartName == data.chartName.ToString()).FirstOrDefault();

                if (checkchart == null)
                {
                    tblsizeShirtFemale ci = new tblsizeShirtFemale();
                    ci.shoulder = data.xsshoulder;
                    ci.chest = data.xschest;
                    ci.sleeveLength = data.xssleeveLength;
                    ci.shirtLength = data.xsshirtLength;
                    ci.sleeveopening = data.xssleeveopening;
                    ci.daman = data.xsdaman;
                    ci.armhole = data.xsarmhole;
                    ci.sizeName = "xsmall";
                    ci.createdById = Convert.ToInt32(System.Web.HttpContext.Current.Session["userid"]);
                    ci.unitId = data.unitId;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShirtFemales.Add(ci);
                    db.SaveChanges();


                    ci.shoulder = data.sshoulder;
                    ci.chest = data.schest;
                    ci.sleeveLength = data.ssleeveLength;
                    ci.shirtLength = data.sshirtLength;
                    ci.sleeveopening = data.ssleeveopening;
                    ci.daman = data.sdaman;
                    ci.armhole = data.sarmhole;
                    ci.sizeName = "small";
                    ci.createdById = Convert.ToInt32(System.Web.HttpContext.Current.Session["userid"]);
                    ci.unitId = data.unitId;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShirtFemales.Add(ci);
                    db.SaveChanges();


                    ci.shoulder = data.mshoulder;
                    ci.chest = data.mchest;
                    ci.sleeveLength = data.msleeveLength;
                    ci.shirtLength = data.mshirtLength;
                    ci.sleeveopening = data.msleeveopening;
                    ci.daman = data.mdaman;
                    ci.armhole = data.marmhole;
                    ci.sizeName = "medium";
                    ci.createdById = Convert.ToInt32(System.Web.HttpContext.Current.Session["userid"]);
                    ci.unitId = data.unitId;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShirtFemales.Add(ci);
                    db.SaveChanges();



                    ci.shoulder = data.lshoulder;
                    ci.chest = data.lchest;
                    ci.sleeveLength = data.lsleeveLength;
                    ci.shirtLength = data.lshirtLength;
                    ci.sleeveopening = data.lsleeveopening;
                    ci.daman = data.ldaman;
                    ci.armhole = data.larmhole;
                    ci.sizeName = "large";
                    ci.createdById = Convert.ToInt32(System.Web.HttpContext.Current.Session["userid"]);
                    ci.unitId = data.unitId;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShirtFemales.Add(ci);
                    db.SaveChanges();

                    ci.shoulder = data.xlshoulder;
                    ci.chest = data.xlchest;
                    ci.sleeveLength = data.xlsleeveLength;
                    ci.shirtLength = data.xlshirtLength;
                    ci.sleeveopening = data.xlsleeveopening;
                    ci.daman = data.xldaman;
                    ci.armhole = data.xlarmhole;
                    ci.sizeName = "xlarge";
                    ci.createdById = Convert.ToInt32(System.Web.HttpContext.Current.Session["userid"]);
                    ci.unitId = data.unitId;
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizeShirtFemales.Add(ci);
                    db.SaveChanges();

                    return "success";
                }

                else
                {

                    return "fail";

                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public string Create(tblsizeShirtFemale sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblsizeShirtFemales.Add(sizeMale);
                    db.SaveChanges();


                    return "success";

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString(); 
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id != null)
                {

                    var todo = db.tblsizeShirtFemales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizeShirtFemales.Remove(todo);
                    db.SaveChanges();

                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception)
            {
                return "failed";
            }
        }
        public List<tblsizeShirtFemale> GetAll()
        {
            try
            {
                var checklist = db.tblsizeShirtFemales.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblsizeShirtFemale GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblsizeShirtFemales.FirstOrDefault(x => x.id == id);

                    if (Obj != null)
                    {
                        return Obj;

                    }
                    else
                    {

                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Update(int id)
        {
            try
            {
                if (id != null)
                {
                    var todo = db.tblsizeShirtFemales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizeShirtFemales.Remove(todo);
                    db.SaveChanges();
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}