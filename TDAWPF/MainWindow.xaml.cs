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

namespace TDAWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal long iID = 0;

        public MainWindow(long ID)
        {
            InitializeComponent();
            iID = ID;
        }

        private void menuClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            MenuItem mi = (MenuItem) sender;
            switch (mi.Header.ToString())
            {
                case "Cliente":
                    {
                        fMain.Source = new Uri("/Layouts/Cliente.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Cliente";
                        break;
                    }
                case "Color":
                    {
                        fMain.Source = new Uri("/Layouts/Color.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Color";
                        break;
                    }
                case "Empleado":
                    {
                        fMain.Source = new Uri("/Layouts/Empleado.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Empleado";
                        break;
                    }
                case "Estado":
                    {
                        fMain.Source = new Uri("/Layouts/Estado.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Estado";
                        break;
                    }
                case "Grupo de Cliente":
                    {
                        fMain.Source = new Uri("/Layouts/GrupoCliente.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Grupo Cliente";
                        break;
                    }
                case "Marca":
                    {
                        fMain.Source = new Uri("/Layouts/Marca.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Marca";
                        break;
                    }
                case "Modelo":
                    {
                        fMain.Source = new Uri("/Layouts/Modelo.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Modelo";
                        break;
                    }
                case "Pais":
                    {
                        fMain.Source = new Uri("/Layouts/Pais.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Pais";
                        break;
                    }
                case "Paquete":
                    {
                        fMain.Source = new Uri("/Layouts/Paquete.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Paquete";
                        break;
                    }
                case "Producto":
                    {
                        fMain.Source = new Uri("/Layouts/Producto.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Producto";
                        break;
                    }
                case "Promocion":
                    {
                        fMain.Source = new Uri("/Layouts/Promocion.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Promocion";
                        break;
                    }
                case "Proveedor":
                    {
                        fMain.Source = new Uri("/Layouts/Proveedor.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Proveedor";
                        break;
                    }
                case "Usuario":
                    {
                        fMain.Source = new Uri("/Layouts/Usuario.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Usuario";
                        break;
                    }
                case "Vehiculo":
                    {
                        fMain.Source = new Uri("/Layouts/Vehiculo.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Vehiculo";
                        break;
                    }
                case "Venta":
                    {
                        fMain.Source = new Uri("/Layouts/Venta.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Venta";
                        break;
                    }
                case "Ventas":
                    {
                        fMain.Source = new Uri("/Layouts/OVentas.xaml", UriKind.Relative);
                        wMain.Title = "Tianguis del Auto - Ventas";
                        break;
                    }
                case "Salir":
                    {
                        this.Close();
                        break;
                    }
            }
        }
    }
}
