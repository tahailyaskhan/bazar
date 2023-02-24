using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblsizeShirtMaleField
    {

        public int id { get; set; }
        public Nullable<int> xscollar { get; set; }
        public Nullable<int> xschest { get; set; }
        public Nullable<int> xssleeveLength { get; set; }
        public Nullable<int> xsshirtLength { get; set; }
        public string xssizeNamxse { get; set; }

       
        public Nullable<int> scollar { get; set; }
        public Nullable<int> schest { get; set; }
        public Nullable<int> ssleeveLength { get; set; }
        public Nullable<int> sshirtLength { get; set; }
        public string ssizeNamse { get; set; }



        
        public Nullable<int> mcollar { get; set; }
        public Nullable<int> mchest { get; set; }
        public Nullable<int> msleeveLength { get; set; }
        public Nullable<int> mshirtLength { get; set; }
        public string msizeNamme { get; set; }

        
        public Nullable<int> lcollar { get; set; }
        public Nullable<int> lchest { get; set; }
        public Nullable<int> lsleeveLength { get; set; }
        public Nullable<int> lshirtLength { get; set; }
        public string lsizeNamle { get; set; }




       
        public Nullable<int> xlcollar { get; set; }
        public Nullable<int> xlchest { get; set; }
        public Nullable<int> xlsleeveLength { get; set; }
        public Nullable<int> xlshirtLength { get; set; }
        public string xlsizeNamxle { get; set; }

        public string chartName { get; set; }
        public string unit { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}