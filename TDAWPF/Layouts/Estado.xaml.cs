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
    /// Interaction logic for Estado.xaml
    /// </summary>
    public partial class Estado : Page
    {
        List<Estados> lstEstado = new List<Estados>();

        public Estado()
        {
            InitializeComponent();
        }

        private void cargarCBPais(Paises p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectPais(p);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbPais.Items.Add(cbi);                
            }
        }

        private void cargarGrid(Estados e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEstado(e);
            tda.Close();
            lstEstado.Clear();

            foreach (var r in resultado)
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
            cargarCBPais(new Paises());
            cargarGrid(new Estados());
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
