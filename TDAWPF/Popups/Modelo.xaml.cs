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
    /// Interaction logic for Modelo.xaml
    /// </summary>
    public partial class Modelo : Window
    {
        private long lID = 0;

        public Modelo()
        {
            InitializeComponent();
        }

        public Modelo(long ID)
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
            Llenado.cargarCBMarca(new Marcas(), cbMarca);
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarModeloID(lID);
                tda.Close();
                foreach (var r in resultado)
                {
                    cbMarca.SelectedIndex = Convert.ToInt32(r.Marca);
                    txtNombre.Text = r.Nombre;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNombre.PlaceHolder && cbMarca.SelectedIndex != 0)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Modelos es = new Modelos();
                es.Nombre = txtNombre.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbMarca.Items[cbMarca.SelectedIndex];
                es.Marca = Convert.ToInt64(cbi.Uid);
                tda.InsertModelo(es);
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
            if (!txtNombre.PlaceHolder && cbMarca.SelectedIndex != 0)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Modelos es = new Modelos();
                es.ID = lID;
                es.Nombre = txtNombre.Text;
                ComboBoxItem cbi = (ComboBoxItem)cbMarca.Items[cbMarca.SelectedIndex];
                es.Marca = Convert.ToInt64(cbi.Uid);
                tda.UpdateModelo(es);
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

