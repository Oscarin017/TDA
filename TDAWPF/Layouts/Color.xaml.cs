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
    /// Interaction logic for Color.xaml
    /// </summary>
    public partial class Color : Page
    {
        List<Colores> lstColor = new List<Colores>();

        private void realizarBusqueda(Colores c) 
        {
            if (!txtNombre.PlaceHolder)
            {
                c.Nombre = txtNombre.Text;
            }
            cargarGrid(c);
        }

        public Color()
        {
            InitializeComponent();
        }

        private void cargarGrid(Colores c)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectColor(c);
            tda.Close();
            var ordenado = resultado.OrderBy(Colores => Colores.Nombre).ToList();
            lstColor.Clear();
            foreach (var r in ordenado)
            {
                lstColor.Add(new Colores()
                {
                    ID = r.ID,
                    Nombre = r.Nombre
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstColor;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid(new Colores());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Colores());
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Color w = new Popups.Color();
            w.ShowDialog();
            realizarBusqueda(new Colores());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Colores r = ((Button)sender).DataContext as Colores;
            long lID = r.ID;
            Popups.Color w = new Popups.Color(lID);
            w.ShowDialog();
            realizarBusqueda(new Colores());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Colores c = ((Button)sender).DataContext as Colores;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar el color " +  c.Nombre + ".","Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                c = tda.BuscarColorID(c.ID).First();
                Resultado r = tda.DeleteColor(c);
                if (r.ErrorDB)
                {
                    MessageBox.Show("No se pudo eliminar el estado " + es.Nombre + ".");
                }
                realizarBusqueda(new Colores());
            }
        }    
    }
}
