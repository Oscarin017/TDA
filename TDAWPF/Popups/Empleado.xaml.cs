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
                //var resultado = tda.BuscarEmpleado(lID);
                tda.Close();

                //foreach (var r in resultado)
                //{
                //    cbPais.SelectedIndex = Convert.ToInt32(r.Pais);
                //    txtNombre.Text = r.Nombre;
                //    txtAno.Text = r.Ano.ToString();
                //}
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Empleados em = new Empleados();
                em.Nombre = txtNombre.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                em.Pais = Convert.ToInt64(cbi.Uid);
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
            if (!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Empleados em = new Empleados();
                em.ID = lID;
                em.Nombre = txtNombre.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                em.Pais = Convert.ToInt64(cbi.Uid);
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

