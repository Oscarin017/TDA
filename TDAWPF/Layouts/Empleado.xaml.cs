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

namespace TDAWPF.Layouts
{
    /// <summary>
    /// Interaction logic for Empleado.xaml
    /// </summary>
    public partial class Empleado : Page
    {
        List<Empleados> lstEmpleado = new List<Empleados>();

        public Empleado()
        {
            InitializeComponent();
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

        private void cargarGrid(Empleados e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectEmpleado(e);
            tda.Close();
            lstEmpleado.Clear();

            foreach (var r in resultado)
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
            cargarCBPais(new Paises());            
            cargarCBEstado(new Estados());
            cargarGrid(new Empleados());
            ComboBoxItem cbi = new ComboBoxItem();
            //cbPais.SelectedValue = "Mexico";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Empleados em = new Empleados();
            ComboBoxItem cbi = (ComboBoxItem)cbPais.SelectedItem;
            if (cbPais.SelectedIndex != 0)
            {
                em.Pais = Convert.ToInt64(cbi.Uid);
            }
            ComboBoxItem cbi1= (ComboBoxItem)cbEstado.SelectedItem;
            if (cbEstado.SelectedIndex != 0)
            {
                em.Estado = Convert.ToInt64(cbi1.Uid);
            }
            if (!txtNombre.PlaceHolder)
            {                
                em.Nombre = txtNombre.Text;
            }
            if (!txtApellido.PlaceHolder)
            {
                em.Apellido = txtApellido.Text;
                em.Apellido2 = txtApellido.Text;
            }
            if (!txtCurp.PlaceHolder)
            {
                em.CURP = txtCurp.Text;
            }
            cargarGrid(em);
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Empleado w = new Popups.Empleado();
            w.ShowDialog();
            cargarGrid(new Empleados());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Empleados r = ((Button)sender).DataContext as Empleados;
            long lID = r.ID;
            Popups.Empleado w = new Popups.Empleado(lID);
            w.ShowDialog();
            cargarGrid(new Empleados());
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
                cargarCBEstado(es);
            }                                            
        }    
    }
}
