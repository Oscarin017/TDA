//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TDA.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Logs
    {
        public long ID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Descripcion { get; set; }
        public Nullable<long> Usuario { get; set; }
    
        public virtual Usuario Usuario1 { get; set; }
    }
}
