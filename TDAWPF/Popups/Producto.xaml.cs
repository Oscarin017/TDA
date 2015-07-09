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
            //Llenado.cargarCBTipoProducto(new TipoProductos(), cbTipoProducto);
            //Llenado.cargarCBProveedor(new Proveedores(), cbProveedor);
            //if (lID == 0)
            //{
            //    btnRegistrar.Visibility = Visibility.Visible;
            //}
            //else if (lID != 0)
            //{
            //    btnModificar.Visibility = Visibility.Visible;
            //    TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            //    var resultado = tda.BuscarProductoID(lID);
            //    tda.Close();
            //    foreach (var r in resultado)
            //    {
            //        txtCodigo.Text = r.Codigo;
            //        txtDescripcion.Text = r.Descripcion;
            //        Llenado.seleccionarComboBoxUid(r.TipoProducto.ToString(), cbTipoProducto);
            //        Llenado.seleccionarComboBoxUid(r.Proveedor.ToString(), cbProveedor);
            //        txtPrecioVenta.Text = r.PrecioVenta;
            //        txtPrecioCompra.Text = r.PrecioCompra;
            //        if (r.Servicio == true)
            //        {
            //            cbEspecial.IsChecked = true;
            //        }
            //        if (r.IVAExcento == true)
            //        {
            //            cbExento.IsChecked = true;
            //        }
            //        txtIVA.Text = r.
            //        txtCiudad.Text = r.Ciudad;
            //        if (r.Localidad != null)
            //        {
            //            txtLocalidad.Text = r.Localidad;
            //        }
            //        txtCalle.Text = r.Calle;
            //        if (r.NumeroExterior != null)
            //        {
            //            txtNumeroExterior.Text = r.NumeroExterior;
            //        }
            //        if (r.NumeroInterior != null)
            //        {
            //            txtNumeroInterior.Text = r.NumeroInterior;
            //        }
            //        if (r.Colonia != null)
            //        {
            //            txtColonia.Text = r.Colonia;
            //        }
            //        txtCP.Text = r.CP.ToString();
            //        txtTelefono.Text = r.Telefono;
            //        if (r.Email != null)
            //        {
            //            txtEmail.Text = r.Email;
            //        }
            //        if (r.GrupoProducto != null)
            //        {
            //            Llenado.seleccionarComboBoxUid(r.GrupoProducto.ToString(), cbGrupoProducto);
            //        }
                //}
            //}
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            //if ((!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder) && ((rbFisica.IsChecked == true && !txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder) || (rbMoral.IsChecked == true)))
            //{
            //    TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            //    Productos c = new Productos();
            //    if (rbMoral.IsChecked == true)
            //    {
            //        c.Tipo = true;
            //        c.Apellido = null;
            //        c.Apellido2 = null;
            //    }
            //    else if (rbFisica.IsChecked == true)
            //    {
            //        c.Tipo = false;
            //        c.Apellido = txtApellidoPaterno.Text;
            //        c.Apellido2 = txtApellidoMaterno.Text;
            //    }
            //    c.Nombre = txtNombre.Text;
            //    if (txtRFC.PlaceHolder)
            //    {
            //        c.RFC = null;
            //    }
            //    else
            //    {
            //        c.RFC = txtRFC.Text;
            //    }
            //    ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
            //    c.Pais = Convert.ToInt64(cbi.Uid);
            //    ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
            //    c.Estado = Convert.ToInt64(cbi1.Uid);
            //    c.Ciudad = txtCiudad.Text;
            //    if (txtLocalidad.PlaceHolder)
            //    {
            //        c.Localidad = null;
            //    }
            //    else
            //    {
            //        c.Localidad = txtLocalidad.Text;
            //    }
            //    c.Calle = txtCalle.Text;
            //    if (txtNumeroExterior.PlaceHolder)
            //    {
            //        c.NumeroExterior = null;
            //    }
            //    else
            //    {
            //        c.NumeroExterior = txtNumeroExterior.Text;
            //    }
            //    if (txtNumeroInterior.PlaceHolder)
            //    {
            //        c.NumeroInterior = null;
            //    }
            //    else
            //    {
            //        c.NumeroInterior = txtNumeroInterior.Text;
            //    }
            //    if (txtColonia.PlaceHolder)
            //    {
            //        c.Colonia = null;
            //    }
            //    else
            //    {
            //        c.Colonia = txtColonia.Text;
            //    }
            //    c.CP = Convert.ToInt32(txtCP.Text);
            //    c.Telefono = txtTelefono.Text;
            //    if (txtEmail.PlaceHolder)
            //    {
            //        c.Email = null;
            //    }
            //    else
            //    {
            //        c.Email = txtEmail.Text;
            //    }
            //    if (cbGrupoProducto.SelectedIndex == 0)
            //    {
            //        c.GrupoProducto = null;
            //    }
            //    else
            //    {
            //        ComboBoxItem cbi2 = (ComboBoxItem)cbGrupoProducto.Items[cbGrupoProducto.SelectedIndex];
            //        c.GrupoProducto = Convert.ToInt64(cbi.Uid);
            //    }                 
            //    tda.InsertProducto(c);
            //    tda.Close();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Favor de llenar los campos.");
            //}
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //if ((!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder) && ((rbFisica.IsChecked == true && !txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder) || (rbMoral.IsChecked == true)))
            //{
            //    TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            //    Productos c = new Productos();
            //    if (rbMoral.IsChecked == true)
            //    {
            //        c.Tipo = true;
            //        c.Apellido = null;
            //        c.Apellido2 = null;
            //    }
            //    else if (rbFisica.IsChecked == true)
            //    {
            //        c.Tipo = false;
            //        c.Apellido = txtApellidoPaterno.Text;
            //        c.Apellido2 = txtApellidoMaterno.Text;
            //    }
            //    c.ID = lID;
            //    c.Apellido = txtApellidoPaterno.Text;
            //    c.Apellido2 = txtApellidoMaterno.Text;
            //    c.Nombre = txtNombre.Text;
            //    if (txtRFC.PlaceHolder)
            //    {
            //        c.RFC = null;
            //    }
            //    else
            //    {
            //        c.RFC = txtRFC.Text;
            //    }
            //    ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
            //    c.Pais = Convert.ToInt64(cbi.Uid);
            //    ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
            //    c.Estado = Convert.ToInt64(cbi1.Uid);
            //    c.Ciudad = txtCiudad.Text;
            //    if (txtLocalidad.PlaceHolder)
            //    {
            //        c.Localidad = null;
            //    }
            //    else
            //    {
            //        c.Localidad = txtLocalidad.Text;
            //    }
            //    c.Calle = txtCalle.Text;
            //    if (txtNumeroExterior.PlaceHolder)
            //    {
            //        c.NumeroExterior = null;
            //    }
            //    else
            //    {
            //        c.NumeroExterior = txtNumeroExterior.Text;
            //    }
            //    if (txtNumeroInterior.PlaceHolder)
            //    {
            //        c.NumeroInterior = null;
            //    }
            //    else
            //    {
            //        c.NumeroInterior = txtNumeroInterior.Text;
            //    }
            //    if (txtColonia.PlaceHolder)
            //    {
            //        c.Colonia = null;
            //    }
            //    else
            //    {
            //        c.Colonia = txtColonia.Text;
            //    }
            //    c.CP = Convert.ToInt32(txtCP.Text);
            //    c.Telefono = txtTelefono.Text;
            //    if (txtEmail.PlaceHolder)
            //    {
            //        c.Email = null;
            //    }
            //    else
            //    {
            //        c.Email = txtEmail.Text;
            //    }
            //    if (cbGrupoProducto.SelectedIndex == 0)
            //    {
            //        c.GrupoProducto = null;
            //    }
            //    else
            //    {
            //        ComboBoxItem cbi2 = (ComboBoxItem)cbGrupoProducto.Items[cbGrupoProducto.SelectedIndex];
            //        c.GrupoProducto = Convert.ToInt64(cbi.Uid);
            //    }    
            //    tda.UpdateProducto(c);
            //    tda.Close();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Favor de llenar los campos.");
            //}
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
