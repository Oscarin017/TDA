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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Cliente = new HashSet<Cliente>();
            this.Cliente1 = new HashSet<Cliente>();
            this.Color = new HashSet<Color>();
            this.Color1 = new HashSet<Color>();
            this.Empleado1 = new HashSet<Empleado>();
            this.Empleado2 = new HashSet<Empleado>();
            this.Estado = new HashSet<Estado>();
            this.Estado1 = new HashSet<Estado>();
            this.GrupoCliente = new HashSet<GrupoCliente>();
            this.GrupoCliente1 = new HashSet<GrupoCliente>();
            this.Logs = new HashSet<Logs>();
            this.Marca = new HashSet<Marca>();
            this.Marca1 = new HashSet<Marca>();
            this.Modelo = new HashSet<Modelo>();
            this.Modelo1 = new HashSet<Modelo>();
            this.Movimiento = new HashSet<Movimiento>();
            this.Movimiento1 = new HashSet<Movimiento>();
            this.Pais = new HashSet<Pais>();
            this.Pais1 = new HashSet<Pais>();
            this.Paquete = new HashSet<Paquete>();
            this.Paquete1 = new HashSet<Paquete>();
            this.PaqueteDia = new HashSet<PaqueteDia>();
            this.PaqueteDia1 = new HashSet<PaqueteDia>();
            this.Producto = new HashSet<Producto>();
            this.Producto1 = new HashSet<Producto>();
            this.Promocion = new HashSet<Promocion>();
            this.Promocion1 = new HashSet<Promocion>();
            this.PromocionDia = new HashSet<PromocionDia>();
            this.PromocionDia1 = new HashSet<PromocionDia>();
            this.Proveedor = new HashSet<Proveedor>();
            this.Proveedor1 = new HashSet<Proveedor>();
            this.TipoMovimiento = new HashSet<TipoMovimiento>();
            this.TipoMovimiento1 = new HashSet<TipoMovimiento>();
            this.TipoProducto = new HashSet<TipoProducto>();
            this.TipoProducto1 = new HashSet<TipoProducto>();
            this.Usuario1 = new HashSet<Usuario>();
            this.Usuario11 = new HashSet<Usuario>();
            this.Vehiculo = new HashSet<Vehiculo>();
            this.Vehiculo1 = new HashSet<Vehiculo>();
            this.Venta = new HashSet<Venta>();
        }
    
        public long ID { get; set; }
        public string Alias { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public Nullable<long> Rol { get; set; }
        public Nullable<long> UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<long> UsuarioMod { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public Nullable<long> Empleado { get; set; }
    
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Cliente> Cliente1 { get; set; }
        public virtual ICollection<Color> Color { get; set; }
        public virtual ICollection<Color> Color1 { get; set; }
        public virtual ICollection<Empleado> Empleado1 { get; set; }
        public virtual ICollection<Empleado> Empleado2 { get; set; }
        public virtual Empleado Empleado3 { get; set; }
        public virtual ICollection<Estado> Estado { get; set; }
        public virtual ICollection<Estado> Estado1 { get; set; }
        public virtual ICollection<GrupoCliente> GrupoCliente { get; set; }
        public virtual ICollection<GrupoCliente> GrupoCliente1 { get; set; }
        public virtual ICollection<Logs> Logs { get; set; }
        public virtual ICollection<Marca> Marca { get; set; }
        public virtual ICollection<Marca> Marca1 { get; set; }
        public virtual ICollection<Modelo> Modelo { get; set; }
        public virtual ICollection<Modelo> Modelo1 { get; set; }
        public virtual ICollection<Movimiento> Movimiento { get; set; }
        public virtual ICollection<Movimiento> Movimiento1 { get; set; }
        public virtual ICollection<Pais> Pais { get; set; }
        public virtual ICollection<Pais> Pais1 { get; set; }
        public virtual ICollection<Paquete> Paquete { get; set; }
        public virtual ICollection<Paquete> Paquete1 { get; set; }
        public virtual ICollection<PaqueteDia> PaqueteDia { get; set; }
        public virtual ICollection<PaqueteDia> PaqueteDia1 { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Producto> Producto1 { get; set; }
        public virtual ICollection<Promocion> Promocion { get; set; }
        public virtual ICollection<Promocion> Promocion1 { get; set; }
        public virtual ICollection<PromocionDia> PromocionDia { get; set; }
        public virtual ICollection<PromocionDia> PromocionDia1 { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<Proveedor> Proveedor1 { get; set; }
        public virtual Rol Rol1 { get; set; }
        public virtual ICollection<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual ICollection<TipoMovimiento> TipoMovimiento1 { get; set; }
        public virtual ICollection<TipoProducto> TipoProducto { get; set; }
        public virtual ICollection<TipoProducto> TipoProducto1 { get; set; }
        public virtual ICollection<Usuario> Usuario1 { get; set; }
        public virtual Usuario Usuario2 { get; set; }
        public virtual ICollection<Usuario> Usuario11 { get; set; }
        public virtual Usuario Usuario3 { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo1 { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
