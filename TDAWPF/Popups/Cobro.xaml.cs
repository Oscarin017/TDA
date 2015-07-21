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
        public decimal Total, Efectivo, Cambio;
        public bool Billete = false;

        public Cobro(Ventas ven, List<VentaDetalles> detVen)
        {
            Total = (decimal)ven.Total;
            venta = ven;
            detalleVentas = detVen;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (Billete)
            {
                Efectivo = 0;
                Billete = false;
            }
            Button btn = (Button)sender;
            string num = btn.Content.ToString();
            Efectivo = Convert.ToDecimal(Efectivo.ToString() + num);
            CalcularCambio();
        }

        private void btnImprimirRecibo_Click(object sender, RoutedEventArgs e)
        {
            TDAService.TDAServiceClient client = new TDAService.TDAServiceClient();
            Resultado res = client.InsertVenta(venta, detalleVentas);
            if (res.Realizado)
            {
                Vendido = true;
                this.Close();
            }
        }

        private void InsertVenta()
        {
            
        }

        private void btn1000_Click(object sender, RoutedEventArgs e)
        {
            Billete = true;
            Efectivo = 1000;
            CalcularCambio();
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            Billete = true;
            Efectivo = 20;
            CalcularCambio();
        }

        private void btn50_Click(object sender, RoutedEventArgs e)
        {
            Billete = true;
            Efectivo = 50;
            CalcularCambio();
        }

        private void btn100_Click(object sender, RoutedEventArgs e)
        {
            Billete = true;
            Efectivo = 100;
            CalcularCambio();
        }

        private void btn200_Click(object sender, RoutedEventArgs e)
        {
            Billete = true;
            Efectivo = 200;
            CalcularCambio();
        }

        private void btn500_Click(object sender, RoutedEventArgs e)
        {
            Billete = true;
            Efectivo = 500;
            CalcularCambio();
        }

        private void CalcularCambio()
        {
            txtEfectivo.Text =  Efectivo.ToString("C");
            Cambio = Efectivo - Total;
            txtCambio.Text = Cambio.ToString("C");

            if (Efectivo >= Total)
                btnImprimirRecibo.IsEnabled = true;
            else
                btnImprimirRecibo.IsEnabled = false;
        }

        private void btnExacto_Click(object sender, RoutedEventArgs e)
        {
            Efectivo = Total;
            CalcularCambio();
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            Efectivo = 0;
            CalcularCambio();
        }
    }
}
