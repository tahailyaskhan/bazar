using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tbluserclass
    {

        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string addresss { get; set; }
        public string cnic { get; set; }
        public Nullable<int> shoptypeid { get; set; }
        public Nullable<int> marketid { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string shopname { get; set; }
        public string profilepic { get; set; }
        public string logo { get; set; }
        public Nullable<int> roleid { get; set; }
    }
}