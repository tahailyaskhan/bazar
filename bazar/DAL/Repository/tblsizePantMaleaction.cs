using bazar.DAL.Contacts;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblsizePantMaleaction : IRepository<tblsizePantMale>
    {
        bazarEntities db = new bazarEntities();

        public string Create(tblsizePantMale sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblsizePantMales.Add(sizeMale);
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

                    var todo = db.tblsizePantMales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizePantMales.Remove(todo);
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
        public List<tblsizePantMale> GetAll()
        {
            try
            {
                var checklist = db.tblsizePantMales.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblsizePantMale GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblsizePantMales.FirstOrDefault(x => x.id == id);

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
                    var todo = db.tblsizePantMales.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizePantMales.Remove(todo);
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