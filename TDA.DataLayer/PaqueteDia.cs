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
    
    public partial class PaqueteDia
    {
        public long ID { get; set; }
        public Nullable<long> Paquete { get; set; }
        public Nullable<long> Dia { get; set; }
        public Nullable<long> UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<long> UsuarioMod { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
    
        public virtual Dia Dia1 { get; set; }
        public virtual Paquete Paquete1 { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
