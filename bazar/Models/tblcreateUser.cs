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
    
    public partial class tblcreateUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string addresss { get; set; }
        public string cnic { get; set; }
        public Nullable<int> shoptypeid { get; set; }
        public Nullable<int> marketid { get; set; }
        public Nullable<int> createdById { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string shopname { get; set; }
        public string profilepic { get; set; }
        public string logo { get; set; }
        public Nullable<int> roleid { get; set; }
    }
}
