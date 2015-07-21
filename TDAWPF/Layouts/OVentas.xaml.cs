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
    /// Interaction logic for OVentas.xaml
    /// </summary>
    public partial class OVentas : Page
    {
        private List<Productos> lstProductos;
        public OVentas()
        {
            InitializeComponent();
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Total = 450;
            List<VentaDetalles> venDet= new List<VentaDetalles>();
            Popups.Cobro popup = new Popups.Cobro(venta, venDet);
            popup.Closed += new EventHandler(popupCobro_Closed);
            
            popup.Total = 450;
            popup.ShowDialog();
        }

        private void popupCobro_Closed(object sender, EventArgs e)
        {
            Popups.Cobro popup = sender as Popups.Cobro;
            
            if (popup.Vendido)
            { 
                
            }
        }            
    }
}
