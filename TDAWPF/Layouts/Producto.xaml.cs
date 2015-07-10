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
    /// Interaction logic for Producto.xaml
    /// </summary>
    public partial class Producto : Page
    {
        List<Productos> lstProducto = new List<Productos>();

        public Producto()
        {
            InitializeComponent();
        }

        private void cargarGrid(Productos p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectProducto(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Productos => Productos.Codigo);
            lstProducto.Clear();
            foreach (var r in ordenado)
            {
                string sNombre = r.ProveedorNombre + " " + r.ProveedorApellido + " " + r.ProveedorApellido2;
                lstProducto.Add(new Productos()
                {
                    ID = r.ID,
                    Codigo = r.Codigo,
                    Descripcion = r.Descripcion,
                    TipoProductoNombre = r.TipoProductoNombre,
                    ProveedorNombre = sNombre,
                    PrecioVenta = r.PrecioVenta
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstProducto;
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBTipoProducto(new TipoProductos(), cbTipo);
            Llenado.cargarCBProveedor(new Proveedores(), cbProveedor);
            cargarGrid(new Productos());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Productos p = new Productos();
            ComboBoxItem cbi = (ComboBoxItem)cbTipo.SelectedItem;
            if (cbTipo.SelectedIndex != 0)
            {
                p.TipoProducto = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1 = (ComboBoxItem)cbProveedor.SelectedItem;
            if (cbProveedor.SelectedIndex != 0)
            {
                p.Proveedor = Convert.ToInt64(cbi1.Uid);
            }
            if (!txtCodigo.PlaceHolder)
            {
                p.Codigo = txtCodigo.Text;
            }
            if (!txtDescripcion.PlaceHolder)
            {
                p.Descripcion = txtDescripcion.Text;
            }
            cargarGrid(p);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Producto w = new Popups.Producto();
            w.ShowDialog();
            cargarGrid(new Productos());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Productos r = ((Button)sender).DataContext as Productos;
            long lID = r.ID;
            Popups.Producto w = new Popups.Producto(lID);
            w.ShowDialog();
            cargarGrid(new Productos());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
