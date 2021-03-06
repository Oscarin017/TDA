﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDA.Entities;
using TDAWPF.Funcionalidad;

namespace TDAWPF.Layouts
{
    /// <summary>
    /// Interaction logic for Proveedor.xaml
    /// </summary>
    public partial class Proveedor : Page
    {
        List<Proveedores> lstProveedor = new List<Proveedores>();
        private long lPais = 0;
        private long lEstado = 0;

        public Proveedor()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Proveedores p)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                p.Pais = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.SelectedItem;
            if (cbEstado.SelectedIndex != 0)
            {
                p.Estado = Convert.ToInt64(cbi1.Uid);
            }
            if (!txtNombre.PlaceHolder)
            {
                p.Nombre = txtNombre.Text;
            }
            if (!txtRFC.PlaceHolder)
            {
                p.RFC = txtRFC.Text;
            }
            cargarGrid(p);
        }

        private void cargarGrid(Proveedores p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectProveedor(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Proveedores => Proveedores.RFC);
            lstProveedor.Clear();
            foreach (var r in ordenado)
            {
                string sNombre = "";
                if (r.Tipo)
                {
                    sNombre = r.Nombre;
                }
                else
                {
                    sNombre = r.Apellido + " " + r.Apellido2 + " " + r.Nombre;
                }
                lstProveedor.Add(new Proveedores()
                {
                    ID = r.ID,
                    Nombre = sNombre,
                    RFC = r.RFC,
                    Telefono = r.Telefono
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstProveedor;
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBPais(new Paises(), cbPais);
            cargarGrid(new Proveedores());
            Llenado.seleccionarDefaultPais(cbPais);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Proveedores());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Proveedor w = new Popups.Proveedor();
            w.ShowDialog();
            realizarBusqueda(new Proveedores());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Proveedores r = ((Button)sender).DataContext as Proveedores;
            long lID = r.ID;
            Popups.Proveedor w = new Popups.Proveedor(lID);
            w.ShowDialog();
            realizarBusqueda(new Proveedores());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Proveedores p = ((Button)sender).DataContext as Proveedores;
            string sNombre = p.Nombre;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar el proveedor " + sNombre + ".", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Resultado r = tda.DeleteProveedor(p);
                if (r.ErrorDB)
                {
                    MessageBox.Show("No se pudo eliminar el producto " + sNombre + ".");
                }
                realizarBusqueda(new Proveedores());
            }
        }

        private void cbPais_SelectionChanged(object sender, EventArgs e)
        {
            Estados es = new Estados();
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (this.IsLoaded)
            {
                es.Pais = lPais = Convert.ToInt64(cbi.Uid);
                Llenado.cargarCBEstado(es, cbEstado);
            }
        }

        private void cbEstado_SelectionChanged(object sender, EventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            Estados es = new Estados();
            ComboBoxItem cbi = (ComboBoxItem)cbEstado.SelectedItem;
            if (this.IsLoaded)
            {
                if (cbEstado.SelectedIndex > 0)
                {
                    es = tda.BuscarEstadoID(Convert.ToInt64(cbi.Uid)).First();
                    lEstado = es.ID;
                    if (lPais == 0)
                    {
                        Llenado.seleccionarComboBoxUid(es.Pais.ToString(), cbPais);
                        Llenado.seleccionarComboBoxUid(lEstado.ToString(), cbEstado);
                    }
                }
                Llenado.cargarCBCiudadProveedor(Convert.ToInt64(es.ID), cbCiudad);
            }
        }
    }
}
