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
    
    public partial class tblmarket
    {
        public int Personid { get; set; }
        public string marketName { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}