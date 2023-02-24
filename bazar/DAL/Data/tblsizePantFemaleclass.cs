using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblsizePantFemaleclass
    {
        public int id { get; set; }
        public Nullable<int> xswaist { get; set; }
        public Nullable<int> xship { get; set; }
        public Nullable<int> xsthigh { get; set; }
        public Nullable<int> xsbottom { get; set; }
        public Nullable<int> xspantlength { get; set; }

        public Nullable<int> swaist { get; set; }
        public Nullable<int> ship { get; set; }
        public Nullable<int> sthigh { get; set; }
        public Nullable<int> sbottom { get; set; }
        public Nullable<int> spantlength { get; set; }


        public Nullable<int> mwaist { get; set; }
        public Nullable<int> mhip { get; set; }
        public Nullable<int> mthigh { get; set; }
        public Nullable<int> mbottom { get; set; }
        public Nullable<int> mpantlength { get; set; }


        public Nullable<int> lwaist { get; set; }
        public Nullable<int> lhip { get; set; }
        public Nullable<int> lthigh { get; set; }
        public Nullable<int> lbottom { get; set; }
        public Nullable<int> lpantlength { get; set; }



        public Nullable<int> xlwaist { get; set; }
        public Nullable<int> xlhip { get; set; }
        public Nullable<int> xlthigh { get; set; }
        public Nullable<int> xlbottom { get; set; }
        public Nullable<int> xlpantlength { get; set; }


        public string sizeName { get; set; }
        public string chartName { get; set; }
        public string unitId { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}