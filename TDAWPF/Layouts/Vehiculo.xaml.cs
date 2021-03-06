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
    /// Interaction logic for Vehiculo.xaml
    /// </summary>
    public partial class Vehiculo : Page
    {
        List<Vehiculos> lstVehiculo = new List<Vehiculos>();
        private long lMarca = 0;
        private long lModelo = 0;

        public Vehiculo()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Vehiculos v)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbMarca.SelectedItem;
            if (cbMarca.SelectedIndex != 0)
            {
                v.Marca = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1 = (ComboBoxItem)cbModelo.SelectedItem;
            if (cbModelo.SelectedIndex != 0)
            {
                v.Modelo = Convert.ToInt64(cbi1.Uid);
            }
            if (!txtAno.PlaceHolder)
            {
                v.Ano = Convert.ToInt32(txtAno.Text);
            }
            ComboBoxItem cbi2 = (ComboBoxItem)cbColor.SelectedItem;
            if (cbColor.SelectedIndex != 0)
            {
                v.Color = cbi2.Content.ToString();
            }
            if (!txtNoSerie.PlaceHolder)
            {
                v.NoSerie = txtNoSerie.Text;
            }
            cargarGrid(v);
        }

        private void cargarGrid(Vehiculos v)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectVehiculo(v);
            tda.Close();
            var ordenado = resultado.OrderBy(Vehiculos => Vehiculos.NoSerie);
            lstVehiculo.Clear();
            foreach (var r in ordenado)
            {
                lstVehiculo.Add(new Vehiculos()
                {
                    ID = r.ID,
                    MarcaNombre = r.MarcaNombre,
                    ModeloNombre = r.ModeloNombre,
                    Color = r.Color,
                    Ano = r.Ano,
                    NoSerie = r.NoSerie
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstVehiculo;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBMarca(new Marcas(), cbMarca);
            Llenado.cargarCBModelo(new Modelos(), cbModelo);
            Llenado.cargarCBColor(new Colores(), cbColor);
            cargarGrid(new Vehiculos());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Vehiculos());
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Vehiculo w = new Popups.Vehiculo();
            w.ShowDialog();
            realizarBusqueda(new Vehiculos());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Vehiculos r = ((Button)sender).DataContext as Vehiculos;
            long lID = r.ID;
            Popups.Vehiculo w = new Popups.Vehiculo(lID);
            w.ShowDialog();
            realizarBusqueda(new Vehiculos());
        }

        private void cbMarca_SelectionChanged(object sender, EventArgs e)
        {
            Modelos m = new Modelos();
            ComboBoxItem cbi = (ComboBoxItem)cbMarca.SelectedItem;
            if (this.IsLoaded)
            {
                m.Marca = lMarca = Convert.ToInt64(cbi.Uid);
                Llenado.cargarCBModelo(m, cbModelo);
            }    
        }

        private void cbModelo_SelectionChanged(object sender, EventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            Modelos m = new Modelos();
            ComboBoxItem cbi = (ComboBoxItem)cbModelo.SelectedItem;
            if (this.IsLoaded)
            {
                if (cbModelo.SelectedIndex > 0)
                {
                    m = tda.BuscarModeloID(Convert.ToInt64(cbi.Uid)).First();
                    lModelo = m.ID;
                    if (lMarca == 0)
                    {
                        Llenado.seleccionarComboBoxUid(m.Marca.ToString(), cbMarca);
                        Llenado.seleccionarComboBoxUid(lModelo.ToString(), cbModelo);
                    }
                }
            }
        }        
    }
}
