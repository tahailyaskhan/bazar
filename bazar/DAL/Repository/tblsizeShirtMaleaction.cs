using bazar.DAL.Contacts;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblsizeShirtMaleaction : IRepository<tblsizeShirtMale>
    {
        bazarEntities db = new bazarEntities();

        public string Create (tblsizeShirtMale sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {
                    
                     db.tblsizeShirtMales.Add(sizeMale);
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

                    var todo = db.tblsizeShirtMales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizeShirtMales.Remove(todo);
                    db.SaveChanges();

                    return "success";
                }
                else {
                    return "failed";
                }
            }
            catch (Exception)
            {
                return "failed";
            }
        }
        public List<tblsizeShirtMale> GetAll()
        {
            try
            {
                var checklist = db.tblsizeShirtMales.ToList();
                
                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblsizeShirtMale GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblsizeShirtMales.FirstOrDefault(x => x.id == id);
                    
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
                    var todo = db.tblsizeShirtMales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizeShirtMales.Remove(todo);
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
                return  ex.ToString();
            }
        }
    }
}