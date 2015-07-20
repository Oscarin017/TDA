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
        public List<Productos> lstProductos;
        private decimal Total;
        private long? cliente;
        private int Cantidad = 0;

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
            int totalProductos = lstProductos.Count();
            TDAService.TDAServiceClient client = new TDAService.TDAServiceClient();
            long Cliente = 1;
            Venta newVenta = new Venta()
            {
                Fecha = fechaventa,
                Total = Total,
                Cliente = Cliente
            };
            VentaDetalle[] newVentaDet =  new VentaDetalle[totalProductos];
            foreach (Productos prod in lstProductos)
            {
                VentaDetalle vd = new VentaDetalle()
                {

                };
            }
        }
    }
}
