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
    
    public partial class tblorder
    {
        public tblorder()
        {
            this.tblorderdetails = new HashSet<tblorderdetail>();
        }
    
        public int oid { get; set; }
        public string odate { get; set; }
        public string opname { get; set; }
        public string opphone { get; set; }
        public string opaddress { get; set; }
        public string opsaddress { get; set; }
        public int oamount { get; set; }
        public int ostatus { get; set; }
    
        public virtual ICollection<tblorderdetail> tblorderdetails { get; set; }
    }
}