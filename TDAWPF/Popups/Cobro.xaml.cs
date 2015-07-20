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
using TDA.DataLayer;

namespace TDAWPF.Popups
{
    /// <summary>
    /// Interaction logic for Cobro.xaml
    /// </summary>
    public partial class Cobro : Window
    {
        public bool Vendido = false;
        public List<VentaDetalles> detalleVentas;
        public Ventas venta;

        public Cobro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //Button btn = (Button)sender;
            //if(btn.Content.ToString())
            //switch(btn.Content.ToString())
            //{
            //    case "1":
            //        {
            //            txtEfectivo.Text = txtEfectivo + btn.Content.ToString();
            //            break;
            //        }
            //}
        }

        private void btnImprimirRecibo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InsertVenta()
        {
            DateTime fechaventa = DateTime.Now;
            int totalProductos = detalleVentas.Count();
            TDAService.TDAServiceClient client = new TDAService.TDAServiceClient();
            long Cliente = 1;
            TDA.DataLayer.VentaDetalle[] newVentaDet =  new TDA.DataLayer.VentaDetalle[totalProductos];
            
            client.InsertVenta(venta, detalleVentas);
        }
    }
}
