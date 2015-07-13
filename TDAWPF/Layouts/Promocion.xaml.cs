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
    /// Interaction logic for Promocion.xaml
    /// </summary>
    public partial class Promocion : Page
    {
        List<Promociones> lstPromocion = new List<Promociones>();

        public Promocion()
        {
            InitializeComponent();
        }

        private void cargarGrid(Promociones p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectPromocion(p);
            tda.Close();
            var ordenado = resultado.OrderBy(Promociones => Promociones.Nombre);
            lstPromocion.Clear();
            foreach (var r in ordenado)
            {
                string sTipo = Llenado.tipoPromocion(Convert.ToInt32(r.Tipo));
                string sValor = "";
                if (r.Tipo == 4)
                {
                    sValor = r.Comprar + " X " + r.Pagar;
                }
                else
                {
                    sValor = r.Valor.ToString();
                }
                string sParaPaq = "NO";
                if (r.ParaPaquete == true)
                {
                    sParaPaq = "SI";
                }
                string sParaTP = "NO";
                if (r.ParaTipoProducto == true)
                {
                    sParaTP = "SI";
                }
                string sParaPro = "NO";
                if (r.ParaProducto == true)
                {
                    sParaPro = "SI";
                }
                string sParaGC = "NO";
                if (r.ParaGrupoCliente == true)
                {
                    sParaGC = "SI";
                }
                string sActivo = "NO";
                if(r.Activo == true && ((r.FechaInicio <= DateTime.Now && r.FechaFin >= DateTime.Now) || (r.FechaInicio == null && r.FechaFin == null)))
                {
                    sActivo = "SI";                
                }
                lstPromocion.Add(new Promociones()
                {
                    ID = r.ID,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    TipoNombre = sTipo,
                    ValorNombre = sValor,
                    ParaPaqueteNombre = sParaPaq,
                    ParaTipoProductoNombre = sParaTP,
                    ParaProductoNombre = sParaPro,
                    ParaGrupoClienteNombre = sParaGC,
                    ActivoNombre = sActivo
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstPromocion;
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBTipoPromocion(cbTipo);
            cargarGrid(new Promociones());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Promociones p = new Promociones();
            ComboBoxItem cbi = (ComboBoxItem)cbTipo.SelectedItem;
            if(cbTipo.SelectedIndex != 0)
            {
                p.Tipo = Convert.ToInt32(cbi.Uid);
            }
            if (!txtNombre.PlaceHolder)
            {
                p.Nombre = txtNombre.Text;
            }
            if (cbActivo.IsChecked == true)
            {
                p.Activo = true;
            }
            if (cbPaquete.IsChecked == true)
            {
                p.ParaPaquete = true;
            }
            if (cbTipoProducto.IsChecked == true)
            {
                p.ParaTipoProducto = true;
            }
            if (cbProducto.IsChecked == true)
            {
                p.ParaProducto = true;
            }
            if (cbGrupoCliente.IsChecked == true)
            {
                p.ParaGrupoCliente = true;
            }
            cargarGrid(p);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Promocion w = new Popups.Promocion();
            w.ShowDialog();
            cargarGrid(new Promociones());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Promociones r = ((Button)sender).DataContext as Promociones;
            long lID = r.ID;
            Popups.Promocion w = new Popups.Promocion(lID);
            w.ShowDialog();
            cargarGrid(new Promociones());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }      
    }
}

