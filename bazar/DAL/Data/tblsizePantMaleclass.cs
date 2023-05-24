using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblsizePantMaleclass
    {
        public int id { get; set; }
        public string xswaist { get; set; }
        public string xspantlength { get; set; }
        public string xssizename { get; set; }


        public string swaist { get; set; }
        public string spantlength { get; set; }
        public string ssizename { get; set; }


        public string mwaist { get; set; }
        public string mpantlength { get; set; }
        public string msizename { get; set; }


        public string lwaist { get; set; }
        public string lpantlength { get; set; }
        public string lsizename { get; set; }



        public string xlwaist { get; set; }
        public string xlpantlength { get; set; }
        public string xlsizename { get; set; }


        public string chartName { get; set; }
        public string unit { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}