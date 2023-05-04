using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblgeneralclass
    {
        public int id { get; set; }
        public string productname { get; set; }
        public Nullable<int> categoryid { get; set; }
        public string pic11 { get; set; }
        public string pic22 { get; set; }
        public string pic33 { get; set; }


        public HttpPostedFileBase pic1 { get; set; }
        public HttpPostedFileBase pic2 { get; set; }
        public HttpPostedFileBase pic3 { get; set; }

        public string detail { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}