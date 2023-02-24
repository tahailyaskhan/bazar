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

        public IEnumerable<serachMaleGarment_Result> spMaleGarmmentList { get; set; }
        public IEnumerable<serachFemaleGarment_Result> spFemaleGarmmentList { get; set; }
    }
}