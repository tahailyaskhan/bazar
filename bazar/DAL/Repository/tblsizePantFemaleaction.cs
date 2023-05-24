using bazar.DAL.Contacts;
using bazar.DAL.Data;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblsizePantFemaleaction : IRepository<tblsizePantFemale>
    {
        bazarEntities db = new bazarEntities();
        public string Add(tblsizePantFemaleclass data)
        {
            tblsizePantMaleaction repo = new tblsizePantMaleaction();
            try
            {
                var checkchart = db.tblsizePantMales.Where(x => x.chartName == data.chartName.ToString()).FirstOrDefault();

                if (checkchart == null)
                {
                    tblsizePantFemale ci = new tblsizePantFemale();
                    ci.waist = data.xswaist;
                    ci.hip = data.xship;
                    ci.thigh = data.xsthigh;
                    ci.bottom = data.xsbottom;
                    ci.pantlength = data.xspantlength;                 
                    ci.sizeName = "xsmall";
                    ci.createdById = 1;
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizePantFemales.Add(ci);
                    db.SaveChanges();


                    ci.waist = data.swaist;
                    ci.hip = data.ship;
                    ci.thigh = data.sthigh;
                    ci.bottom = data.xsbottom;
                    ci.pantlength = data.spantlength;
                    ci.sizeName = "small";                  
                    ci.createdById = 1;
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizePantFemales.Add(ci);
                    db.SaveChanges();


                    ci.waist = data.mwaist;
                    ci.hip = data.mhip;
                    ci.thigh = data.mthigh;
                    ci.bottom = data.mbottom;
                    ci.pantlength = data.mpantlength;
                    ci.sizeName = "medium";
                    ci.createdById = 1;
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    db.tblsizePantFemales.Add(ci);
                    db.SaveChanges();



                    ci.waist = data.lwaist;
                    ci.hip = data.lhip;
                    ci.thigh = data.lthigh;
                    ci.bottom = data.lbottom;
                    ci.pantlength = data.lpantlength;
                    ci.sizeName = "large";
                    ci.createdById = 1;
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizePantFemales.Add(ci);
                    db.SaveChanges();




                    ci.waist = data.xlwaist;
                    ci.hip = data.xlhip;
                    ci.thigh = data.xlthigh;
                    ci.bottom = data.xlbottom;
                    ci.pantlength = data.xlpantlength;
                    ci.sizeName = "xlarge";                    
                    ci.createdById = 1;
                    ci.unitId = "inches";
                    ci.chartName = data.chartName;
                    ci.createdDate = DateTime.Now;
                    db.tblsizePantFemales.Add(ci);
                    db.SaveChanges();


                    return "success";

                }
                else
                {
                    return "fail" ;

                }
            }
            catch (Exception ex)

            {
               
                return ex.InnerException.Message;
            }
        }
        public string Create(tblsizePantFemale sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblsizePantFemales.Add(sizeMale);
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
                return ex.ToString(); ;
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id != null)
                {

                    var todo = db.tblsizePantFemales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizePantFemales.Remove(todo);
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
        public List<tblsizePantFemale> GetAll()
        {
            try
            {
                var checklist = db.tblsizePantFemales.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblsizePantFemale GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblsizePantFemales.FirstOrDefault(x => x.id == id);

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
                    var todo = db.tblsizePantFemales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizePantFemales.Remove(todo);
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