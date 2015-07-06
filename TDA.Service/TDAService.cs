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
        public List<Usuarios> SelectUsuario(Usuarios usu)
        {
            return _dataBaseTool.SelectUsuarios(usu);
        }
        public List<Usuarios> BuscarUsuarioID(long ID)
        {
            return _dataBaseTool.BuscarUsuariosID(ID);
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
        public List<Paises> SelectPais(Paises pai)
        {
            return _dataBaseTool.SelectPais(pai);
        }
        public List<Paises> BuscarPaisID(long ID)
        {
            return _dataBaseTool.BuscarPaisID(ID);
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
        public List<Estados> SelectEstado(Estados est)
        {
            return _dataBaseTool.SelectEstado(est);
        }
        public List<Estados> BuscarEstadoID(long ID)
        {
            return _dataBaseTool.BuscarEstadoID(ID);
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
        public List<Marcas> SelectMarca(Marcas mar)
        {
            return _dataBaseTool.SelectMarca(mar);
        }
        public List<Marcas> BuscarMarcaID(long ID)
        {
            return _dataBaseTool.BuscarMarcaID(ID);
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
        public List<Modelos> SelectModelo(Modelos mod)
        {
            return _dataBaseTool.SelectModelo(mod);
        }
        public List<Modelos> BuscarModeloID(long ID)
        {
            return _dataBaseTool.BuscarModeloID(ID);
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
        public List<Colores> SelectColor(Colores col)
        {
            return _dataBaseTool.SelectColor(col);
        }
        public List<Colores> BuscarColorID(long ID)
        {
            return _dataBaseTool.BuscarColorID(ID);
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
        public List<TipoProductos> SelectTipoProducto(TipoProductos tip)
        {
            return _dataBaseTool.SelectTipoProducto(tip);
        }
        public List<TipoProductos> BuscarTipoProductoID(long ID)
        {
            return _dataBaseTool.BuscarTipoProductoID(ID);
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
        public List<Empleados> SelectEmpleado(Empleados emp)
        {
            return _dataBaseTool.SelectEmpleado(emp);
        }
        public List<Empleados> BuscarEmpleadoID(long? ID)
        {
            return _dataBaseTool.BuscarEmpleadoID(ID);
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
        public List<Vehiculos> SelectVehiculo(Vehiculos veh)
        {
            return _dataBaseTool.SelectVehiculos(veh);
        }
        public List<Vehiculos> BuscarVehiculoID(long? ID)
        {
            return _dataBaseTool.BuscarVehiculosID(ID);
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
        public List<Proveedores> SelectProveedor(Proveedores pro)
        {
            return _dataBaseTool.SelectProveedor(pro);
        }
        public List<Proveedores> BuscarProveedorID(long? ID)
        {
            return _dataBaseTool.BuscarProveedorID(ID);
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
        public List<Productos> SelectProducto(Productos pro)
        {
            return _dataBaseTool.SelectProducto(pro);
        }
        public List<Productos> BuscarProductoID(long? ID)
        {
            return _dataBaseTool.BuscarProductoID(ID);
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
        public List<GrupoClientes> SelectGrupoCliente(GrupoClientes gcl)
        {
            return _dataBaseTool.SelectGrupoCliente(gcl);
        }
        public List<GrupoClientes> BuscarGrupoClienteID(long ID)
        {
            return _dataBaseTool.BuscarGrupoClienteID(ID);
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
        public List<Clientes> SelectCliente(Clientes cli)
        {
            return _dataBaseTool.SelectCliente(cli);
        }
        public List<Clientes> BuscarClienteID(long? ID)
        {
            return _dataBaseTool.BuscarClienteID(ID);
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

        #region Tabla Venta 
        public Resultado InsertVenta(Ventas ven)
        {
            return _dataBaseTool.InsertVenta(ven);
        }
        public Resultado DeleteVenta(Ventas ven)
        {
            return _dataBaseTool.DeleteVenta(ven);
        }
        public List<Ventas> SelectVenta()
        {
            return _dataBaseTool.SelectVenta();
        }
        #endregion

        #region Tabla Venta Detalle
        public Resultado InsertVentaDetalle(VentaDetalles ved)
        {
            return _dataBaseTool.InsertVentaDetalle(ved);
        }
        public Resultado DeleteVentaDetalle(VentaDetalles ved)
        {
            return _dataBaseTool.DeleteVentaDetalle(ved);
        }
        public List<VentaDetalles> SelectVentaDetalle()
        {
            return _dataBaseTool.SelectVentaDetalle();
        }
        #endregion

        #region Tabla Venta Dia
        public Resultado InsertVentaDia(VentaDias ved)
        {
            return _dataBaseTool.InsertVentaDia(ved);
        }
        public Resultado DeleteVentaDia(VentaDias ved)
        {
            return _dataBaseTool.DeleteVentaDia(ved);
        }
        public List<VentaDias> SelectVentaDia()
        {
            return _dataBaseTool.SelectVentaDia();
        }
        #endregion

        #region Tabla Logs
        public Resultado InsertLog(Log log)
        {
            return _dataBaseTool.InsertLog(log);
        }
        public List<Log> SelectLog()
        {
            return _dataBaseTool.SelectLog();
        }
        #endregion


    }
}
