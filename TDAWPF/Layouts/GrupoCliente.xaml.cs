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
    /// Interaction logic for GrupoCliente.xaml
    /// </summary>
    public partial class GrupoCliente : Page
    {
        List<GrupoClientes> lstGC = new List<GrupoClientes>();

        public GrupoCliente()
        {
            InitializeComponent();
        }

        private void cargarGrid(GrupoClientes gc)
        {
            //TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            //var resultado = tda.SelectGrupoCliente(gc);
            //tda.Close();
            //lstGC.Clear();

            //foreach (var r in resultado)
            //{
            //    lstGC.Add(new GrupoClientes()
            //    {
            //        ID = r.ID,
            //        Nombre = r.Nombre
            //    });
            //}

            //dg.ItemsSource = null;
            //dg.ItemsSource = lstGC;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid(new GrupoClientes());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            GrupoClientes gc = new GrupoClientes();
            gc.Nombre = txtNombre.Text;
            cargarGrid(gc);
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.GrupoCliente w = new Popups.GrupoCliente();
            w.ShowDialog();
            cargarGrid(new GrupoClientes());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            GrupoClientes r = ((Button)sender).DataContext as GrupoClientes;
            long lID = r.ID;
            Popups.GrupoCliente w = new Popups.GrupoCliente(lID);
            w.ShowDialog();
            cargarGrid(new GrupoClientes());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
