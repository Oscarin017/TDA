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
    /// Interaction logic for Marca.xaml
    /// </summary>
    public partial class Marca : Page
    {
        List<Marcas> lstMarca = new List<Marcas>();

        public Marca()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Marcas m)
        {
            if (!txtNombre.PlaceHolder)
            {
                m.Nombre = txtNombre.Text;
            }
            cargarGrid(m);
        }

        private void cargarGrid(Marcas m)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectMarca(m);
            tda.Close();
            var ordenado = resultado.OrderBy(Marcas => Marcas.Nombre).ToList();
            lstMarca.Clear();
            foreach (var r in ordenado)
            {
                lstMarca.Add(new Marcas()
                {
                    ID = r.ID,
                    Nombre = r.Nombre
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstMarca;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid(new Marcas());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Marcas());
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Marca w = new Popups.Marca();
            w.ShowDialog();
            realizarBusqueda(new Marcas());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Marcas r = ((Button)sender).DataContext as Marcas;
            long lID = r.ID;
            Popups.Marca w = new Popups.Marca(lID);
            w.ShowDialog();
            realizarBusqueda(new Marcas());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Marcas m = ((Button)sender).DataContext as Marcas;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar la marca " + m.Nombre + ".", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                m = tda.BuscarMarcaID(m.ID).First();
                Resultado r = tda.DeleteMarca(m);
                if (r.ErrorDB)
                {
                    MessageBox.Show("No se pudo eliminar la marca" + m.Nombre + ".");
                }
                realizarBusqueda(new Marcas());
            }
        }    
    }
}
