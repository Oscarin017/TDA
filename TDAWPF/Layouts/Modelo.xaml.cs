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

namespace TDAWPF.Layouts
{
    /// <summary>
    /// Interaction logic for Modelo.xaml
    /// </summary>
    public partial class Modelo : Page
    {
        List<Modelos> lstModelo = new List<Modelos>();

        public Modelo()
        {
            InitializeComponent();
        }

        private void cargarCBMarca(Marcas m)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectMarca(m);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbMarca.Items.Add(cbi);                
            }
        }

        private void cargarGrid(Modelos m)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectModelo(m);
            tda.Close();
            lstModelo.Clear();

            foreach (var r in resultado)
            {
                lstModelo.Add(new Modelos()
                {
                    ID = r.ID,
                    Nombre = r.Nombre,
                    MarcaNombre = r.MarcaNombre
                });
            }

            dg.ItemsSource = null;
            dg.ItemsSource = lstModelo;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarCBMarca(new Marcas());
            cargarGrid(new Modelos());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Modelos m = new Modelos();
            ComboBoxItem cbi = (ComboBoxItem)cbMarca.SelectedItem;
            if (cbMarca.SelectedIndex != 0)
            {
                m.Marca = Convert.ToInt64(cbi.Uid);
            }
            if (!txtNombre.PlaceHolder)
            {                
                m.Nombre = txtNombre.Text;
            }
            cargarGrid(m);
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Modelo w = new Popups.Modelo();
            w.ShowDialog();
            cargarGrid(new Modelos());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Modelos r = ((Button)sender).DataContext as Modelos;
            long lID = r.ID;
            Popups.Modelo w = new Popups.Modelo(lID);
            w.ShowDialog();
            cargarGrid(new Modelos());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
