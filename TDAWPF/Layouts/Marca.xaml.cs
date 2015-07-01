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

        private void cargarGrid(Marcas m)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectMarca(m);
            tda.Close();
            lstMarca.Clear();

            foreach (var r in resultado)
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
            Marcas m = new Marcas();
            if (!txtNombre.PlaceHolder)
            {
                m.Nombre = txtNombre.Text;
            }
            cargarGrid(m);
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Marca w = new Popups.Marca();
            w.ShowDialog();
            cargarGrid(new Marcas());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Marcas r = ((Button)sender).DataContext as Marcas;
            long lID = r.ID;
            Popups.Marca w = new Popups.Marca(lID);
            w.ShowDialog();
            cargarGrid(new Marcas());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
