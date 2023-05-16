using bazar.DAL.Contacts;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblsizeShoaction : IRepository<tblsizeShoe>
    {
        bazarEntities db = new bazarEntities();

        public string Create(tblsizeShoe sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblsizeShoes.Add(sizeMale);
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

                    var todo = db.tblsizeShoes.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizeShoes.Remove(todo);
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
        public List<tblsizeShoe> GetAll()
        {
            try
            {
                var checklist = db.tblsizeShoes.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblsizeShoe GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblsizeShoes.FirstOrDefault(x => x.id == id);

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
                    var todo = db.tblsizeShoes.Where(x => x.id == id).FirstOrDefault();
                    db.tblsizeShoes.Remove(todo);
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