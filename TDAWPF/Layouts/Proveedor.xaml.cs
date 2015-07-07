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
    /// Interaction logic for Proveedor.xaml
    /// </summary>
    public partial class Proveedor : Page
    {
        List<Proveedores> lstProveedor = new List<Proveedores>();

        public Proveedor()
        {
            InitializeComponent();
        }

        private void cargarGrid(Proveedores p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectProveedor(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Proveedores => Proveedores.RFC);
            lstProveedor.Clear();
            foreach (var r in ordenado)
            {
                string sNombre = "";
                if (r.Tipo)
                {
                    sNombre = r.Nombre;
                }
                else
                {
                    sNombre = r.Apellido + " " + r.Apellido2 + " " + r.Nombre;
                }
                lstProveedor.Add(new Proveedores()
                {
                    ID = r.ID,
                    Nombre = sNombre,
                    RFC = r.RFC,
                    Telefono = r.Telefono
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstProveedor;
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBPais(new Paises(), cbPais);
            Llenado.cargarCBEstado(new Estados(), cbEstado);
            cargarGrid(new Proveedores());
            Llenado.seleccionarDefaultPais(cbPais);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Proveedores p = new Proveedores();
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                p.Pais = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.SelectedItem;
            if (cbEstado.SelectedIndex != 0)
            {
                p.Estado = Convert.ToInt64(cbi1.Uid);
            }
            if (!txtNombre.PlaceHolder)
            {
                p.Nombre = txtNombre.Text;
            }
            if (!txtRFC.PlaceHolder)
            {
                p.RFC = txtRFC.Text;
            }
            cargarGrid(p);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Proveedor w = new Popups.Proveedor();
            w.ShowDialog();
            cargarGrid(new Proveedores());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Proveedores r = ((Button)sender).DataContext as Proveedores;
            long lID = r.ID;
            Popups.Proveedor w = new Popups.Proveedor(lID);
            w.ShowDialog();
            cargarGrid(new Proveedores());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbPais_SelectionChanged(object sender, EventArgs e)
        {
            Estados es = new Estados();
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                es.Pais = Convert.ToInt64(cbi.Uid);
            }
            if (this.IsLoaded)
            {
                Llenado.cargarCBEstado(es, cbEstado);
            }        
        }
    }
}
