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
        private long lPais = 0;
        private long lEstado = 0;

        public Cliente()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Clientes c)
        {
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

        private void cargarGrid(Clientes c)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            List<Clientes> lstC = tda.SelectCliente(c).ToList();
            tda.Close();
            lstC = lstC.OrderBy(Clientes => Clientes.RFC).ToList();
            lstCliente.Clear();
            foreach (Clientes ca in lstC)
            {
                string sNombre = "";
                if (ca.Tipo == true)
                {
                    sNombre = ca.Nombre;
                }
                else
                {
                    sNombre = ca.Nombre + " " + ca.Apellido + " " + ca.Apellido2;
                }
                lstCliente.Add(new Clientes()
                {
                    ID = ca.ID,
                    Nombre = sNombre,
                    RFC = ca.RFC,
                    GrupoClienteNombre = ca.GrupoClienteNombre
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
            realizarBusqueda(new Clientes());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Cliente w = new Popups.Cliente();
            w.ShowDialog();
            realizarBusqueda(new Clientes());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Clientes r = ((Button)sender).DataContext as Clientes;
            long lID = r.ID;
            Popups.Cliente w = new Popups.Cliente(lID);
            w.ShowDialog();
            realizarBusqueda(new Clientes());
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
                Llenado.cargarCBCiudadCliente(Convert.ToInt64(es.ID), cbCiudad);
            }
        }
    }
}
