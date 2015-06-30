﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using TDA.DataLayer;
using TDA.Entities;

namespace TDA.Service
{
    [ServiceContract]
    public interface ITDAService
    {
        #region Tabla Configuraciones
        [OperationContract]
        List<Configuraciones> SelectConfiguracion();
        #endregion

        #region Tabla Rol
        [OperationContract]
        List<Roles> SelectRol();
        #endregion

        #region Tabla Pagina
        [OperationContract]
        List<Paginas> SelectPagina();
        #endregion

        #region Tabla RolPagina
        [OperationContract]
        List<RolPaginas> SelectRolPagina();
        #endregion

        #region Tabla Base Salario
        [OperationContract]
        List<BaseSalarios> SelectBaseSalario();
        #endregion

        #region Tabla Tipo Identificacion
        [OperationContract]
        List<TipoIdentificaciones> SelectTipoIdentificacion();
        #endregion

        #region Tabla Usuario
        [OperationContract]
        Resultado InsertUsuario(Usuarios usu);
        [OperationContract]
        Resultado UpdateUsuario(Usuarios usu);
        [OperationContract]
        List<Usuarios> SelectUsuario(Usuarios usu);
        [OperationContract]
        List<Usuarios> BuscarUsuarioID(long ID);
        #endregion

        #region Tabla Pais
        [OperationContract]
        Resultado InsertPais(Paises pai);
        [OperationContract]
        Resultado UpdatePais(Paises pai);
        [OperationContract]
        Resultado DeletePais(Paises pai);
        [OperationContract]
        List<Paises> SelectPais(Paises pai);
        [OperationContract]
        List<Paises> BuscarPaisID(long ID);
        #endregion

        #region Tabla Estado
        [OperationContract]
        Resultado InsertEstado(Estados est);
        [OperationContract]
        Resultado UpdateEstado(Estados est);
        [OperationContract]
        List<Estados> SelectEstado(Estados est);
        [OperationContract]
        List<Estados> BuscarEstadoID(long ID);
        #endregion

        #region Tabla Marca
        [OperationContract]
        Resultado InsertMarca(Marcas mar);
        [OperationContract]
        Resultado UpdateMarca(Marcas mar);
        [OperationContract]
        Resultado DeleteMarca(Marcas mar);
        [OperationContract]
        List<Marcas> SelectMarca(Marcas mar);
        [OperationContract]
        List<Marcas> BuscarMarcaID(long ID);
        #endregion

        #region Tabla Modelo
        [OperationContract]
        Resultado InsertModelo(Modelos mod);
        [OperationContract]
        Resultado UpdateModelo(Modelos mod);
        [OperationContract]
        Resultado DeleteModelo(Modelos mod);
        [OperationContract]
        List<Modelos> SelectModelo(Modelos mod);
        [OperationContract]
        List<Modelos> BuscarModeloID(long ID);
        #endregion

        #region Tabla Color
        [OperationContract]
        Resultado InsertColor(Colores col);
        [OperationContract]
        Resultado UpdateColor(Colores col);
        [OperationContract]
        Resultado DeleteColor(Colores col);
        [OperationContract]
        List<Colores> SelectColor(Colores col);
        [OperationContract]
        List<Colores> BuscarColorID(long ID);
        #endregion

        #region Tabla Tipo producto
        [OperationContract]
        Resultado InsertTipoProducto(TipoProductos tip);
        [OperationContract]
        Resultado UpdateTipoProducto(TipoProductos tip);
        [OperationContract]
        Resultado DeleteTipoProducto(TipoProductos tip);
        [OperationContract]
        List<TipoProductos> SelectTipoProducto(TipoProductos tip);
        [OperationContract]
        List<TipoProductos> BuscarTipoProductoID(long ID);
        #endregion

        #region Tabla Empleado
        [OperationContract]
        Resultado InsertEmpleado(Empleados emp);
        [OperationContract]
        Resultado UpdateEmpleado(Empleados emp);
        [OperationContract]
        Resultado DeleteEmpleado(Empleados emp);
        [OperationContract]
        List<Empleados> SelectEmpleado(Empleados emp);
        #endregion

        #region Tabla Vehiculo
        [OperationContract]
        Resultado InsertVehiculo(Vehiculos veh);
        [OperationContract]
        Resultado UpdateVehiculo(Vehiculos veh);
        [OperationContract]
        List<Vehiculos> SelectVehiculo();
        #endregion

        #region Tabla Proveedor
        [OperationContract]
        Resultado InsertProveedor(Proveedores pro);
        [OperationContract]
        Resultado UpdateProveedor(Proveedores pro);
        [OperationContract]
        Resultado DeleteProveedor(Proveedores pro);
        [OperationContract]
        List<Proveedores> SelectProveedor();
        #endregion

        #region Tabla Dia
        [OperationContract]
        List<Dias> SelectDia();
        #endregion

        #region Tabla Producto
        [OperationContract]
        Resultado InsertProducto(Productos pro);
        [OperationContract]
        Resultado UpdateProducto(Productos pro);
        [OperationContract]
        Resultado DeleteProducto(Productos pro);
        [OperationContract]
        List<Productos> SelectProducto();
        #endregion

        #region Tabla Tipo Movimiento
        [OperationContract]
        Resultado InsertTipoMovimiento(TipoMovimientos tim);
        [OperationContract]
        Resultado UpdateTipoMovimiento(TipoMovimientos tim);
        [OperationContract]
        Resultado DeleteTipoMovimiento(TipoMovimientos tim);
        [OperationContract]
        List<TipoMovimientos> SelectTipoMovimiento();
        #endregion
        
