using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDA.DataLayer;
using TDA.Entities;

namespace TDA.Service
{
    class TDAService : ITDAService
    {
        private DataLayer.DataAccess _dataBaseTool = new DataLayer.DataAccess();
        #region Tabla Configuraciones
        public List<Configuraciones> SelectConfiguracion()
        {
            return _dataBaseTool.SelectConfiguracion();
        }
        #endregion
        
        #region Tabla Rol
        public List<Roles> SelectRol() {
            return _dataBaseTool.SelectRol();
        }
        #endregion

        #region Tabla Pagina
        public List<Paginas> SelectPagina()
        {
            return _dataBaseTool.SelectPagina();
        }
        #endregion

        #region Tabla Rol Pagina
        public List<RolPaginas> SelectRolPagina()
        {
            return _dataBaseTool.SelectRolPagina();
        }
        #endregion

        #region Tabla Base Salario
        public List<BaseSalarios> SelectBaseSalario()
        {
            return _dataBaseTool.SelectBaseSalario();
        }
        #endregion

        #region Tabla  Dia
        public List<Dias> SelectDia()
        {
            return _dataBaseTool.SelectDia();
        }
        #endregion

        #region Tabla  Tipo Identificacion
        public List<TipoIdentificaciones> SelectTipoIdentificacion()
        {
            return _dataBaseTool.SelectTipoIdentificacion();
        }
        #endregion

        #region Tabla Usuario
        public Resultado InsertUsuario(Usuarios usu)
        {
            return _dataBaseTool.InsertUsuario(usu);
        }
        public Resultado UpdateUsuario(Usuarios usu)
        {
            return _dataBaseTool.UpdateUsuario(usu);
        }
        public List<Usuarios> SelectUsuario()
        {
            return _dataBaseTool.SelectUsuarios();
        }

        #endregion

        #region Tabla  Pais
        public Resultado InsertPais(Paises pai)
        {
            return _dataBaseTool.InsertPais(pai);
        }
        public Resultado UpdatePais(Paises pai)
        {
            return _dataBaseTool.UpdatePais(pai);
        }
        public Resultado DeletePais(Paises pai)
        {
            return _dataBaseTool.DeletePais(pai);
        }
        public List<Paises> SelectPais()
        {
            return _dataBaseTool.SelectPais();
        }
        #endregion

        #region Tabla  Estado
        public Resultado InsertEstado(Estados est)
        {
            return _dataBaseTool.InsertEstado(est);
        }
        public Resultado UpdateEstado(Estados est)
        {
            return _dataBaseTool.UpdateEstado(est);
        }
        public List<Estados> SelectEstado()
        {
            return _dataBaseTool.SelectEstado();
        }
        #endregion

        #region Tabla  Marca
        public Resultado InsertMarca(Marcas mar)
        {
            return _dataBaseTool.InsertMarca(mar);
        }
        public Resultado UpdateMarca(Marcas mar)
        {
            return _dataBaseTool.UpdateMarca(mar);
        }
        public Resultado DeleteMarca(Marcas mar)
        {
            return _dataBaseTool.DeleteMarca(mar);
        }
        public List<Marcas> SelectMarca()
        {
            return _dataBaseTool.SelectMarca();
        }
        #endregion

        #region Tabla  Modelo
        public Resultado InsertModelo(Modelos mod)
        {
            return _dataBaseTool.InsertModelo(mod);
        }
        public Resultado UpdateModelo(Modelos mod)
        {
            return _dataBaseTool.UpdateModelo(mod);
        }
        public Resultado DeleteModelo(Modelos mod)
        {
            return _dataBaseTool.DeleteModelo(mod);
        }
        public List<Modelos> SelectModelo()
        {
            return _dataBaseTool.SelectModelo();
        }
        #endregion

        #region Tabla  Color
        public Resultado InsertColor(Colores col)
        {
            return _dataBaseTool.InsertColor(col);
        }
        public Resultado UpdateColor(Colores col)
        {
            return _dataBaseTool.UpdateColor(col);
        }
        public Resultado DeleteColor(Colores col)
        {
            return _dataBaseTool.DeleteColor(col);
        }
        public List<Colores> SelectColor()
        {
            return _dataBaseTool.SelectColor();
        }
        #endregion

        #region Tabla  Tipo producto
        public Resultado InsertTipoProducto(TipoProductos tip)
        {
            return _dataBaseTool.InsertTipoProducto(tip);
        }
        public Resultado UpdateTipoProducto(TipoProductos tip)
        {
            return _dataBaseTool.UpdateTipoProducto(tip);
        }
        public Resultado DeleteTipoProducto(TipoProductos tip)
        {
            return _dataBaseTool.DeleteTipoProducto(tip);
        }
        public List<TipoProductos> SelectTipoProducto()
        {
            return _dataBaseTool.SelectTipoProducto();
        }
        #endregion

