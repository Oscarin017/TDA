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
    /// Interaction logic for Empleado.xaml
    /// </summary>
    public partial class Empleado : Window
    {
        private long lID = 0;

        public Empleado()
        {
            InitializeComponent();
        }

        public Empleado(long ID)
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
            Llenado.cargarCBBaseSalario(cbBaseSalario);
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
                Llenado.seleccionarDefaultPais(cbPais);
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarEmpleadoID(lID);
                tda.Close();
                foreach (var r in resultado)
                {
                    txtApellidoPaterno.Text = r.Apellido;
                    txtApellidoMaterno.Text = r.Apellido2;
                    txtNombre.Text = r.Nombre;
                    if (r.RFC != null)
                    {
                        txtRFC.Text = r.RFC;
                    }
                    txtCURP.Text = r.CURP;
                    if (r.NSS != null)
                    {
                        txtNSS.Text = r.NSS;
                    }
                    Llenado.seleccionarComboBoxUid(r.BaseSalario.ToString(), cbBaseSalario);
                    txtSalario.Text = r.Salario.ToString();
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
            if (!txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder && !txtNombre.PlaceHolder && !txtCURP.PlaceHolder && cbBaseSalario.SelectedIndex != 0 && !txtSalario.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Empleados em = new Empleados();
                em.Apellido = txtApellidoPaterno.Text;
                em.Apellido2 = txtApellidoMaterno.Text;
                em.Nombre = txtNombre.Text;
                if (txtRFC.PlaceHolder)
                {
                    em.RFC = null;
                }
                else
                {
                    em.RFC = txtRFC.Text;
                }
                em.CURP = txtCURP.Text;
                if (txtNSS.PlaceHolder)
                {
                    em.NSS = null;
                }
                else
                {
                    em.NSS = txtNSS.Text;
                }
                ComboBoxItem cbi = (ComboBoxItem)cbBaseSalario.Items[cbBaseSalario.SelectedIndex];
                em.BaseSalario = Convert.ToInt64(cbi.Uid);
                em.Salario = Convert.ToDecimal(txtSalario.Text);
                ComboBoxItem cbi1 = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                em.Pais = Convert.ToInt64(cbi1.Uid);
                ComboBoxItem cbi2 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
                em.Estado = Convert.ToInt64(cbi2.Uid);
                em.Ciudad = txtCiudad.Text;
                if (txtLocalidad.PlaceHolder)
                {
                    em.Localidad = null;
                }
                else
                {
                    em.Localidad = txtLocalidad.Text;
                }
                em.Calle = txtCalle.Text;
                if (txtNumeroExterior.PlaceHolder)
                {
                    em.NumeroExterior = null;
                }
                else
                {
                    em.NumeroExterior = txtNumeroExterior.Text;
                }
                if (txtNumeroInterior.PlaceHolder)
                {
                    em.NumeroInterior = null;
                }
                else
                {
                    em.NumeroInterior = txtNumeroInterior.Text;
                }
                if (txtColonia.PlaceHolder)
                {
                    em.Colonia = null;
                }
                else
                {
                    em.Colonia = txtColonia.Text;
                }
                em.CP = txtCP.Text;
                em.Telefono = txtTelefono.Text;
                if (txtEmail.PlaceHolder)
                {
                    em.Email = null;
                }
                else
                {
                    em.Email = txtEmail.Text;
                }                 
                tda.InsertEmpleado(em);
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
            if (!txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder && !txtNombre.PlaceHolder && !txtCURP.PlaceHolder && cbBaseSalario.SelectedIndex != 0 && !txtSalario.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder && !txtCP.PlaceHolder && !txtTelefono.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Empleados em = new Empleados();
                em.ID = lID;
                em.Apellido = txtApellidoPaterno.Text;
                em.Apellido2 = txtApellidoMaterno.Text;
                em.Nombre = txtNombre.Text;
                if (txtRFC.PlaceHolder)
                {
                    em.RFC = null;
                }
                else
                {
                    em.RFC = txtRFC.Text;
                }
                em.CURP = txtCURP.Text;
                if (txtNSS.PlaceHolder)
                {
                    em.NSS = null;
                }
                else
                {
                    em.NSS = txtNSS.Text;
                }
                ComboBoxItem cbi = (ComboBoxItem)cbBaseSalario.Items[cbBaseSalario.SelectedIndex];
                em.BaseSalario = Convert.ToInt64(cbi.Uid);
                em.Salario = Convert.ToDecimal(txtSalario.Text);
                ComboBoxItem cbi1 = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                em.Pais = Convert.ToInt64(cbi1.Uid);
                ComboBoxItem cbi2 = (ComboBoxItem)cbEstado.Items[cbEstado.SelectedIndex];
                em.Estado = Convert.ToInt64(cbi2.Uid);
                em.Ciudad = txtCiudad.Text;
                if (txtLocalidad.PlaceHolder)
                {
                    em.Localidad = null;
                }
                else
                {
                    em.Localidad = txtLocalidad.Text;
                }
                em.Calle = txtCalle.Text;
                if (txtNumeroExterior.PlaceHolder)
                {
                    em.NumeroExterior = null;
                }
                else
                {
                    em.NumeroExterior = txtNumeroExterior.Text;
                }
                if (txtNumeroInterior.PlaceHolder)
                {
                    em.NumeroInterior = null;
                }
                else
                {
                    em.NumeroInterior = txtNumeroInterior.Text;
                }
                if (txtColonia.PlaceHolder)
                {
                    em.Colonia = null;
                }
                else
                {
                    em.Colonia = txtColonia.Text;
                }
                em.CP = txtCP.Text;
                em.Telefono = txtTelefono.Text;
                if (txtEmail.PlaceHolder)
                {
                    em.Email = null;
                }
                else
                {
                    em.Email = txtEmail.Text;
                }                
                tda.UpdateEmpleado(em);
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
    }
}

