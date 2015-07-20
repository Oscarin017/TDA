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
using System.Windows.Shapes;
using TDA.Entities;
using TDAWPF.Funcionalidad;

namespace TDAWPF.Popups
{
    /// <summary>
    /// Interaction logic for Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        private long lID = 0;

        public Producto()
        {
            InitializeComponent();
        }

        public Producto(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBTipoProducto(new TipoProductos(), cbTipoProducto);
            Llenado.cargarCBProveedor(new Proveedores(), cbProveedor);
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarProductoID(lID);
                tda.Close();
                foreach (var r in resultado)
                {
                    txtCodigo.IsReadOnly = true;
                    txtCodigo.Text = r.Codigo;                    
                    txtDescripcion.Text = r.Descripcion;
                    Llenado.seleccionarComboBoxUid(r.TipoProducto.ToString(), cbTipoProducto);
                    Llenado.seleccionarComboBoxUid(r.Proveedor.ToString(), cbProveedor);
                    txtPrecioVenta.Text = r.PrecioVenta.ToString();
                    txtPrecioCompra.Text = r.PrecioCompra.ToString();                    
                    if (r.Especial == true)
                    {
                        cbEspecial.IsChecked = true;
                    }
                    if (r.IVAExcento == true)
                    {
                        cbExento.IsChecked = true;
                    }
                    txtIVA.Text = r.IVA.ToString();
                    txtObservacion.Text = r.Observaciones;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if ((cbTipoProducto.SelectedIndex != 0 && !txtCodigo.PlaceHolder && !txtDescripcion.PlaceHolder && !txtPrecioVenta.PlaceHolder) && ((cbExento.IsChecked == false && !txtIVA.PlaceHolder)) || (cbExento.IsChecked == true))
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Productos p = new Productos();
                p.Codigo = txtCodigo.Text;
                p.Descripcion = txtDescripcion.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbTipoProducto.Items[cbTipoProducto.SelectedIndex];
                p.TipoProducto = Convert.ToInt64(cbi.Uid);
                if (cbProveedor.SelectedIndex == 0)
                {
                    p.Proveedor = null;
                }
                else
                {
                    ComboBoxItem cbi2 = (ComboBoxItem)cbProveedor.Items[cbProveedor.SelectedIndex];
                    p.Proveedor = Convert.ToInt64(cbi.Uid);
                }
                p.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                if (txtPrecioCompra.PlaceHolder)
                {
                    p.PrecioCompra = null;
                }
                else
                {
                    p.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                }
                if (cbEspecial.IsChecked == true)
                {
                    p.Servicio = true;
                }
                else
                {
                    p.Servicio = false;
                }
                if (cbExento.IsChecked == true)
                {
                    p.IVAExcento = true;
                    p.IVA = null;
                }
                else
                {
                    p.IVAExcento = false;
                    p.IVA = Convert.ToDecimal(txtIVA.Text);
                }               
                if (txtObservacion.PlaceHolder)
                {
                    p.Observaciones = null;
                }
                else
                {
                    p.Observaciones = txtObservacion.Text;
                }                
                tda.InsertProducto(p);
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if ((cbTipoProducto.SelectedIndex != 0 && !txtCodigo.PlaceHolder && !txtDescripcion.PlaceHolder && !txtPrecioVenta.PlaceHolder) && ((cbExento.IsChecked == false && !txtIVA.PlaceHolder)) || (cbExento.IsChecked == true))
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Productos p = new Productos();                
                p.ID = lID;
                p.Codigo = txtCodigo.Text;
                p.Descripcion = txtDescripcion.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbTipoProducto.Items[cbTipoProducto.SelectedIndex];
                p.TipoProducto = Convert.ToInt64(cbi.Uid);
                if (cbProveedor.SelectedIndex == 0)
                {
                    p.Proveedor = null;
                }
                else
                {
                    ComboBoxItem cbi2 = (ComboBoxItem)cbProveedor.Items[cbProveedor.SelectedIndex];
                    p.Proveedor = Convert.ToInt64(cbi.Uid);
                }
                p.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                if (txtPrecioCompra.PlaceHolder)
                {
                    p.PrecioCompra = null;
                }
                else
                {
                    p.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                }
                if (cbEspecial.IsChecked == true)
                {
                    p.Servicio = true;
                }
                else
                {
                    p.Servicio = false;
                }
                if (cbExento.IsChecked == true)
                {
                    p.IVAExcento = true;
                    p.IVA = null;
                }
                else
                {
                    p.IVAExcento = false;
                    p.IVA = Convert.ToDecimal(txtIVA.Text);
                }
                if (txtObservacion.PlaceHolder)
                {
                    p.Observaciones = null;
                }
                else
                {
                    p.Observaciones = txtObservacion.Text;
                }   
                tda.UpdateProducto(p);
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void cbExento_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.IsChecked == true && cb.IsLoaded)
            {
                txtIVA.Visibility = Visibility.Hidden;
            }
            else if (cb.IsChecked == false && cb.IsLoaded)
            {
                txtIVA.Visibility = Visibility.Visible;
            }
        }
    }
}
