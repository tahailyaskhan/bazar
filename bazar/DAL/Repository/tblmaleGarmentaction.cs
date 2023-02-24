using bazar.DAL.Contacts;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblmaleGarmentaction : IRepository<tblmaleGarment>
    {
        bazarEntities db = new bazarEntities();

        public string Create(tblmaleGarment sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblmaleGarments.Add(sizeMale);
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

                    var todo = db.tblmaleGarments.Where(x => x.id == id).FirstOrDefault();
                    db.tblmaleGarments.Remove(todo);
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
        public List<tblmaleGarment> GetAll()
        {
            try
            {
                var checklist = db.tblmaleGarments.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblmaleGarment GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblmaleGarments.FirstOrDefault(x => x.id == id);

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
                    var todo = db.tblmaleGarments.Where(x => x.id == id).FirstOrDefault();
                    db.tblmaleGarments.Remove(todo);
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