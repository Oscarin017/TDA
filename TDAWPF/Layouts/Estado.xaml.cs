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
    /// Interaction logic for Estado.xaml
    /// </summary>
    public partial class Estado : Page
    {
        List<Estados> lstEstado = new List<Estados>();

        public Estado()
        {
            InitializeComponent();
        }

        private void cargarGrid(Estados e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEstado(e);
            tda.Close();
            var ordenado = resultado.OrderBy(Estados => Estados.PaisNombre).ToList();
            lstEstado.Clear();
            foreach (var r in ordenado)
            {
                lstEstado.Add(new Estados()
                {
                    ID = r.ID,
                    Nombre = r.Nombre,
                    PaisNombre = r.PaisNombre
                });
            }

            dg.ItemsSource = null;
            dg.ItemsSource = lstEstado;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBPais(new Paises(), cbPais);
            cargarGrid(new Estados());
            Llenado.seleccionarDefaultPais(cbPais);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Estados es = new Estados();
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                es.Pais = Convert.ToInt64(cbi.Uid);
            }
            if (!txtNombre.PlaceHolder)
            {                
                es.Nombre = txtNombre.Text;
            }
            cargarGrid(es);
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Estado w = new Popups.Estado();
            w.ShowDialog();
            cargarGrid(new Estados());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Estados r = ((Button)sender).DataContext as Estados;
            long lID = r.ID;
            Popups.Estado w = new Popups.Estado(lID);
            w.ShowDialog();
            cargarGrid(new Estados());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
