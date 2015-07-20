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
    /// Interaction logic for Empleado.xaml
    /// </summary>
    public partial class Empleado : Page
    {
        List<Empleados> lstEmpleado = new List<Empleados>();
        private long lPais = 0;
        private long lEstado = 0;

        public Empleado()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Empleados e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                e.Pais = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1 = (ComboBoxItem)cbEstado.SelectedItem;
            if (cbEstado.SelectedIndex != 0)
            {
                e.Estado = Convert.ToInt64(cbi1.Uid);
            }
            ComboBoxItem cbi2 = (ComboBoxItem)cbCiudad.SelectedItem;
            if (cbCiudad.SelectedIndex != 0)
            {
                e.Ciudad = cbi2.Content.ToString();
            }
            if (!txtNombre.PlaceHolder)
            {
                e.Nombre = txtNombre.Text;
            }
            if (!txtApellido.PlaceHolder)
            {
                e.Apellido = txtApellido.Text;
                e.Apellido2 = txtApellido.Text;
            }
            if (!txtCurp.PlaceHolder)
            {
                e.CURP = txtCurp.Text;
            }
            cargarGrid(e);
        }

        private void cargarGrid(Empleados e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEmpleado(e);
            tda.Close();
            var ordenado = resultado.OrderBy(Empleados => Empleados.CURP).ToList();
            lstEmpleado.Clear();
            foreach (var r in ordenado)
            {
                lstEmpleado.Add(new Empleados()
                {
                    ID = r.ID,
                    Nombre = r.Nombre,
                    Apellido = r.Apellido,
                    Apellido2 = r.Apellido2,
                    CURP = r.CURP
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstEmpleado;   
        }        

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBPais(new Paises(), cbPais);
            cargarGrid(new Empleados());
            Llenado.seleccionarDefaultPais(cbPais);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Empleados());
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Empleado w = new Popups.Empleado();
            w.ShowDialog();
            realizarBusqueda(new Empleados());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Empleados r = ((Button)sender).DataContext as Empleados;
            long lID = r.ID;
            Popups.Empleado w = new Popups.Empleado(lID);
            w.ShowDialog();
            realizarBusqueda(new Empleados());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleados em = ((Button)sender).DataContext as Empleados;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar al empleado " + em.Nombre + " "+ em.Apellido + " " + em.Apellido2 + ".", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                em = tda.BuscarEmpleadoID(em.ID).First();
                Resultado r = tda.DeleteEmpleado(em);
                if (r.ErrorDB)
                {
                    MessageBox.Show("No se pudo eliminar el estado " + em.Nombre + ".");
                }
                realizarBusqueda(new Empleados());
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
                Llenado.cargarCBCiudadEmpleado(Convert.ToInt64(es.ID), cbCiudad);                
            }
        }
    }
}
