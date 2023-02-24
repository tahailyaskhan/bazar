using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblcustomerorder
    {
        public int id { get; set; }
        public Nullable<int> orderId { get; set; }
        public Nullable<int> counts { get; set; }
        public string addresss { get; set; }
        public string cityname { get; set; }
        public string clothname { get; set; }
        public string pic { get; set; }
        public string size { get; set; }
        public string mobileNo { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
        public string reviews { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> customerId { get; set; }
        public Nullable<int> ownerId { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}