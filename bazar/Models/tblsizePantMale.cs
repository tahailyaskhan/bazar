//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bazar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblsizePantMale
    {
        public int id { get; set; }
        public Nullable<int> waist { get; set; }
        public Nullable<int> pantlength { get; set; }
        public string sizeName { get; set; }
        public string chartName { get; set; }
        public string unitId { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string abbreviation { get; set; }
    }
}