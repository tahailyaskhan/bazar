using bazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class viewmodel
    {
        public IEnumerable<tblmaleGarment> maleGarmmentList { get; set; }
        public IEnumerable<tblfemaleGarment> femaleGarmmentList { get; set; }
        public IEnumerable<tblshoe> shoeList { get; set; }
        public IEnumerable<tblcreateUser> userList { get; set; }

        public IEnumerable<tblsizeShirtMale> maleShirtSizeList { get; set; }
        public IEnumerable<tblsizeShirtFemale> femaleShirtSizeList { get; set; }
        public IEnumerable<tblsizePantMale> malePantSizeList { get; set; }
        public IEnumerable<tblsizePantFemale> femalePantSizeList { get; set; }

        public tblmaleGarment maleGarmentObj { get; set; }
        public tblfemaleGarment femaleGarmentObj { get; set; }

        public tblshoe shoeObj { get; set; }

        public IEnumerable<serachMaleGarment_Result> spMaleGarmmentList { get; set; }
        public IEnumerable<serachFemaleGarment_Result> spFemaleGarmmentList { get; set; }
        public IEnumerable<serachShoe_Result> spShoeList { get; set; }
        public IEnumerable<serachUser_Result> spUserList { get; set; }
        public IEnumerable<getCustomerReviews_Result> spGetCustomerReviews { get; set; }
    }
}