        #region Tabla  Empleado
        public Resultado InsertEmpleado(Empleados emp)
        {
            return _dataBaseTool.InsertEmpleado(emp);
        }
        public Resultado UpdateEmpleado(Empleados emp)
        {
            return _dataBaseTool.UpdateEmpleado(emp);
        }
        public Resultado DeleteEmpleado(Empleados emp)
        {
            return _dataBaseTool.DeleteEmpleado(emp);
        }
        public List<Empleados> SelectEmpleado()
        {
            return _dataBaseTool.SelectEmpleado();
        }
        #endregion

        #region Tabla  Vehiculo
        public Resultado InsertVehiculo(Vehiculos veh)
        {
            return _dataBaseTool.InsertVehiculos(veh);
        }
        public Resultado UpdateVehiculo(Vehiculos veh)
        {
            return _dataBaseTool.UpdateVehiculos(veh);
        }
        public List<Vehiculos> SelectVehiculo()
        {
            return _dataBaseTool.SelectVehiculos();
        }
        #endregion

        #region Tabla Proveedor
        public Resultado InsertProveedor(Proveedores pro)
        {
            return _dataBaseTool.InsertProveedor(pro);
        }
        public Resultado UpdateProveedor(Proveedores pro)
        {
            return _dataBaseTool.UpdateProveedor(pro);
        }
        public Resultado DeleteProveedor(Proveedores pro)
        {
            return _dataBaseTool.DeleteProveedor(pro);
        }
        public List<Proveedores> SelectProveedor()
        {
            return _dataBaseTool.SelectProveedor();
        }
        #endregion

        #region Tabla  Producto
        public Resultado InsertProducto(Productos pro)
        {
            return _dataBaseTool.InsertProducto(pro);
        }
        public Resultado UpdateProducto(Productos pro)
        {
            return _dataBaseTool.UpdateProducto(pro);
        }
        public Resultado DeleteProducto(Productos pro)
        {
            return _dataBaseTool.DeleteProducto(pro);
        }
        public List<Productos> SelectProducto()
        {
            return _dataBaseTool.SelectProducto();
        }
        #endregion

        #region Tabla  Tipo Movimiento
        public Resultado InsertTipoMovimiento(TipoMovimientos tim)
        {
            return _dataBaseTool.InsertTipoMovimiento(tim);
        }
        public Resultado UpdateTipoMovimiento(TipoMovimientos tim)
        {
            return _dataBaseTool.UpdateTipoMovimiento(tim);
        }
        public Resultado DeleteTipoMovimiento(TipoMovimientos tim)
        {
            return _dataBaseTool.DeleteTipoMovimiento(tim);
        }
        public List<TipoMovimientos> SelectTipoMovimiento()
        {
            return _dataBaseTool.SelectTipoMovimiento();
        }
        #endregion

        #region Tabla Movimiento
        public Resultado InsertMovimiento(Movimientos mov)
        {
            return _dataBaseTool.InsertMovimiento(mov);
        }
        public Resultado DeleteMovimiento(Movimientos mov)
        {
            return _dataBaseTool.DeleteMovimiento(mov);
        }
        public List<Movimientos> SelectMovimiento()
        {
            return _dataBaseTool.SelectMovimiento();
        }
        #endregion

        #region Tabla Grupo Cliente 
        public Resultado InsertGrupoCliente(GrupoClientes gcl)
        {
            return _dataBaseTool.InsertGrupoCliente(gcl);
        }
        public Resultado UpdateGrupoCliente(GrupoClientes gcl)
        {
            return _dataBaseTool.UpdateGurpoCliente(gcl);
        }
        public Resultado DeleteGrupoCliente(GrupoClientes gcl)
        {
            return _dataBaseTool.DeleteGrupoCliente(gcl);
        }
        public List<GrupoClientes> SelectGrupoCliente()
        {
            return _dataBaseTool.SelectGrupoCliente();
        }
        #endregion

        #region Tabla Cliente
        public Resultado InsertCliente(Clientes cli)
        {
            return _dataBaseTool.InsertCliente(cli);
        }
        public Resultado UpdateCliente(Clientes cli)
        {
            return _dataBaseTool.UpdateCliente(cli);
        }
        public Resultado DeleteCliente(Clientes cli)
        {
            return _dataBaseTool.DeleteCliente(cli);
        }
        public List<Clientes> SelectCliente()
        {
            return _dataBaseTool.SelectCliente();
        }
        #endregion

        #region Tabla Paquete 
        public Resultado InsertPaquete(Paquetes paq)
        {
            return _dataBaseTool.InsertPaquete(paq);
        }
        public Resultado UpdatePaquete(Paquetes paq)
        {
            return _dataBaseTool.UpdatePaquete(paq);
        }
        public List<Paquetes> SelectPaquete()
        {
            return _dataBaseTool.SelectPaquete();
        }
        #endregion

