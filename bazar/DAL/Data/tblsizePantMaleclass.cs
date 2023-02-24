using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblsizePantMaleclass
    {
        public int id { get; set; }
        public Nullable<int> xswaist { get; set; }
        public Nullable<int> xspantlength { get; set; }
        public Nullable<int> xssizename { get; set; }


        public Nullable<int> swaist { get; set; }
        public Nullable<int> spantlength { get; set; }
        public Nullable<int> ssizename { get; set; }


        public Nullable<int> mwaist { get; set; }
        public Nullable<int> mpantlength { get; set; }
        public Nullable<int> msizename { get; set; }


        public Nullable<int> lwaist { get; set; }
        public Nullable<int> lpantlength { get; set; }
        public Nullable<int> lsizename { get; set; }



        public Nullable<int> xlwaist { get; set; }
        public Nullable<int> xlpantlength { get; set; }
        public Nullable<int> xlsizename { get; set; }


        public string chartName { get; set; }
        public string unit { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}