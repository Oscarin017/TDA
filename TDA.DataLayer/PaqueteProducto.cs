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
    
    public partial class PaqueteProducto
    {
        public long ID { get; set; }
        public Nullable<long> Paquete { get; set; }
        public Nullable<long> Producto { get; set; }
    
        public virtual Paquete Paquete1 { get; set; }
        public virtual Producto Producto1 { get; set; }
    }
}
