using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class tblsizeShirtFemaleclass
    {
        public int id { get; set; }
        public Nullable<int> xsshoulder { get; set; }
        public Nullable<int> xschest { get; set; }
        public Nullable<int> xsarmhole { get; set; }
        public Nullable<int> xssleeveLength { get; set; }
        public Nullable<int> xssleeveopening { get; set; }
        public Nullable<int> xsshirtLength { get; set; }
        public Nullable<int> xsdaman { get; set; }


        public Nullable<int> sshoulder { get; set; }
        public Nullable<int> schest { get; set; }
        public Nullable<int> sarmhole { get; set; }
        public Nullable<int> ssleeveLength { get; set; }
        public Nullable<int> ssleeveopening { get; set; }
        public Nullable<int> sshirtLength { get; set; }
        public Nullable<int> sdaman { get; set; }


        public Nullable<int> mshoulder { get; set; }
        public Nullable<int> mchest { get; set; }
        public Nullable<int> marmhole { get; set; }
        public Nullable<int> msleeveLength { get; set; }
        public Nullable<int> msleeveopening { get; set; }
        public Nullable<int> mshirtLength { get; set; }
        public Nullable<int> mdaman { get; set; }


        public Nullable<int> lshoulder { get; set; }
        public Nullable<int> lchest { get; set; }
        public Nullable<int> larmhole { get; set; }
        public Nullable<int> lsleeveLength { get; set; }
        public Nullable<int> lsleeveopening { get; set; }
        public Nullable<int> lshirtLength { get; set; }
        public Nullable<int> ldaman { get; set; }


        public Nullable<int> xlshoulder { get; set; }
        public Nullable<int> xlchest { get; set; }
        public Nullable<int> xlarmhole { get; set; }
        public Nullable<int> xlsleeveLength { get; set; }
        public Nullable<int> xlsleeveopening { get; set; }
        public Nullable<int> xlshirtLength { get; set; }
        public Nullable<int> xldaman { get; set; }

        public string sizeName { get; set; }
        public string chartName { get; set; }
        public string unitId { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}