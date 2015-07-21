using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TDA.Entities;
using System.Text.RegularExpressions;

namespace TDAWPF.Funcionalidad
{
    class Llenado
    {
        #region Llenado de ComboBoxI
        public static void cargarCBPais(Paises p, Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectPais(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Paises => Paises.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBEstado(Estados e, Controles.ComboBoxI cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEstado(e);
            tda.Close();
            var ordenado = resultado.OrderBy(Estados => Estados.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }        

        public static void cargarCBMarca(Marcas m, Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectMarca(m);
            tda.Close();
            var ordenado = resultado.OrderBy(Marcas => Marcas.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBModelo(Modelos m, Controles.ComboBoxI cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectModelo(m);
            tda.Close();
            var ordenado = resultado.OrderBy(Modelos => Modelos.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBColor(Colores c, Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectColor(c);
            tda.Close();
            var ordenado = resultado.OrderBy(Colores => Colores.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBRol(Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectRol();
            tda.Close();
            var ordenado = resultado.OrderBy(Roles => Roles.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBBaseSalario(Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectBaseSalario();
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBGrupoCliente(GrupoClientes gc, Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectGrupoCliente(gc);
            tda.Close();
            var ordenado = resultado.OrderBy(GrupoClientes => GrupoClientes.Nombre);
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBTipoProducto(TipoProductos tp, Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectTipoProducto(tp);
            tda.Close();
            var ordenado = resultado.OrderBy(TipoProductos => TipoProductos.Nombre);
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBProveedor(Proveedores p, Controles.ComboBoxI cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectProveedor(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Proveedores => Proveedores.RFC);
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre + " " + r.Apellido + " " + r.Apellido2;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBTipoPromocion(Controles.ComboBoxI cb)
        {
            ComboBoxItem cbi = new ComboBoxItem();
            cbi.Uid = "1";
            cbi.Content = "Porcentaje";
            ComboBoxItem cbi1 = new ComboBoxItem();
            cbi1.Uid = "2";
            cbi1.Content = "Cantidad";
            ComboBoxItem cbi2 = new ComboBoxItem();
            cbi2.Uid = "3";
            cbi2.Content = "Precio Fijo";
            ComboBoxItem cbi3 = new ComboBoxItem();
            cbi3.Uid = "4";
            cbi3.Content = "Pagas X Llevas";
            cb.Items.Add(cbi);
            cb.Items.Add(cbi1);
            cb.Items.Add(cbi2);
            cb.Items.Add(cbi3);
        }
        #endregion

        #region Llenado de ComboBoxS
        public static void cargarCBPais(Paises p, Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectPais(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Paises => Paises.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBEstado(Estados e, Controles.ComboBoxS cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEstado(e);
            tda.Close();
            var ordenado = resultado.OrderBy(Estados => Estados.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBCiudadCliente(long lEstado, Controles.ComboBoxS cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectCiudadCliente(lEstado);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = r;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBCiudadEmpleado(long lEstado, Controles.ComboBoxS cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectCiudadEmpleado(lEstado);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = r;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBCiudadProveedor(long lEstado, Controles.ComboBoxS cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectCiudadProveedor(lEstado);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = r;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBMarca(Marcas m, Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectMarca(m);
            tda.Close();
            var ordenado = resultado.OrderBy(Marcas => Marcas.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBModelo(Modelos m, Controles.ComboBoxS cb)
        {
            cb.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectModelo(m);
            tda.Close();
            var ordenado = resultado.OrderBy(Modelos => Modelos.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBColor(Colores c, Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectColor(c);
            tda.Close();
            var ordenado = resultado.OrderBy(Colores => Colores.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBRol(Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectRol();
            tda.Close();
            var ordenado = resultado.OrderBy(Roles => Roles.Nombre).ToList();
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBGrupoCliente(GrupoClientes gc, Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectGrupoCliente(gc);
            tda.Close();
            var ordenado = resultado.OrderBy(GrupoClientes => GrupoClientes.Nombre);
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBTipoProducto(TipoProductos tp, Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectTipoProducto(tp);
            tda.Close();
            var ordenado = resultado.OrderBy(TipoProductos => TipoProductos.Nombre);
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBProveedor(Proveedores p, Controles.ComboBoxS cb)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectProveedor(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Proveedores => Proveedores.RFC);
            foreach (var r in ordenado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre + " " + r.Apellido + " " + r.Apellido2;
                cb.Items.Add(cbi);
            }
        }

        public static void cargarCBTipoPromocion(Controles.ComboBoxS cb)
        {
            ComboBoxItem cbi = new ComboBoxItem();
            cbi.Uid = "1";
            cbi.Content = "Procentaje";
            ComboBoxItem cbi1 = new ComboBoxItem();
            cbi1.Uid = "2";
            cbi1.Content = "Cantidad";
            ComboBoxItem cbi2 = new ComboBoxItem();
            cbi2.Uid = "3";
            cbi2.Content = "Precio Fijo";
            ComboBoxItem cbi3 = new ComboBoxItem();
            cbi3.Uid = "4";
            cbi3.Content = "Pagas X Llevas";
            cb.Items.Add(cbi);
            cb.Items.Add(cbi1);
            cb.Items.Add(cbi2);
            cb.Items.Add(cbi3);
        }
        #endregion

        #region Selecciones
        public static void seleccionarDefaultPais(Controles.ComboBoxS cb)
        {
            foreach (ComboBoxItem cbi in cb.Items)
            {
                if (cbi.Content.ToString() == "Mexico")
                {
                    cbi.IsSelected = true;
                }
            }
        }
        
        public static void seleccionarDefaultPais(Controles.ComboBoxI cb)
        {
            foreach (ComboBoxItem cbi in cb.Items)
            {
                if (cbi.Content.ToString() == "Mexico")
                {
                    cbi.IsSelected = true;
                }
            }
        }

        public static void seleccionarComboBoxUid(string Uid, Controles.ComboBoxI cb)
        {
            foreach (ComboBoxItem cbi in cb.Items)
            {
                if (cbi.Uid == Uid)
                {
                    cbi.IsSelected = true;
                }
            }
        }

        public static void seleccionarComboBoxUid(string Uid, Controles.ComboBoxS cb)
        {
            foreach (ComboBoxItem cbi in cb.Items)
            {
                if (cbi.Uid == Uid)
                {
                    cbi.IsSelected = true;
                }
            }
        }
        #endregion

        #region Llenado de DataGrids
        public static string tipoPromocion(int iPromocion)
        {
            string sTipo = "";
            switch(iPromocion)
            {
                case 1:
                    {
                        sTipo = "Precio Fijo";
                        break;
                    }
                case 2:
                    {
                        sTipo = "Porcentaje";
                        break;
                    }
                case 3:
                    {
                        sTipo = "Cantidad";
                        break;
                    }
                case 4:
                    {
                        sTipo = "Pagas X Llevas";
                        break;
                    }
            }
            return sTipo;
        }
        #endregion

        #region Manejo de Dias
        public static List<PaqueteDias> guardarDiasSeleccionadosPaquete(long lPaquete, CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7)
        {
            List<PaqueteDias> lstPD = new List<PaqueteDias>();
            if (cb1.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 1;
                lstPD.Add(pd);
            }
            if (cb2.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 2;
                lstPD.Add(pd);
            }
            if (cb3.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 3;
                lstPD.Add(pd);
            }
            if (cb4.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 4;
                lstPD.Add(pd);
            }
            if (cb5.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 5;
                lstPD.Add(pd);
            }
            if (cb6.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 6;
                lstPD.Add(pd);
            }
            if (cb7.IsChecked == true)
            {
                PaqueteDias pd = new PaqueteDias();
                pd.Paquete = lPaquete;
                pd.Dia = 7;
                lstPD.Add(pd);
            }
            return lstPD;
        }

        public static List<PromocionDias> guardarDiasSeleccionadosPromocion(long lPromocion, CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7)
        {
            List<PromocionDias> lstPD = new List<PromocionDias>();
            if (cb1.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 1;
                lstPD.Add(pd);
            }
            if (cb2.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 2;
                lstPD.Add(pd);
            }
            if (cb3.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 3;
                lstPD.Add(pd);
            }
            if (cb4.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 4;
                lstPD.Add(pd);
            }
            if (cb5.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 5;
                lstPD.Add(pd);
            }
            if (cb6.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 6;
                lstPD.Add(pd);
            }
            if (cb7.IsChecked == true)
            {
                PromocionDias pd = new PromocionDias();
                pd.Promocion = lPromocion;
                pd.Dia = 7;
                lstPD.Add(pd);
            }
            return lstPD;
        }

        public static void mostrarDiasSeleccionados(List<PaqueteDias> lstPD, CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7)
        {
            cb1.IsChecked = false;
            cb2.IsChecked = false;
            cb3.IsChecked = false;
            cb4.IsChecked = false;
            cb5.IsChecked = false;
            cb6.IsChecked = false;
            cb7 .IsChecked = false;
            foreach (PaqueteDias pd in lstPD)
            {
                switch (pd.Dia)
                {
                    case 1:
                        {
                            cb1.IsChecked = true;
                            break;
                        }
                    case 2:
                        {
                            cb2.IsChecked = true;
                            break;
                        }
                    case 3:
                        {
                            cb3.IsChecked = true;
                            break;
                        }
                    case 4:
                        {
                            cb4.IsChecked = true;
                            break;
                        }
                    case 5:
                        {
                            cb5.IsChecked = true;
                            break;
                        }
                    case 6:
                        {
                            cb6.IsChecked = true;
                            break;
                        }
                    case 7:
                        {
                            cb7.IsChecked = true;
                            break;
                        }
                }
            }
        }

        public static void mostrarDiasSeleccionados(List<PromocionDias> lstPD, CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7)
        {
            cb1.IsChecked = false;
            cb2.IsChecked = false;
            cb3.IsChecked = false;
            cb4.IsChecked = false;
            cb5.IsChecked = false;
            cb6.IsChecked = false;
            cb7.IsChecked = false;
            foreach (PromocionDias pd in lstPD)
            {
                switch (pd.Dia)
                {
                    case 1:
                        {
                            cb1.IsChecked = true;
                            break;
                        }
                    case 2:
                        {
                            cb2.IsChecked = true;
                            break;
                        }
                    case 3:
                        {
                            cb3.IsChecked = true;
                            break;
                        }
                    case 4:
                        {
                            cb4.IsChecked = true;
                            break;
                        }
                    case 5:
                        {
                            cb5.IsChecked = true;
                            break;
                        }
                    case 6:
                        {
                            cb6.IsChecked = true;
                            break;
                        }
                    case 7:
                        {
                            cb7.IsChecked = true;
                            break;
                        }
                }
            }
        }
        #endregion

        #region Comparacion de tablas
        public static List<Productos> compararTabla(List<Productos> lstCompleta, List<Productos> lstTabla)
        {
            List<Productos> lstOrdenada = lstCompleta.ToList();
            foreach (Productos pT in lstTabla)
            {
                foreach (Productos pC in lstCompleta)
                {
                    if (pC.ID == pT.ID)
                    {
                        lstOrdenada.Remove(pC);
                    }
                }
            }
            return lstOrdenada;
        }

        public static List<Paquetes> compararTabla(List<Paquetes> lstCompleta, List<Paquetes> lstTabla)
        {
            List<Paquetes> lstOrdenada = lstCompleta.ToList();
            foreach (Paquetes pT in lstTabla)
            {
                foreach (Paquetes pC in lstCompleta)
                {
                    if (pC.ID == pT.ID)
                    {
                        lstOrdenada.Remove(pC);
                    }
                }
            }
            return lstOrdenada;
        }

        public static List<TipoProductos> compararTabla(List<TipoProductos> lstCompleta, List<TipoProductos> lstTabla)
        {
            List<TipoProductos> lstOrdenada = lstCompleta.ToList();
            foreach (TipoProductos tpT in lstTabla)
            {
                foreach (TipoProductos tpC in lstCompleta)
                {
                    if (tpC.ID == tpT.ID)
                    {
                        lstOrdenada.Remove(tpC);
                    }
                }
            }
            return lstOrdenada;
        }

        public static List<GrupoClientes> compararTabla(List<GrupoClientes> lstCompleta, List<GrupoClientes> lstTabla)
        {
            List<GrupoClientes> lstOrdenada = lstCompleta.ToList();
            foreach (GrupoClientes gcT in lstTabla)
            {
                foreach (GrupoClientes gcC in lstCompleta)
                {
                    if (gcC.ID == gcT.ID)
                    {
                        lstOrdenada.Remove(gcC);
                    }
                }
            }
            return lstOrdenada;
        }
        #endregion

        #region Ordenamiento de tablas
        public static List<Productos> ordenarTabla(List<Productos> lstP)
        {
            List<Productos> lst = lstP.OrderBy(Productos => Productos.Descripcion).ToList();
            return lst;
        }

        public static List<Paquetes> ordenarTabla(List<Paquetes> lstP)
        {
            List<Paquetes> lst = lstP.OrderBy(Paquetes => Paquetes.Nombre).ToList();
            return lst;
        }

        public static List<TipoProductos> ordenarTabla(List<TipoProductos> lstTP)
        {
            List<TipoProductos> lst = lstTP.OrderBy(TipoProductos => TipoProductos.Nombre).ToList();
            return lst;
        }

        public static List<GrupoClientes> ordenarTabla(List<GrupoClientes> lstGC)
        {
            List<GrupoClientes> lst = lstGC.OrderBy(GrupoClientes => GrupoClientes.Nombre).ToList();
            return lst;
        }
        #endregion

        #region Validacion de Popups
        public static bool validacionRFC(string sRFC, bool Tipo)
        {
            bool bValidacion = false;
           if (!Tipo)
            {
                Regex r = new Regex("^[a-zA-Z]{4}[0-9]{6}[a-zA-Z0-9]{3}$");
                if(r.IsMatch(sRFC))
                {
                    bValidacion = true;
                }
            }
            else
            {
               Regex r = new Regex("^[a-zA-Z]{3}[0-9]{6}[a-zA-Z0-9]{3}$");
                if(r.IsMatch(sRFC))
                {
                    bValidacion = true;
                }     
            }
            if(!bValidacion)
            {
                MessageBox.Show("RFC no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionCURP(string sCURP)
        {
            bool bValidacion = false;
            Regex r = new Regex("^[a-zA-Z]{4}[0-9]{6}[hHmM][a-zA-Z]{5}[0-9]{2}$");
            if (r.IsMatch(sCURP))
            {
                bValidacion = true;
            }
            else
            { 
                MessageBox.Show("CURP no valida. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionNSS(string sNSS)
        {
            bool bValidacion = false;
            Regex r = new Regex("^[0-9]{10}$");
            if (r.IsMatch(sNSS))
            {
                bValidacion = true;
            }
            else
            {
                MessageBox.Show("NSS no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionCP(string sCP)
        {
            bool bValidacion = false;
            Regex r = new Regex("^[0-9]{5}$");
            if (r.IsMatch(sCP))
            {
                bValidacion = true;
            }
            else
            {
                MessageBox.Show("CP no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionTelefono(string sTelefono)
        {
            bool bValidacion = false;
            Regex r = new Regex("^[0-9]{7,10}$");
            if (r.IsMatch(sTelefono))
            {
                bValidacion = true;
            }
            else
            {
                MessageBox.Show("Telefono no valido. Favor de verificar.\nTelefono debe contener solo numeros. Minimo 7 y maximo 10 caracteres.");
            }  
            return bValidacion;
        }

        public static bool validacionEMail(string sEmail)
        {
            bool bValidacion = false;
            Regex r = new Regex("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+[.][a-zA-Z0-9-.]+$");
            if (r.IsMatch(sEmail))
            {
                bValidacion = true;
            }
            else
            {
                MessageBox.Show("Email no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionPrecio(string sPrecio)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sPrecio);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Precio no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionPorcentaje(string sPorcenaje)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sPorcenaje);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Porcentaje de promocion no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionCantidad(string sCantidad)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sCantidad);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Cantidad de promocion no valida. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionFijo(string sFijo)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sFijo);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Precio fijo no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionCompra(string sCompra)
        {
            bool bValidacion = false;
            try
            {
                int dPrecio = Convert.ToInt32(sCompra);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Cantidad de compra no valida. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionPaga(string sCompra)
        {
            bool bValidacion = false;
            try
            {
                int dPrecio = Convert.ToInt32(sCompra);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Cantidad de paga no valida. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionPrecioVenta(string sPrecio)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sPrecio);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Precio de venta no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionPrecioCompra(string sPrecio)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sPrecio);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Precio de compra no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionIVA(string sIVA)
        {
            bool bValidacion = false;
            try
            {
                decimal dPrecio = Convert.ToDecimal(sIVA);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("IVA no valido. Favor de verificar.");
            }
            return bValidacion;
        }

        public static bool validacionAno(string sAno)
        {
            bool bValidacion = false;
            try
            {
                int dPrecio = Convert.ToInt32(sAno);
                bValidacion = true;
            }
            catch
            {
                MessageBox.Show("Año no valido. Favor de verificar.");
            }
            return bValidacion;
        }
        #endregion
    }
}