        #region Tabla Paquete Dia
        public Resultado InsertPaqueteDia(PaqueteDias pqd)
        {
            return _dataBaseTool.InsertPaqueteDia(pqd);
        }
        public Resultado DeletePaqueteDia(PaqueteDias pqd)
        {
            return _dataBaseTool.DeletePaqueteDia(pqd);
        }
        public List<PaqueteDias> SelectPaqueteDia()
        {
            return _dataBaseTool.SelectPaqueteDia();
        }
        #endregion

        #region Tabla Paquete Grupo Cliente
        public Resultado InsertPaqueteGrupoCliente(PaqueteGrupoClientes pgc)
        {
            return _dataBaseTool.InsertPaqueteGrupoCliente(pgc);
        }
        public Resultado DeletePaqueteGrupoCliente(PaqueteGrupoClientes pgc)
        {
            return _dataBaseTool.DeletePaqueteGrupoCliente(pgc);
        }
        public List<PaqueteGrupoClientes> SelectPaqueteGrupoCliente()
        {
            return _dataBaseTool.SelectPaqueteGrupoCliente();
        }
        #endregion

        #region Tabla Paquete Producto
        public Resultado InsertPaqueteProducto(PaqueteProductos ppr)
        {
            return _dataBaseTool.InsertPaqueteProducto(ppr);
        }
        public Resultado DeletePaqueteProducto(PaqueteProductos ppr)
        {
            return _dataBaseTool.DeletePaqueteProducto(ppr);
        }
        public List<PaqueteProductos> SelectPaqueteProducto()
        {
            return _dataBaseTool.SelectPaqueteProducto();
        }
        #endregion

        #region Tabla Promocion
        public Resultado InsertPromocion(Promociones pro)
        {
            return _dataBaseTool.InsertPromocion(pro);
        }
        public Resultado UpdatePromocion(Promociones pro)
        {
            return _dataBaseTool.UpdatePromocion(pro);
        }
        public List<Promociones> SelectPromocion()
        {
            return _dataBaseTool.SelectPromocion();
        }
        #endregion

        #region Tabla Promocion Dia
        public Resultado InsertPromocionDia(PromocionDias prd)
        {
            return _dataBaseTool.InsertPromocionDia(prd);
        }
        public Resultado DeletePromocionDia(PromocionDias prd)
        {
            return _dataBaseTool.DeletePromocionDia(prd);
        }
        public List<PromocionDias> SelectPromocionDia()
        {
            return _dataBaseTool.SelectPromocionDia();
        }
        #endregion

        #region Tabla Promocion Paquete
        public Resultado InsertPromocionPaquete(PromocionPaquetes prp)
        {
            return _dataBaseTool.InsertPromocionPaquete(prp);
        }
        public Resultado DeletePromocionPaquete(PromocionPaquetes prp)
        {
            return _dataBaseTool.DeletePromocionPaquete(prp);
        }
        public List<PromocionPaquetes> SelectPromocionPaquete()
        {
            return _dataBaseTool.SelectPromocionPaquete();
        }
        #endregion

        #region Tabla Promocion Tipo Producto
        public Resultado InsertPromocionTipoProducto(PromocionTipoProductos ptp)
        {
            return _dataBaseTool.InsertPromocionTipoProducto(ptp);
        }
        public Resultado DeletePromocionTipoProducto(PromocionTipoProductos ptp)
        {
            return _dataBaseTool.DeletePromocionTipoProducto(ptp);
        }
        public List<PromocionTipoProductos> SelectPromocionTipoProducto()
        {
            return _dataBaseTool.SelectPromocionTipoProducto();
        }
        #endregion
        
        #region Tabla Promocion Producto
        public Resultado InsertPromocionProducto(PromocionProductos ppr)
        {
            return _dataBaseTool.InsertPromocionProducto(ppr);
        }
        public Resultado DeletePromocionProducto(PromocionProductos ppr)
        {
            return _dataBaseTool.DeletePromocionProducto(ppr);
        }
        public List<PromocionProductos> SelectPromocionProducto()
        {
            return _dataBaseTool.SelectPromocionProducto();
        }
        #endregion

        #region Tabla Promocion Grupo Cliente
        public Resultado InsertPromocionGrupoCliente(PromocionGrupoClientes ppr)
        {
            return _dataBaseTool.InsertPromocionGrupoCliente(ppr);
        }
        public Resultado DeletePromocionGrupoCliente(PromocionGrupoClientes ppr)
        {
            return _dataBaseTool.DeletePromocionGrupoCliente(ppr);
        }
        public List<PromocionGrupoClientes> SelectPromocionGrupoCliente()
        {
            return _dataBaseTool.SelectPromocionGrupoCliente();
        }
        #endregion
    }
}
