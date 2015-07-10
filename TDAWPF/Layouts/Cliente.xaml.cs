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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDA.Entities;
using TDAWPF.Funcionalidad;

namespace TDAWPF.Layouts
{
    /// <summary>
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Page
    {
        List<Clientes> lstCliente = new List<Clientes>();

        public Cliente()
        {
            InitializeComponent();
        }

        private void cargarGrid(Clientes c)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectCliente(c);
            tda.Close();
            var ordenado = resultado.OrderBy(Clientes => Clientes.RFC);
            lstCliente.Clear();
            foreach (var r in ordenado)
            {
                string sNombre = "";
                if (r.Tipo == true)
                {
                    sNombre = r.Nombre;
                }
                else
                {
                    sNombre = r.Apellido + " " + r.Apellido2 + " " + r.Nombre;
                }
                lstCliente.Add(new Clientes()
                {
                    ID = r.ID,
                    Nombre = sNombre,
                    RFC = r.RFC,
                    GrupoClienteNombre = r.GrupoClienteNombre
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstCliente;
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBPais(new Paises(), cbPais);
            Llenado.cargarCBGrupoCliente(new GrupoClientes(), cbGrupoCliente);
            cargarGrid(new Clientes());
            Llenado.seleccionarDefaultPais(cbPais);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Clientes c = new Clientes();
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                c.Pais = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.SelectedItem;
            if (cbEstado.SelectedIndex != 0)
            {
                c.Estado = Convert.ToInt64(cbi1.Uid);
            }
            ComboBoxItem cbi2 = (ComboBoxItem)cbCiudad.SelectedItem;
            if (cbCiudad.SelectedIndex != 0)
            {
                c.Ciudad = cbi2.Content.ToString();
            }
            if (!txtNombre.PlaceHolder)
            {
                c.Nombre = txtNombre.Text;
            }
            if (!txtRFC.PlaceHolder)
            {
                c.RFC = txtRFC.Text;
            }
            ComboBoxItem cbi3 = (ComboBoxItem)cbGrupoCliente.SelectedItem;
            if (cbGrupoCliente.SelectedIndex != 0)
            {
                c.GrupoCliente = Convert.ToInt64(cbi3.Uid);  
            }
            cargarGrid(c);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Cliente w = new Popups.Cliente();
            w.ShowDialog();
            cargarGrid(new Clientes());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Clientes r = ((Button)sender).DataContext as Clientes;
            long lID = r.ID;
            Popups.Cliente w = new Popups.Cliente(lID);
            w.ShowDialog();
            cargarGrid(new Clientes());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

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
                Llenado.cargarCBCiudadCliente(Convert.ToInt64(es.Pais), 0, cbCiudad);
            }        
        }

        private void cbEstado_SelectionChanged(object sender, EventArgs e)
        {
            Estados es = new Estados();
            ComboBoxItem cbi = (ComboBoxItem)cbEstado.SelectedItem;
            if (cbEstado.SelectedIndex > 0)
            {
                es.ID = Convert.ToInt64(cbi.Uid);
            }
            if (this.IsLoaded)
            {
                Llenado.cargarCBCiudadCliente(Convert.ToInt64(es.Pais), Convert.ToInt64(es.ID), cbCiudad);
            }
        }
    }
}
