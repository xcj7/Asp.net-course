//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shopbd
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblimage
    {
        public int iid { get; set; }
        public string iname { get; set; }
        public int pid { get; set; }
    
        public virtual tblpro tblpro { get; set; }
    }
}
