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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        private long lID = 0;
        private long lPais = 0;
        private long lEstado = 0;

        public Cliente()
        {
            InitializeComponent();
        }

        public Cliente(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private bool validacionCampos()
        {
            bool bValidacion = true;
            bool bTipoRFC = false;
            if(rbMoral.IsChecked == true)
            {
                bTipoRFC = true;
            }
            if (!txtRFC.PlaceHolder)
            {
                if (!Llenado.validacionRFC(txtRFC.Text, bTipoRFC))
                {
                    bValidacion = false;
                }
            }
            if(!txtCP.PlaceHolder)
            {
                if(!Llenado.validacionCP(txtCP.Text))
                {
                    bValidacion = false;
                }
            }
            if (!txtTelefono.PlaceHolder)
            {
                if (!Llenado.validacionTelefono(txtTelefono.Text))
                {
                    bValidacion = false;
                }
            }
            if (!txtEmail.PlaceHolder)
            {
                if (!Llenado.validacionEMail(txtEmail.Text))
                {
                    bValidacion = false;
                }
            }
            return bValidacion;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBPais(new Paises(), cbPais);
            Llenado.cargarCBEstado(new Estados(), cbEstado);
            Llenado.cargarCBGrupoCliente(new GrupoClientes(), cbGrupoCliente);
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
                Llenado.seleccionarDefaultPais(cbPais);
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarClienteID(lID);
                tda.Close();
                foreach (var r in resultado)
                {
                    if (r.Tipo == true)
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
                    if (r.GrupoCliente != null)
                    {
                        Llenado.seleccionarComboBoxUid(r.GrupoCliente.ToString(), cbGrupoCliente);
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if ((!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder) && ((rbFisica.IsChecked == true && !txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder) || (rbMoral.IsChecked == true)))
            {
                if (validacionCampos())
                {
                    TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                    Clientes c = new Clientes();
                    if (rbMoral.IsChecked == true)
                    {
                        c.Tipo = true;
                        c.Apellido = null;
                        c.Apellido2 = null;
                    }
                    else if (rbFisica.IsChecked == true)
                    {
                        c.Tipo = false;
                        c.Apellido = txtApellidoPaterno.Text;
                        c.Apellido2 = txtApellidoMaterno.Text;
                    }
                    c.Nombre = txtNombre.Text;
                    if (txtRFC.PlaceHolder)
                    {
                        c.RFC = "XAXX010101000";
                    }
                    else
                    {
                        c.RFC = txtRFC.Text;
                    }
                    ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                    c.Pais = Convert.ToInt64(cbi.Uid);
                    ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
                    c.Estado = Convert.ToInt64(cbi1.Uid);
                    c.Ciudad = txtCiudad.Text;
                    if (txtLocalidad.PlaceHolder)
                    {
                        c.Localidad = null;
                    }
                    else
                    {
                        c.Localidad = txtLocalidad.Text;
                    }
                    c.Calle = txtCalle.Text;
                    if (txtNumeroExterior.PlaceHolder)
                    {
                        c.NumeroExterior = null;
                    }
                    else
                    {
                        c.NumeroExterior = txtNumeroExterior.Text;
                    }
                    if (txtNumeroInterior.PlaceHolder)
                    {
                        c.NumeroInterior = null;
                    }
                    else
                    {
                        c.NumeroInterior = txtNumeroInterior.Text;
                    }
                    if (txtColonia.PlaceHolder)
                    {
                        c.Colonia = null;
                    }
                    else
                    {
                        c.Colonia = txtColonia.Text;
                    }
                    c.CP = txtCP.Text;
                    c.Telefono = txtTelefono.Text;
                    if (txtEmail.PlaceHolder)
                    {
                        c.Email = null;
                    }
                    else
                    {
                        c.Email = txtEmail.Text;
                    }
                    if (cbGrupoCliente.SelectedIndex == 0)
                    {
                        c.GrupoCliente = null;
                    }
                    else
                    {
                        ComboBoxItem cbi2 = (ComboBoxItem)cbGrupoCliente.Items[cbGrupoCliente.SelectedIndex];
                        c.GrupoCliente = Convert.ToInt64(cbi.Uid);
                    }
                    tda.InsertCliente(c);
                    tda.Close();
                    this.Close();
                }
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
                Clientes c = new Clientes();
                if (rbMoral.IsChecked == true)
                {
                    c.Tipo = true;
                    c.Apellido = null;
                    c.Apellido2 = null;
                }
                else if (rbFisica.IsChecked == true)
                {
                    c.Tipo = false;
                    c.Apellido = txtApellidoPaterno.Text;
                    c.Apellido2 = txtApellidoMaterno.Text;
                }
                c.ID = lID;
                c.Apellido = txtApellidoPaterno.Text;
                c.Apellido2 = txtApellidoMaterno.Text;
                c.Nombre = txtNombre.Text;
                if (txtRFC.PlaceHolder)
                {
                    c.RFC = null;
                }
                else
                {
                    c.RFC = txtRFC.Text;
                }
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                c.Pais = Convert.ToInt64(cbi.Uid);
                ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
                c.Estado = Convert.ToInt64(cbi1.Uid);
                c.Ciudad = txtCiudad.Text;
                if (txtLocalidad.PlaceHolder)
                {
                    c.Localidad = null;
                }
                else
                {
                    c.Localidad = txtLocalidad.Text;
                }
                c.Calle = txtCalle.Text;
                if (txtNumeroExterior.PlaceHolder)
                {
                    c.NumeroExterior = null;
                }
                else
                {
                    c.NumeroExterior = txtNumeroExterior.Text;
                }
                if (txtNumeroInterior.PlaceHolder)
                {
                    c.NumeroInterior = null;
                }
                else
                {
                    c.NumeroInterior = txtNumeroInterior.Text;
                }
                if (txtColonia.PlaceHolder)
                {
                    c.Colonia = null;
                }
                else
                {
                    c.Colonia = txtColonia.Text;
                }
                c.CP = txtCP.Text;
                c.Telefono = txtTelefono.Text;
                if (txtEmail.PlaceHolder)
                {
                    c.Email = null;
                }
                else
                {
                    c.Email = txtEmail.Text;
                }
                if (cbGrupoCliente.SelectedIndex == 0)
                {
                    c.GrupoCliente = null;
                }
                else
                {
                    ComboBoxItem cbi2 = (ComboBoxItem)cbGrupoCliente.Items[cbGrupoCliente.SelectedIndex];
                    c.GrupoCliente = Convert.ToInt64(cbi.Uid);
                }    
                tda.UpdateCliente(c);
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
            if (this.IsLoaded)
            {
                es.Pais = lPais = Convert.ToInt64(cbi.Uid);
                Llenado.cargarCBEstado(es, cbEstado);
            }
        }

        private void cbEstado_SelectionChanged(object sender, EventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            Estados es = new Estados();
            ComboBoxItem cbi = (ComboBoxItem)cbEstado.SelectedItem;
            if (this.IsLoaded)
            {
                if (cbEstado.SelectedIndex > 0)
                {
                    es = tda.BuscarEstadoID(Convert.ToInt64(cbi.Uid)).First();
                    lEstado = es.ID;
                    if (lPais == 0)
                    {
                        Llenado.seleccionarComboBoxUid(es.Pais.ToString(), cbPais);
                        Llenado.seleccionarComboBoxUid(lEstado.ToString(), cbEstado);
                    }
                }
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
