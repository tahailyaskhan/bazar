using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class userclass
    {
        public string MyProperty { get; set; }


         public int  id             { get; set; }  
         public string   username       { get; set; }
         public string   email          { get; set; }
         public string   password       { get; set; }
         public string   cnic           { get; set; }

                public string   address     { get; set; }
         public string   shopname       { get; set; }
         public string   profilepic     { get; set; }
        public string shoptype { get; set; }
        public string market { get; set; }
        public string role { get; set; }
        public string logo { get; set; }


        public int shoptypeid { get; set; }
        public int marketid { get; set; }
        public int roleid { get; set; }
        public HttpPostedFileBase pics1 { get; set; }
        public HttpPostedFileBase pics2 { get; set; }


    }
}