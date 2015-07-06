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

        private void cargarCBEstado(Estados e)
        {
            cbEstado.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEstado(e);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbEstado.Items.Add(cbi);
            }
        }

        public void cargarCBBaseSalario()
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectBaseSalario();
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbBaseSalario.Items.Add(cbi);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarCBPais(new Paises());
            cargarCBEstado(new Estados());
            cargarCBBaseSalario();
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
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
                    txtRFC.Text = r.RFC;
                    txtCURP.Text = r.CURP;
                    txtNSS.Text = r.NSS;
                    cbBaseSalario.SelectedIndex = Convert.ToInt32(r.BaseSalario);
                    txtSalario.Text = r.Salario.ToString();
                    cbPais.SelectedIndex = Convert.ToInt32(r.Pais);
                    cbEstado.SelectedIndex = Convert.ToInt32(r.Estado);
                    txtCiudad.Text = r.Ciudad;
                    txtLocalidad.Text = r.Localidad;
                    txtCalle.Text = r.Calle;
                    txtNumeroExterior.Text = r.NumeroExterior;
                    txtNumeroInterior.Text = r.NumeroInterior;
                    txtColonia.Text = r.Colonia;
                    txtCP.Text = r.CP.ToString();
                    txtTelefono.Text = r.Telefono;
                    txtEmail.Text = r.Email;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder && !txtCURP.PlaceHolder && !txtNombre.PlaceHolder && cbBaseSalario.SelectedIndex != 0 && !txtSalario.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Empleados em = new Empleados();
                em.Apellido = txtApellidoPaterno.Text;
                em.Apellido2 = txtApellidoMaterno.Text;
                em.Nombre = txtNombre.Text;
                em.RFC = txtRFC.Text;
                em.CURP = txtCURP.Text;
                em.NSS = txtNSS.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbBaseSalario.SelectedIndex];
                em.BaseSalario = Convert.ToInt64(cbi.Uid);
                em.Salario = Convert.ToDecimal(txtSalario.Text);
                ComboBoxItem cbi1 = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                em.Pais = Convert.ToInt64(cbi.Uid);
                ComboBoxItem cbi2 = (ComboBoxItem)cbPais.Items[cbEstado.SelectedIndex];
                em.Estado = Convert.ToInt64(cbi2.Uid);
                em.Ciudad = txtCiudad.Text;
                em.Localidad = txtLocalidad.Text;
                em.Calle = txtCalle.Text;
                em.NumeroExterior = txtNumeroExterior.Text;
                em.NumeroInterior= txtNumeroInterior.Text;
                em.Colonia = txtColonia.Text;
                em.CP = Convert.ToInt32(txtCP.Text);
                em.Telefono = txtTelefono.Text;
                em.Email = txtEmail.Text;                
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
            if (!txtApellidoPaterno.PlaceHolder && !txtApellidoMaterno.PlaceHolder && !txtCURP.PlaceHolder && !txtNombre.PlaceHolder && cbBaseSalario.SelectedIndex != 0 && !txtSalario.PlaceHolder && cbPais.SelectedIndex != 0 && cbEstado.SelectedIndex != 0 && !txtCiudad.PlaceHolder && !txtCalle.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Empleados em = new Empleados();
                em.ID = lID;
                em.Apellido = txtApellidoPaterno.Text;
                em.Apellido2 = txtApellidoMaterno.Text;
                em.Nombre = txtNombre.Text;
                em.RFC = txtRFC.Text;
                em.CURP = txtCURP.Text;
                em.NSS = txtNSS.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbBaseSalario.SelectedIndex];
                em.BaseSalario = Convert.ToInt64(cbi.Uid);
                em.Salario = Convert.ToDecimal(txtSalario.Text);
                ComboBoxItem cbi1 = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                em.Pais = Convert.ToInt64(cbi.Uid);
                ComboBoxItem cbi2 = (ComboBoxItem)cbPais.Items[cbEstado.SelectedIndex];
                em.Estado = Convert.ToInt64(cbi2.Uid);
                em.Ciudad = txtCiudad.Text;
                em.Localidad = txtLocalidad.Text;
                em.Calle = txtCalle.Text;
                em.NumeroExterior = txtNumeroExterior.Text;
                em.NumeroInterior = txtNumeroInterior.Text;
                em.Colonia = txtColonia.Text;
                em.CP = Convert.ToInt32(txtCP.Text);
                em.Telefono = txtTelefono.Text;
                em.Email = txtEmail.Text;   
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
            if (cbPais.SelectedIndex != 0)
            {
                Estados es = new Estados();
                ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
                es.Pais = Convert.ToInt64(cbi.Uid);
                cargarCBEstado(es);
            }
        }
    }
}

