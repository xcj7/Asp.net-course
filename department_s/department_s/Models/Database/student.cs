//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace department_s.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        public int s_id { get; set; }
        public string s_name { get; set; }
        public int dep_id { get; set; }
    
        public virtual department department { get; set; }
    }
}
