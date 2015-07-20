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
    /// Interaction logic for Modelo.xaml
    /// </summary>
    public partial class Modelo : Page
    {
        List<Modelos> lstModelo = new List<Modelos>();

        public Modelo()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Modelos m)
        {
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

        private void cargarGrid(Modelos m)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectModelo(m);
            tda.Close();
            var ordenado = resultado.OrderBy(Modelos => Modelos.MarcaNombre).ToList();
            lstModelo.Clear();
            foreach (var r in ordenado)
            {
                lstModelo.Add(new Modelos()
                {
                    ID = r.ID,
                    Nombre = r.Nombre,
                    MarcaNombre = r.MarcaNombre,
                    Ano = r.Ano
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstModelo;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBMarca(new Marcas(), cbMarca);
            cargarGrid(new Modelos());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Modelos());
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Modelo w = new Popups.Modelo();
            w.ShowDialog();
            realizarBusqueda(new Modelos());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Modelos r = ((Button)sender).DataContext as Modelos;
            long lID = r.ID;
            Popups.Modelo w = new Popups.Modelo(lID);
            w.ShowDialog();
            realizarBusqueda(new Modelos());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Modelos m = ((Button)sender).DataContext as Modelos;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar el modelo " + m.Nombre + ".", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                m = tda.BuscarModeloID(m.ID).First();
                Resultado r = tda.DeleteModelo(m);
                if (r.ErrorDB)
                {
                    MessageBox.Show("No se pudo eliminar el modelo" + m.Nombre + ".");
                }
                realizarBusqueda(new Modelos());
            }
        }        
    }
}
