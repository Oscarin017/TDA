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
    /// Interaction logic for Paquete.xaml
    /// </summary>
    public partial class Paquete : Page
    {
        List<Paquetes> lstPaquete = new List<Paquetes>();

        public Paquete()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Paquetes p)
        {
            if (!txtNombre.PlaceHolder)
            {
                p.Nombre = txtNombre.Text;
            }
            if (cbActivo.IsChecked == true)
            {
                p.Activo = true;
            }
            if (cbGrupoCliente.IsChecked == true)
            {
                p.ParaGrupoCliente = true;
            }
            cargarGrid(p);
        }

        private void cargarGrid(Paquetes p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectPaquete(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Paquetes => Paquetes.Nombre);
            lstPaquete.Clear();
            foreach (var r in ordenado)
            {
                string sPara = "NO";
                if (r.ParaGrupoCliente == true)
                {
                    sPara = "SI";
                }
                string sActivo = "NO";
                if (r.Activo == true && ((r.FechaInicio <= DateTime.Now && r.FechaFin >= DateTime.Now) || (r.FechaInicio == null && r.FechaFin == null)))
                {
                    sActivo = "SI";                
                }
                lstPaquete.Add(new Paquetes()
                {
                    ID = r.ID,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Precio = r.Precio,
                    ParaGrupoClienteNombre = sPara,
                    ActivoNombre = sActivo
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstPaquete;
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid(new Paquetes());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Paquetes());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Paquete w = new Popups.Paquete();
            w.ShowDialog();
           realizarBusqueda(new Paquetes());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Paquetes r = ((Button)sender).DataContext as Paquetes;
            long lID = r.ID;
            Popups.Paquete w = new Popups.Paquete(lID);
            w.ShowDialog();
            realizarBusqueda(new Paquetes());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Paquetes p = ((Button)sender).DataContext as Paquetes;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar el paquete " + p.Nombre + ".", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                p = tda.BuscarPaqueteID(p.ID).First();
                p.Activo = false;
                Resultado r = tda.UpdatePaquete(p);
                realizarBusqueda(new Paquetes());
            }
        }        
    }
}
