﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblmaleGarmentclass
    {
        public int id { get; set; }
        public Nullable<int> createdById { get; set; }
        public string clothname { get; set; }
        public Nullable<int> categoryid { get; set; }
        public string shirtsizechartid { get; set; }
        public string pantsizechartid { get; set; }


        public Nullable<bool> xsmall { get; set; }
        public Nullable<bool> small { get; set; }
        public Nullable<bool> medium { get; set; }
        public Nullable<bool> large { get; set; }
        public Nullable<bool> xlarge { get; set; }
        public Nullable<bool> xxlarge { get; set; }

        public string detail { get; set; }
        public string categoryname { get; set; }
        public Nullable<int> price { get; set; }

        public HttpPostedFileBase pic1 { get; set; }

        public HttpPostedFileBase pic2 { get; set; }

        public HttpPostedFileBase pics1 { get; set; }

        public HttpPostedFileBase pics2 { get; set; }

        public string pic11 { get; set; }

        public string pic22 { get; set; }
    }
}