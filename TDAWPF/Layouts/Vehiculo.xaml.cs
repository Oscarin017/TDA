using System;
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

        public Vehiculo()
        {
            InitializeComponent();
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
            Vehiculos v = new Vehiculos();
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
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Vehiculo w = new Popups.Vehiculo();
            w.ShowDialog();
            cargarGrid(new Vehiculos());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Vehiculos r = ((Button)sender).DataContext as Vehiculos;
            long lID = r.ID;
            Popups.Vehiculo w = new Popups.Vehiculo(lID);
            w.ShowDialog();
            cargarGrid(new Vehiculos());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbMarca_SelectionChanged(object sender, EventArgs e)
        {
            Modelos m = new Modelos();
            ComboBoxItem cbi = (ComboBoxItem)cbMarca.SelectedItem;
            if (cbMarca.SelectedIndex != 0)
            {
                m.Marca = Convert.ToInt64(cbi.Uid);
            }
            if (this.IsLoaded)
            {
                Llenado.cargarCBModelo(m, cbModelo);
            }    
        }
    }
}
