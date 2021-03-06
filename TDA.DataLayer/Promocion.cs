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
    
    public partial class Promocion
    {
        public Promocion()
        {
            this.PromocionDia = new HashSet<PromocionDia>();
            this.PromocionPaquete = new HashSet<PromocionPaquete>();
            this.PromocionTipoProducto = new HashSet<PromocionTipoProducto>();
            this.PromocionProducto = new HashSet<PromocionProducto>();
            this.PromocionTipoCliente = new HashSet<PromocionTipoCliente>();
            this.VentaDetalle = new HashSet<VentaDetalle>();
        }
    
        public long ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<int> Comprar { get; set; }
        public Nullable<int> Pagar { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<bool> ParaPaquete { get; set; }
        public Nullable<bool> ParaTipoProducto { get; set; }
        public Nullable<bool> ParaProducto { get; set; }
        public Nullable<bool> ParaGrupoCliente { get; set; }
        public Nullable<long> UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<long> UsuarioMod { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
    
        public virtual ICollection<PromocionDia> PromocionDia { get; set; }
        public virtual ICollection<PromocionPaquete> PromocionPaquete { get; set; }
        public virtual ICollection<PromocionTipoProducto> PromocionTipoProducto { get; set; }
        public virtual ICollection<PromocionProducto> PromocionProducto { get; set; }
        public virtual ICollection<PromocionTipoCliente> PromocionTipoCliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
