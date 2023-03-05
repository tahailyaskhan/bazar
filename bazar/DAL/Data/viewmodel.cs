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
        public IEnumerable<tblcategory> categorylist { get; set; }
        public IEnumerable<tblsizeShirtMale> tblsizeShirtMalelist { get; set; }
        public IEnumerable<tblsizePantMale> tblsizePantMalelist { get; set; }
        public IEnumerable<tblsizeShirtFemale> tblsizeShirtFemalelist { get; set; }
        public IEnumerable<tblsizePantFemale> tblsizePantFemalelist { get; set; }
       
        public tblmaleGarment maleGarmmentobj { get; set; }
        public tblfemaleGarment femaleGarmmentobj { get; set; }
        public tblshoe shoeobj { get; set; }

        public IEnumerable<serachMaleGarment_Result> spMaleGarmmentList { get; set; }
        public IEnumerable<serachFemaleGarment_Result> spFemaleGarmmentList { get; set; }

        public IEnumerable<serachShoes_Result> spShoeList { get; set; }
    }
}