using bazar.DAL.Contacts;
using bazar.DAL.Data;
using bazar.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblfemaleGarmentaction : IRepository<tblfemaleGarment>
    {
        bazarEntities db = new bazarEntities();

        
        

        public string Create(tblfemaleGarment sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblfemaleGarments.Add(sizeMale);
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

                    var todo = db.tblfemaleGarments.Where(x => x.id == id).FirstOrDefault();
                    db.tblfemaleGarments.Remove(todo);
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
        public List<tblfemaleGarment> GetAll()
        {
            try
            {
                var checklist = db.tblfemaleGarments.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblfemaleGarment GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblfemaleGarments.FirstOrDefault(x => x.id == id);

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
                    var todo = db.tblfemaleGarments.Where(x => x.id == id).FirstOrDefault();
                    db.tblfemaleGarments.Remove(todo);
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