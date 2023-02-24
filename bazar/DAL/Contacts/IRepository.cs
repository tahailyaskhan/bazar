using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bazar.DAL.Contacts
{
     public interface IRepository<T>
    {
         string Create(T _object);
         string Delete(int _object);
         string Update(int _object);
         List<T> GetAll();
         T GetById(int Id);
    }
}
