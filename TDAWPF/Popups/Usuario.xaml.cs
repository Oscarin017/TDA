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
    /// Interaction logic for Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        private long lID = 0;

        public Usuario()
        {
            InitializeComponent();
        }

        public Usuario(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private void cargarCBRol()
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectRol();
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbRol.Items.Add(cbi);
            }
        }

        private void cargarCBEmpleado()
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEmpleado(new Empleados());
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre + " " + r.Apellido + " " + r.Apellido2;
                cbEmpleado.Items.Add(cbi);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarCBRol();
            cargarCBEmpleado();
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarUsuarioID(lID);
                tda.Close();

                foreach (var r in resultado)
                {
                    cbRol.SelectedIndex = Convert.ToInt32(r.Rol);
                    txtAlias.Text = r.Alias;
                    txtContraseña.Text = r.Contraseña;
                    if (r.Empleado != null)
                    {
                        cbEmpleado.SelectedIndex = Convert.ToInt32(r.Empleado);
                        rbEmpleado.IsChecked = true;
                    }
                    else if (r.Empleado == null) ;
                    {
                        txtEmail.Text = r.Email;
                        rbFuera.IsChecked = true;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if ((!txtAlias.PlaceHolder && cbRol.SelectedIndex != 0 && !txtContraseña.PlaceHolder) && ((rbEmpleado.IsChecked == true && cbEmpleado.Visibility == Visibility.Visible && cbEmpleado.SelectedIndex != 0) || (rbFuera.IsChecked == true && txtEmail.Visibility == Visibility.Visible && !txtEmail.PlaceHolder)))
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Usuarios u = new Usuarios();
                u.Alias = txtAlias.Text;
                u.Contraseña = txtContraseña.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbRol.Items[cbRol.SelectedIndex];
                u.Rol = Convert.ToInt64(cbi.Uid);
                if (rbEmpleado.IsChecked == true)
                {
                    ComboBoxItem cbi1 = (ComboBoxItem)cbEmpleado.Items[cbRol.SelectedIndex];
                    u.Empleado = Convert.ToInt64(cbi.Uid);
                    u.Email = null;
                }
                else if (rbFuera.IsChecked == true)
                {
                    u.Email = txtEmail.Text;
                    u.Empleado = null;
                }
                tda.InsertUsuario(u);
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
            if ((!txtAlias.PlaceHolder && cbRol.SelectedIndex != 0 && !txtContraseña.PlaceHolder) && ((rbEmpleado.IsChecked == true && cbEmpleado.Visibility == Visibility.Visible && cbEmpleado.SelectedIndex != 0) || (rbFuera.IsChecked == true && txtEmail.Visibility == Visibility.Visible && !txtEmail.PlaceHolder)))
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Usuarios u = new Usuarios();
                u.ID = lID;
                u.Alias = txtAlias.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbRol.Items[cbRol.SelectedIndex];
                u.Rol = Convert.ToInt64(cbi.Uid);
                if (rbEmpleado.IsChecked == true)
                {
                    ComboBoxItem cbi1 = (ComboBoxItem)cbEmpleado.Items[cbRol.SelectedIndex];
                    u.Empleado = Convert.ToInt64(cbi.Uid);
                    u.Email = null;
                }
                else if (rbFuera.IsChecked == true)
                {
                    u.Email = txtEmail.Text;
                    u.Empleado = null;
                }
                tda.UpdateUsuario(u);
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void rTipo_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (this.IsLoaded)
            {

                if (rb.Content.ToString() == "Empleado")
                {
                    cbEmpleado.Visibility = Visibility.Visible;
                    txtEmail.Visibility = Visibility.Collapsed;
                }
                else if (rb.Content.ToString() == "Fuera")
                {
                    txtEmail.Visibility = Visibility.Visible;
                    cbEmpleado.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
