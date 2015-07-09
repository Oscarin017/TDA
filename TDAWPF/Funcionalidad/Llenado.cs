using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TDA.Entities;

namespace TDAWPF.Funcionalidad
{
    class Llenado
    {
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
        
    }
}
