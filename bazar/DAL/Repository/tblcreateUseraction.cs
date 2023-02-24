using bazar.DAL.Contacts;
using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Repository
{
    public class tblcreateUseraction : IRepository<tblcreateUser>
    {
        bazarEntities db = new bazarEntities();

        public string Create(tblcreateUser sizeMale)
        {
            try
            {
                if (sizeMale != null)
                {

                    db.tblcreateUsers.Add(sizeMale);
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

                    var todo = db.tblcreateUsers.Where(x => x.id == id).FirstOrDefault();
                    db.tblcreateUsers.Remove(todo);
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
        public List<tblcreateUser> GetAll()
        {
            try
            {
                var checklist = db.tblcreateUsers.ToList();

                return checklist;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public tblcreateUser GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = db.tblcreateUsers.FirstOrDefault(x => x.id == id);

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
                    var todo = db.tblcreateUsers.Where(x => x.id == id).FirstOrDefault();
                    db.tblcreateUsers.Remove(todo);
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