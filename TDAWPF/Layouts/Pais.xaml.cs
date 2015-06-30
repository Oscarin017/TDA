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
    /// Interaction logic for Pais.xaml
    /// </summary>
    public partial class Pais : Page
    {
        List<Paises> lstPais = new List<Paises>();

        public Pais()
        {
            InitializeComponent();
        }

        private void cargarGrid(Paises p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectPais(p);
            tda.Close();
            lstPais.Clear();

            foreach (var r in resultado)
            {
                lstPais.Add(new Paises()
                {
                    ID = r.ID,
                    Nombre = r.Nombre
                });
            }

            dg.ItemsSource = null;
            dg.ItemsSource = lstPais;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid(new Paises());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Paises p = new Paises();
            p.Nombre = txtNombre.Text;
            cargarGrid(p);
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Pais w = new Popups.Pais();
            w.ShowDialog();
            cargarGrid(new Paises());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Paises r = ((Button)sender).DataContext as Paises;
            long lID = r.ID;
            Popups.Pais w = new Popups.Pais(lID);
            w.ShowDialog();
            cargarGrid(new Paises());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