        #region Tabla Movimiento
        [OperationContract]
        Resultado InsertMovimiento(Movimientos mov);
        [OperationContract]
        Resultado DeleteMovimiento(Movimientos mov);
        [OperationContract]
        List<Movimientos> SelectMovimiento();
        #endregion

        #region Tabla Grupo Cliente
        [OperationContract]
        Resultado InsertGrupoCliente(GrupoClientes gcl);
        [OperationContract]
        Resultado UpdateGrupoCliente(GrupoClientes gcl);
        [OperationContract]
        Resultado DeleteGrupoCliente(GrupoClientes gcl);
        [OperationContract]
        List<GrupoClientes> SelectGrupoCliente(GrupoClientes gcl);
        [OperationContract]
        List<GrupoClientes> BuscarGrupoClienteID(long ID);
        #endregion

        #region Tabla Cliente
        [OperationContract]
        Resultado InsertCliente(Clientes cli);
        [OperationContract]
        Resultado UpdateCliente(Clientes cli);
        [OperationContract]
        Resultado DeleteCliente(Clientes cli);
        [OperationContract]
        List<Clientes> SelectCliente();
        #endregion

        #region Tabla Paquete
        [OperationContract]
        Resultado InsertPaquete(Paquetes paq);
        [OperationContract]
        Resultado UpdatePaquete(Paquetes paq);
        [OperationContract]
        List<Paquetes> SelectPaquete();
        #endregion

        #region Tabla Paquete Dia
        [OperationContract]
        Resultado InsertPaqueteDia(PaqueteDias pqd);
        [OperationContract]
        Resultado DeletePaqueteDia(PaqueteDias pqd);
        [OperationContract]
        List<PaqueteDias> SelectPaqueteDia();
        #endregion

        #region Tabla Paquete Grupo Cliente
        [OperationContract]
        Resultado InsertPaqueteGrupoCliente(PaqueteGrupoClientes pgc);
        [OperationContract]
        Resultado DeletePaqueteGrupoCliente(PaqueteGrupoClientes pgc);
        [OperationContract]
        List<PaqueteGrupoClientes> SelectPaqueteGrupoCliente();
        #endregion

        #region Tabla Paquete Producto
        [OperationContract]
        Resultado InsertPaqueteProducto(PaqueteProductos ppr);
        [OperationContract]
        Resultado DeletePaqueteProducto(PaqueteProductos ppr);
        [OperationContract]
        List<PaqueteProductos> SelectPaqueteProducto();
        #endregion

        #region Tabla Promocion
        [OperationContract]
        Resultado InsertPromocion(Promociones pro);
        [OperationContract]
        Resultado UpdatePromocion(Promociones pro);
        [OperationContract]
        List<Promociones> SelectPromocion();
        #endregion

        #region Tabla Promocion Dia
        [OperationContract]
        Resultado InsertPromocionDia(PromocionDias prd);
        [OperationContract]
        Resultado DeletePromocionDia(PromocionDias prd);
        [OperationContract]
        List<PromocionDias> SelectPromocionDia();
        #endregion

        #region Tabla Promocion Paquete
        [OperationContract]
        Resultado InsertPromocionPaquete(PromocionPaquetes prp);
        [OperationContract]
        Resultado DeletePromocionPaquete(PromocionPaquetes prp);
        [OperationContract]
        List<PromocionPaquetes> SelectPromocionPaquete();
        #endregion

        #region Tabla Promocion Tipo Producto
        [OperationContract]
        Resultado InsertPromocionTipoProducto(PromocionTipoProductos ptp);
        [OperationContract]
        Resultado DeletePromocionTipoProducto(PromocionTipoProductos ptp);
        [OperationContract]
        List<PromocionTipoProductos> SelectPromocionTipoProducto();
        #endregion

        #region Tabla Promocion Producto 
        [OperationContract]
        Resultado InsertPromocionProducto(PromocionProductos ppr);
        [OperationContract]
        Resultado DeletePromocionProducto(PromocionProductos ppr);
        [OperationContract]
        List<PromocionProductos> SelectPromocionProducto();
        #endregion

        #region Tabla Promocion Grupo Cliente
        [OperationContract]
        Resultado InsertPromocionGrupoCliente(PromocionGrupoClientes ppr);
        [OperationContract]
        Resultado DeletePromocionGrupoCliente(PromocionGrupoClientes ppr);
        [OperationContract]
        List<PromocionGrupoClientes> SelectPromocionGrupoCliente();
        #endregion

        #region Tabla Venta
        [OperationContract]
        Resultado InsertVenta(Ventas ven);
        [OperationContract]
        Resultado DeleteVenta(Ventas ven);
        [OperationContract]
        List<Ventas> SelectVenta();
        #endregion

        #region Tabla Venta Detalle
        [OperationContract]
        Resultado InsertVentaDetalle(VentaDetalles ved);
        [OperationContract]
        Resultado DeleteVentaDetalle(VentaDetalles ved);
        [OperationContract]
        List<VentaDetalles> SelectVentaDetalle();
        #endregion

        #region Tabla Venta Dia
        [OperationContract]
        Resultado InsertVentaDia(VentaDias ved);
        [OperationContract]
        Resultado DeleteVentaDia(VentaDias ved);
        [OperationContract]
        List<VentaDias> SelectVentaDia();
        #endregion

        #region Tabla Logs
        [OperationContract]
        Resultado InsertLog(Log log);
        [OperationContract]
        List<Log> SelectLog();
        #endregion

    }
}
