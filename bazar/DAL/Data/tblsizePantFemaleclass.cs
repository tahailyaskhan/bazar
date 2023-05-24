using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblsizePantFemaleclass
    {
        public int id { get; set; }
        public string xswaist { get; set; }
        public string xship { get; set; }
        public string xsthigh { get; set; }
        public string xsbottom { get; set; }
        public string xspantlength { get; set; }

        public string swaist { get; set; }
        public string ship { get; set; }
        public string sthigh { get; set; }
        public string sbottom { get; set; }
        public string spantlength { get; set; }


        public string mwaist { get; set; }
        public string mhip { get; set; }
        public string mthigh { get; set; }
        public string mbottom { get; set; }
        public string mpantlength { get; set; }


        public string lwaist { get; set; }
        public string lhip { get; set; }
        public string lthigh { get; set; }
        public string lbottom { get; set; }
        public string lpantlength { get; set; }



        public string xlwaist { get; set; }
        public string xlhip { get; set; }
        public string xlthigh { get; set; }
        public string xlbottom { get; set; }
        public string xlpantlength { get; set; }


        public string sizeName { get; set; }
        public string chartName { get; set; }
        public string unitId { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}