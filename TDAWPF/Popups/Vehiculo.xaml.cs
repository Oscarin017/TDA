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
    /// Interaction logic for Vehiculo.xaml
    /// </summary>
    public partial class Vehiculo : Window
    {
        private long lID = 0;
        private long lMarca = 0;
        private long lModelo = 0;

        public Vehiculo()
        {
            InitializeComponent();
        }

        public Vehiculo(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private void cargarCBMarca(Marcas m)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectMarca(m);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbMarca.Items.Add(cbi);
            }
        }

        private void cargarCBModelo(Modelos m)
        {
            cbModelo.Clear();
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectModelo(m);
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbModelo.Items.Add(cbi);
            }
        }

        private void cargarCBTipoIdentificacion()
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectTipoIdentificacion();
            tda.Close();
            foreach (var r in resultado)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Uid = r.ID.ToString();
                cbi.Content = r.Nombre;
                cbTipo.Items.Add(cbi);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarCBMarca(new Marcas());
            cargarCBModelo(new Modelos());
            cargarCBTipoIdentificacion();
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarVehiculoID(lID);
                tda.Close();

                foreach (var r in resultado)
                {
                    cbMarca.SelectedIndex = Convert.ToInt32(r.Marca);
                    cbModelo.SelectedIndex = Convert.ToInt32(r.Modelo);
                    txtAno.Text = r.Ano.ToString();
                    txtColor.Text = r.Color;
                    txtNoSerie.Text = r.NoSerie;
                    txtResponsable.Text = r.Responsable;
                    cbTipo.SelectedIndex = Convert.ToInt32(r.TipoIdentificacion);
                    txtNumeroIdentificacion.Text = r.NumeroIdentificacion;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (cbModelo.SelectedIndex != 0 && !txtAno.PlaceHolder && !txtColor.PlaceHolder && !txtNoSerie.PlaceHolder && !txtResponsable.PlaceHolder && cbTipo.SelectedIndex != 0 && !txtNumeroIdentificacion.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Vehiculos v = new Vehiculos();
                ComboBoxItem cbi = (ComboBoxItem)cbModelo.Items[cbModelo.SelectedIndex];
                v.Modelo = Convert.ToInt64(cbi.Uid);
                v.Ano = Convert.ToInt32(txtAno.Text);
                v.Color = txtColor.Text;
                v.NoSerie = txtNoSerie.Text;
                v.Responsable = txtResponsable.Text;
                ComboBoxItem cbi1 = (ComboBoxItem)cbTipo.Items[cbTipo.SelectedIndex];
                v.TipoIdentificacion = Convert.ToInt64(cbi1.Uid);
                v.NumeroIdentificacion = txtNumeroIdentificacion.Text;
                tda.InsertVehiculo(v);
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
            if (cbModelo.SelectedIndex != 0 && !txtAno.PlaceHolder && !txtColor.PlaceHolder && !txtNoSerie.PlaceHolder && !txtResponsable.PlaceHolder && cbTipo.SelectedIndex != 0 && !txtNumeroIdentificacion.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Vehiculos v = new Vehiculos();
                v.ID = lID;
                ComboBoxItem cbi = (ComboBoxItem)cbModelo.Items[cbModelo.SelectedIndex];
                v.Modelo = Convert.ToInt64(cbi.Uid);
                v.Ano = Convert.ToInt32(txtAno.Text);
                v.Color = txtColor.Text;
                v.NoSerie = txtNoSerie.Text;
                v.Responsable = txtResponsable.Text;
                ComboBoxItem cbi1 = (ComboBoxItem)cbTipo.Items[cbTipo.SelectedIndex];
                v.TipoIdentificacion = Convert.ToInt64(cbi1.Uid);
                v.NumeroIdentificacion = txtNumeroIdentificacion.Text;
                tda.UpdateVehiculo(v);
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void cbMarca_SelectionChanged(object sender, EventArgs e)
        {
            Modelos m = new Modelos();
            ComboBoxItem cbi = (ComboBoxItem)cbMarca.SelectedItem;
            if (this.IsLoaded)
            {
                m.Marca = lMarca = Convert.ToInt64(cbi.Uid);
                Llenado.cargarCBModelo(m, cbModelo);
            }    
        }

        private void cbModelo_SelectionChanged(object sender, EventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            Modelos m = new Modelos();
            ComboBoxItem cbi = (ComboBoxItem)cbModelo.SelectedItem;
            if (this.IsLoaded)
            {
                if (cbModelo.SelectedIndex > 0)
                {
                    m = tda.BuscarModeloID(Convert.ToInt64(cbi.Uid)).First();
                    lModelo = m.ID;
                    if (lMarca == 0)
                    {
                        Llenado.seleccionarComboBoxUid(m.Marca.ToString(), cbMarca);
                        Llenado.seleccionarComboBoxUid(lModelo.ToString(), cbModelo);
                    }
                }
            }
        }
    }
}

