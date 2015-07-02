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
    /// Interaction logic for Estado.xaml
    /// </summary>
    public partial class Estado : Window
    {
        private long lID = 0;

        public Estado()
        {
            InitializeComponent();
        }

        public Estado(long ID)
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarCBPais(new Paises());
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarEstadoID(lID);
                tda.Close();

                foreach (var r in resultado)
                {
                    cbPais.SelectedIndex = Convert.ToInt32(r.Pais);
                    txtNombre.Text = r.Nombre;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNombre.PlaceHolder && cbPais.SelectedIndex != 0)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Estados es = new Estados();
                es.Nombre = txtNombre.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                es.Pais = Convert.ToInt64(cbi.Uid);
                tda.InsertEstado(es);
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
                Estados es = new Estados();
                es.ID = lID;
                es.Nombre = txtNombre.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbPais.Items[cbPais.SelectedIndex];
                es.Pais = Convert.ToInt64(cbi.Uid);
                tda.UpdateEstado(es);
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }
    }
}
