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
using TDAWPF.Funcionalidad;

namespace TDAWPF.Popups
{
    /// <summary>
    /// Interaction logic for Paquete.xaml
    /// </summary>
    public partial class Paquete : Window
    {
        private long lID = 0;

        List<Productos> lstProductoT = new List<Productos>();
        List<Productos> lstProductoA = new List<Productos>();
        List<GrupoClientes> lstGCT = new List<GrupoClientes>();
        List<GrupoClientes> lstGCA = new List<GrupoClientes>();

        public Paquete()
        {
            InitializeComponent();
        }

        public Paquete(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private void cargarGridProductos()
        {
            dgPA.ItemsSource = null;
            dgPT.ItemsSource = null;
            dgPA.ItemsSource = lstProductoA;
            dgPT.ItemsSource = lstProductoT;
        }

        private void cargarGridGrupoClientes()
        {
            dgGCA.ItemsSource = null;
            dgGCT.ItemsSource = null;
            dgGCA.ItemsSource = lstGCA;
            dgGCT.ItemsSource = lstGCT;
        }

        private void cargarGridProductosT(Productos p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            List<Productos> lstP = tda.SelectProducto(p).ToList();
            tda.Close();
            lstP = lstP.OrderBy(Productos => Productos.Codigo).ToList();
            lstProductoT.Clear();
            foreach (Productos pa in lstP)
            {
                lstProductoT.Add(pa);
            }
            dgPT.ItemsSource = null;
            dgPT.ItemsSource = lstProductoT;
        }

        private void cargarGridGrupoClientesT(GrupoClientes gc)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            List<GrupoClientes> lstGC = tda.SelectGrupoCliente(gc).ToList();
            tda.Close();
            lstGC = lstGC.OrderBy(GrupoClientes => GrupoClientes.Nombre).ToList();
            lstGCT.Clear();
            foreach (GrupoClientes gca in lstGC)
            {
                lstGCT.Add(gca);
            }
            dgGCT.ItemsSource = null;
            dgGCT.ItemsSource = lstGCT;
        }        

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            cargarGridProductosT(new Productos());
            if (lstProductoT != null )
            {
                btnPAdd.Visibility = Visibility.Visible;
                btnPRemove.Visibility = Visibility.Visible;
            }
            cargarGridGrupoClientesT(new GrupoClientes());
            if (lstGCT != null)
            {
                btnGCAdd.Visibility = Visibility.Visible;
                btnGCRemove.Visibility = Visibility.Visible;
            }
            if (lID == 0)
            {                
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Paquetes p = tda.BuscarPaqueteID(lID).First(); 
                List<PaqueteDias> lstPD = tda.BuscarPaqueteDiaID(lID).ToList();
                Llenado.mostrarDiasSeleccionados(lstPD, cbLunes, cbMartes, cbMiercoles, cbJueves, cbViernes, cbSabado, cbDomingo);
                List<PaqueteProductos> lstPP = tda.BuscarPaqueteProductoID(lID).ToList();
                foreach (PaqueteProductos pp in lstPP)
                {
                    Productos pr = tda.BuscarProductoID(pp.Producto).First();
                    lstProductoA.Add(pr);
                }
                List<PaqueteGrupoClientes> lstPGC = tda.BuscarPaqueteGrupoClienteID(lID).ToList();
                foreach (PaqueteGrupoClientes pgc in lstPGC)
                {
                    GrupoClientes gc = tda.BuscarGrupoClienteID(Convert.ToInt64(pgc.GrupoCliente)).First();
                    lstGCA.Add(gc);
                }
                tda.Close();
                txtNombre.Text = p.Nombre;
                txtPrecio.Text = p.Precio.ToString();
                txtDescripcion.Text = p.Descripcion;
                if (p.Activo == true && p.FechaInicio == null && p.FechaFin == null)
                {
                    rbNo.IsChecked = true;
                }
                else if (p.Activo == true && p.FechaInicio != null && p.FechaFin != null)
                {
                    rbSi.IsChecked = true;
                    dpDe.SelectedDate = p.FechaInicio;
                    dpHasta.SelectedDate = p.FechaFin;
                }
                if (p.ParaGrupoCliente == false)
                {
                    rbPublico.IsChecked = true;
                }
                else if (p.ParaGrupoCliente == true)
                {
                    rbGrupoCliente.IsChecked = true;
                }
                lstProductoT = Llenado.compararTabla(lstProductoT, lstProductoA);
                lstGCT = Llenado.compararTabla(lstGCT, lstGCA);
                cargarGridProductos();
                cargarGridGrupoClientes();
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNombre.PlaceHolder && !txtDescripcion.PlaceHolder && !txtPrecio.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Paquetes p = new Paquetes();
                p.Nombre = txtNombre.Text;
                p.Descripcion = txtDescripcion.Text;
                p.Precio = Convert.ToDecimal(txtPrecio.Text);
                if (rbGrupoCliente.IsChecked == true)
                {
                    p.ParaGrupoCliente = true;
                }
                else if (rbPublico.IsChecked == true)
                {
                    p.ParaGrupoCliente = false;
                }
                if (rbNo.IsChecked == true)
                { 
                    p.Activo = true;
                }
                else if(rbSi.IsChecked == true)
                {
                    p.Activo = true;
                    p.FechaInicio = Convert.ToDateTime(dpDe.Text);
                    p.FechaFin = Convert.ToDateTime(dpHasta.Text);
                }                
                Resultado r = tda.InsertPaquete(p);
                if (r.IdGuardado == 1)
                {
                    Paquetes pg = tda.SelectPaquete(p).First();
                    foreach (PaqueteDias pd in Llenado.guardarDiasSeleccionadosPaquete(pg.ID, cbLunes, cbMartes, cbMiercoles, cbJueves, cbViernes, cbSabado, cbDomingo))
                    {
                        tda.InsertPaqueteDia(pd);
                    }       
                    foreach (Productos pa in lstProductoA)
                    {
                        PaqueteProductos pp = new PaqueteProductos();
                        pp.Paquete = pg.ID;
                        pp.Producto = pa.ID;
                        tda.InsertPaqueteProducto(pp);
                    }
                    foreach (GrupoClientes pa in lstGCA)
                    {
                        PaqueteGrupoClientes pgc = new PaqueteGrupoClientes();
                        pgc.Paquete = pg.ID;
                        pgc.GrupoCliente = pa.ID;
                        tda.InsertPaqueteGrupoCliente(pgc);
                    }
                }
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNombre.PlaceHolder && !txtDescripcion.PlaceHolder && !txtPrecio.PlaceHolder)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Paquetes p = new Paquetes();
                p.ID = lID;
                p.Nombre = txtNombre.Text;
                p.Descripcion = txtDescripcion.Text;
                p.Precio = Convert.ToDecimal(txtPrecio.Text);
                if (rbGrupoCliente.IsChecked == true)
                {
                    p.ParaGrupoCliente = true;
                }
                else if (rbPublico.IsChecked == true)
                {
                    p.ParaGrupoCliente = false;
                }
                if (rbNo.IsChecked == true)
                {
                    p.Activo = true;
                }
                else if (rbSi.IsChecked == true)
                {
                    p.Activo = true;
                    p.FechaInicio = Convert.ToDateTime(dpDe.Text);
                    p.FechaFin = Convert.ToDateTime(dpHasta.Text);
                }                  
                tda.UpdatePaquete(p);
                foreach (PaqueteDias pd in tda.BuscarPaqueteDiaID(p.ID))
                {
                    tda.DeletePaqueteDia(pd);
                }
                foreach (PaqueteDias pd in Llenado.guardarDiasSeleccionadosPaquete(p.ID, cbLunes, cbMartes, cbMiercoles, cbJueves, cbViernes, cbSabado, cbDomingo))
                {
                    tda.InsertPaqueteDia(pd);
                }
                foreach (PaqueteProductos pp in tda.BuscarPaqueteProductoID(p.ID))
                {
                    tda.DeletePaqueteProducto(pp);
                }
                foreach (Productos pa in lstProductoA)
                {
                    PaqueteProductos pp = new PaqueteProductos();
                    pp.Paquete = p.ID;
                    pp.Producto = pa.ID;
                    tda.InsertPaqueteProducto(pp);
                }
                foreach (PaqueteGrupoClientes pgc in tda.BuscarPaqueteGrupoClienteID(p.ID))
                {
                    tda.DeletePaqueteGrupoCliente(pgc);
                }
                if (rbGrupoCliente.IsChecked == true)
                {
                    foreach (GrupoClientes pa in lstGCA)
                    {
                        PaqueteGrupoClientes pgc = new PaqueteGrupoClientes();
                        pgc.Paquete = p.ID;
                        pgc.GrupoCliente = pa.ID;
                        tda.InsertPaqueteGrupoCliente(pgc);
                    }
                }
                tda.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void rDuracion_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Content.ToString() == "SI")
            {
                gDuracion.Visibility = Visibility.Visible;
            }
            else if (rb.Content.ToString() == "NO" && rb.IsLoaded)
            {
                gDuracion.Visibility = Visibility.Collapsed;
            }
        }

        private void rDirigido_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Content.ToString() == "Publico General" && rb.IsLoaded)
            {
                tiGrupos.Visibility = Visibility.Collapsed;
                tcMain.SelectedIndex = 0;
            }
            else if (rb.Content.ToString() == "Grupo Cliente")
            {
                tiGrupos.Visibility = Visibility.Visible;
            }
        }

        private void btnPAdd_Click(object sender, RoutedEventArgs e)
        {
            var sp = dgPT.SelectedItems;
            foreach (Productos p in sp)
            {
                lstProductoT.Remove(p);
                lstProductoA.Add(p);                
            }
            lstProductoA = Llenado.ordenarTabla(lstProductoA);
            cargarGridProductos();
        }

        private void btnPRemove_Click(object sender, RoutedEventArgs e)
        {
            var sp = dgPA.SelectedItems;
            foreach (Productos p in sp)
            {
                lstProductoA.Remove(p);
                lstProductoT.Add(p);
            }
            lstProductoT = Llenado.ordenarTabla(lstProductoT);
            cargarGridProductos();
        }

        private void btnGCAdd_Click(object sender, RoutedEventArgs e)
        {
            var sgc = dgGCT.SelectedItems;
            foreach (GrupoClientes gc in sgc)
            {
                lstGCT.Remove(gc);
                lstGCA.Add(gc);
            }
            lstGCA = Llenado.ordenarTabla(lstGCA);
            cargarGridGrupoClientes();
        }

        private void btnGCRemove_Click(object sender, RoutedEventArgs e)
        {
            var sgc = dgGCA.SelectedItems;
            foreach (GrupoClientes gc in sgc)
            {
                lstGCA.Remove(gc);
                lstGCT.Add(gc);
            }
            lstGCT = Llenado.ordenarTabla(lstGCT);
            cargarGridGrupoClientes();
        }
    }
}
