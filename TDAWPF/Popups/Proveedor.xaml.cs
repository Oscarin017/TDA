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
    /// Interaction logic for Proveedor.xaml
    /// </summary>
    public partial class Proveedor : Window
    {
        private long lID = 0;

        public Proveedor()
        {
            InitializeComponent();
        }

        public Proveedor(long ID)
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
            Llenado.cargarCBPais(new Paises(), cbPais);
            Llenado.cargarCBEstado(new Estados(), cbEstado);
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
                Llenado.seleccionarDefaultPais(cbPais);
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarProveedorID(lID);
                tda.Close();
                foreach (var r in resultado)
                {
                    if (r.Tipo)
                    {
                        rbMoral.IsChecked = true;
                    }
                    else
                    {
                        txtApellidoPaterno.Text = r.Apellido;
                        txtApellidoMaterno.Text = r.Apellido2;
                    }                    
                    txtNombre.Text = r.Nombre;
                    txtRFC.Text = r.RFC;
                    Llenado.seleccionarComboBoxUid(r.Pais.ToString(), cbPais);
                    Llenado.seleccionarComboBoxUid(r.Estado.ToString(), cbEstado);
                    txtCiudad.Text = r.Ciudad;
                    if (r.Localidad != null)
                    {
                        txtLocalidad.Text = r.Localidad;
                    }
                    txtCalle.Text = r.Calle;
                    if (r.NumeroExterior != null)
                    {
                        txtNumeroExterior.Text = r.NumeroExterior;
                    }
                    if (r.NumeroInterior != null)
                    {
                        txtNumeroInterior.Text = r.NumeroInterior;
                    }
                    if (r.Colonia != null)
                    {
                        txtColonia.Text = r.Colonia;
                    }
                    txtCP.Text = r.CP.ToString();
                    txtTelefono.Text = r.Telefono;
                    if (r.Email != null)
                    {
                        txtEmail.Text = r.Email;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if ((!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder) && ((rbFisica.IsChecked == true && !txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder) || (rbMoral.IsChecked == true)))
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Proveedores p = new Proveedores();
                if (rbMoral.IsChecked == true)
                {
                    p.Tipo = true;
                    p.Apellido = null;
                    p.Apellido2 = null;
                }
                else if (rbFisica.IsChecked == true)
                {
                    p.Tipo = false;
                    p.Apellido = txtApellidoPaterno.Text;
                    p.Apellido2 = txtApellidoMaterno.Text;
                }
                p.Nombre = txtNombre.Text;
                if (txtRFC.PlaceHolder)
                {
                    p.RFC = null;
                }
                else
                {
                    p.RFC = txtRFC.Text;
                }
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                p.Pais = Convert.ToInt64(cbi.Uid);
                ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
                p.Estado = Convert.ToInt64(cbi1.Uid);
                p.Ciudad = txtCiudad.Text;
                if (txtLocalidad.PlaceHolder)
                {
                    p.Localidad = null;
                }
                else
                {
                    p.Localidad = txtLocalidad.Text;
                }
                p.Calle = txtCalle.Text;
                if (txtNumeroExterior.PlaceHolder)
                {
                    p.NumeroExterior = null;
                }
                else
                {
                    p.NumeroExterior = txtNumeroExterior.Text;
                }
                if (txtNumeroInterior.PlaceHolder)
                {
                    p.NumeroInterior = null;
                }
                else
                {
                    p.NumeroInterior = txtNumeroInterior.Text;
                }
                if (txtColonia.PlaceHolder)
                {
                    p.Colonia = null;
                }
                else
                {
                    p.Colonia = txtColonia.Text;
                }
                p.CP = txtCP.Text;
                p.Telefono = txtTelefono.Text;
                if (txtEmail.PlaceHolder)
                {
                    p.Email = null;
                }
                else
                {
                    p.Email = txtEmail.Text;
                }                                 
                tda.InsertProveedor(p);
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
            if ((!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder) && ((rbFisica.IsChecked == true && !txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder) || (rbMoral.IsChecked == true)))
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Proveedores p = new Proveedores();
                if (rbMoral.IsChecked == true)
                {
                    p.Tipo = true;
                    p.Apellido = null;
                    p.Apellido2 = null;
                }
                else if (rbFisica.IsChecked == true)
                {
                    p.Tipo = false;
                    p.Apellido = txtApellidoPaterno.Text;
                    p.Apellido2 = txtApellidoMaterno.Text;
                }
                p.ID = lID;
                p.Apellido = txtApellidoPaterno.Text;
                p.Apellido2 = txtApellidoMaterno.Text;
                p.Nombre = txtNombre.Text;
                if (txtRFC.PlaceHolder)
                {
                    p.RFC = null;
                }
                else
                {
                    p.RFC = txtRFC.Text;
                }
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                p.Pais = Convert.ToInt64(cbi.Uid);
                ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
                p.Estado = Convert.ToInt64(cbi1.Uid);
                p.Ciudad = txtCiudad.Text;
                if (txtLocalidad.PlaceHolder)
                {
                    p.Localidad = null;
                }
                else
                {
                    p.Localidad = txtLocalidad.Text;
                }
                p.Calle = txtCalle.Text;
                if (txtNumeroExterior.PlaceHolder)
                {
                    p.NumeroExterior = null;
                }
                else
                {
                    p.NumeroExterior = txtNumeroExterior.Text;
                }
                if (txtNumeroInterior.PlaceHolder)
                {
                    p.NumeroInterior = null;
                }
                else
                {
                    p.NumeroInterior = txtNumeroInterior.Text;
                }
                if (txtColonia.PlaceHolder)
                {
                    p.Colonia = null;
                }
                else
                {
                    p.Colonia = txtColonia.Text;
                }
                p.CP = txtCP.Text;
                p.Telefono = txtTelefono.Text;
                if (txtEmail.PlaceHolder)
                {
                    p.Email = null;
                }
                else
                {
                    p.Email = txtEmail.Text;
                }                         
                tda.UpdateProveedor(p);
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
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

        private void rTipo_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Content.ToString() == "Moral")
            {
                txtApellidoPaterno.Visibility = Visibility.Collapsed;
                txtApellidoMaterno.Visibility = Visibility.Collapsed;
            }
            else if (rb.Content.ToString() == "Fisica" && rb.IsLoaded)
            {
                txtApellidoPaterno.Visibility = Visibility.Visible;
                txtApellidoMaterno.Visibility = Visibility.Visible;
            }
        }
    }
}
