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
    /// Interaction logic for Promocion.xaml
    /// </summary>
    public partial class Promocion : Window
    {
       private long lID = 0;

        List<Productos> lstProductoT = new List<Productos>();
        List<Productos> lstProductoA = new List<Productos>();
        List<Paquetes> lstPaqueteT = new List<Paquetes>();
        List<Paquetes> lstPaqueteA = new List<Paquetes>();
        List<TipoProductos> lstTPT = new List<TipoProductos>();
        List<TipoProductos> lstTPA = new List<TipoProductos>();
        List<GrupoClientes> lstGCT = new List<GrupoClientes>();
        List<GrupoClientes> lstGCA = new List<GrupoClientes>();

        public Promocion()
        {
            InitializeComponent();
        }

        public Promocion(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private bool validacionCampos()
        {
            bool bValidacion = true;
            if (!txtPorcentaje.PlaceHolder)
            {
                if (!Llenado.validacionPorcentaje(txtPorcentaje.Text))
                {
                    bValidacion = false;
                }
            }
            if (!txtCantidad.PlaceHolder)
            {
                if (!Llenado.validacionCantidad(txtCantidad.Text))
                {
                    bValidacion = false;
                }
            }
            if (!txtPrecioFijo.PlaceHolder)
            {
                if (!Llenado.validacionFijo(txtPrecioFijo.Text))
                {
                    bValidacion = false;
                }
            }
            if (!txtCompra.PlaceHolder)
            {
                if (!Llenado.validacionCompra(txtCompra.Text))
                {
                    bValidacion = false;
                }
            }
            if (!txtPaga.PlaceHolder)
            {
                if (!Llenado.validacionPaga(txtPaga.Text))
                {
                    bValidacion = false;
                }
            }
            return bValidacion;
        }

        private void cargarGridProductos()
        {
            dgPA.ItemsSource = null;
            dgPT.ItemsSource = null;
            dgPA.ItemsSource = lstProductoA;
            dgPT.ItemsSource = lstProductoT;
        }

        private void cargarGridPaquetes()
        {
            dgPaqA.ItemsSource = null;
            dgPaqT.ItemsSource = null;
            dgPaqA.ItemsSource = lstPaqueteA;
            dgPaqT.ItemsSource = lstPaqueteT;
        }

        private void cargarGridTipoProductos()
        {
            dgTPA.ItemsSource = null;
            dgTPT.ItemsSource = null;
            dgTPA.ItemsSource = lstTPA;
            dgTPT.ItemsSource = lstTPT;
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

        private void cargarGridPaquetesT(Paquetes p)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            List<Paquetes> lstP = tda.SelectPaquete(p).ToList();
            tda.Close();
            lstP = lstP.OrderBy(Paquetes => Paquetes.Nombre).ToList();
            lstPaqueteT.Clear();
            foreach (Paquetes pa in lstP)
            {
                lstPaqueteT.Add(pa);
            }
            dgPaqT.ItemsSource = null;
            dgPaqT.ItemsSource = lstPaqueteT;
        }

        private void cargarGridTipoProductosT(TipoProductos tp)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            List<TipoProductos> lstTP = tda.SelectTipoProducto(tp).ToList();
            tda.Close();
            lstTP = lstTP.OrderBy(TipoProductos => TipoProductos.Nombre).ToList();
            lstTPT.Clear();
            foreach (TipoProductos tpa in lstTP)
            {
                lstTPT.Add(tpa);
            }
            dgTPT.ItemsSource = null;
            dgTPT.ItemsSource = lstTPT;
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
            Llenado.cargarCBTipoPromocion(cbTipo);
            cargarGridProductosT(new Productos());
            if (lstProductoT != null )
            {
                btnPAdd.Visibility = Visibility.Visible;
                btnPRemove.Visibility = Visibility.Visible;
            }
            cargarGridPaquetesT(new Paquetes());
            if (lstPaqueteT != null)
            {
                btnPaqAdd.Visibility = Visibility.Visible;
                btnPaqRemove.Visibility = Visibility.Visible;
            }
            cargarGridTipoProductosT(new TipoProductos());
            if (lstTPT != null)
            {
                btnTPAdd.Visibility = Visibility.Visible;
                btnTPRemove.Visibility = Visibility.Visible;
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
                Promociones p = tda.BuscarPromocionID(lID).First(); 
                List<PromocionDias> lstPD = tda.BuscarPromocionDiaID(lID).ToList();
                Llenado.mostrarDiasSeleccionados(lstPD, cbLunes, cbMartes, cbMiercoles, cbJueves, cbViernes, cbSabado, cbDomingo);
                List<PromocionProductos> lstPP = tda.BuscarPromocionProductoID(lID).ToList();
                foreach (PromocionProductos pp in lstPP)
                {
                    Productos pr = tda.BuscarProductoID(pp.Producto).First();
                    lstProductoA.Add(pr);
                }
                List<PromocionPaquetes> lstPPaq = tda.BuscarPromocionPaqueteID(lID).ToList();
                foreach (PromocionPaquetes ppaq in lstPPaq)
                {
                    Paquetes paq = tda.BuscarPaqueteID(ppaq.Paquete).First();
                    lstPaqueteA.Add(paq);
                }
                List<PromocionTipoProductos> lstTP = tda.BuscarPromocionTipoProductoID(lID).ToList();
                foreach (PromocionTipoProductos ptp in lstTP)
                {
                    TipoProductos tp = tda.BuscarTipoProductoID(Convert.ToInt64(ptp.TipoProducto)).First();
                    lstTPA.Add(tp);
                }
                List<PromocionGrupoClientes> lstPGC = tda.BuscarPromocionGrupoClienteID(lID).ToList();
                foreach (PromocionGrupoClientes pgc in lstPGC)
                {
                    GrupoClientes gc = tda.BuscarGrupoClienteID(Convert.ToInt64(pgc.GrupoCliente)).First();
                    lstGCA.Add(gc);
                }
                tda.Close();
                txtNombre.Text = p.Nombre;
                txtDescripcion.Text = p.Descripcion;
                Llenado.seleccionarComboBoxUid(p.Tipo.ToString(), cbTipo);
                switch (p.Tipo)
                {
                    case 1: 
                        {
                            txtPorcentaje.Text = p.Valor.ToString();
                            break;                
                        }
                    case 2:
                        {
                            txtCantidad.Text = p.Valor.ToString();
                            break;
                        }
                    case 3:
                        {
                            txtPrecioFijo.Text = p.Valor.ToString();
                            break;
                        }
                    case 4:
                        {
                            txtCompra.Text = p.Comprar.ToString();
                            txtPaga.Text = p.Pagar.ToString();
                            break;
                        }
                }
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
                lstProductoT = Llenado.compararTabla(lstProductoT, lstProductoA);
                lstPaqueteT = Llenado.compararTabla(lstPaqueteT, lstPaqueteA);
                lstTPT = Llenado.compararTabla(lstTPT, lstTPA);
                lstGCT = Llenado.compararTabla(lstGCT, lstGCA);
                cargarGridProductos();
                cargarGridPaquetes();
                cargarGridTipoProductos();
                cargarGridGrupoClientes();
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNombre.PlaceHolder && !txtDescripcion.PlaceHolder && cbTipo.SelectedIndex != 0 && (!txtPorcentaje.PlaceHolder || !txtCantidad.PlaceHolder || !txtPrecioFijo.PlaceHolder || (!txtPaga.PlaceHolder && !txtCompra.PlaceHolder)))
            {
                if (validacionCampos())
                {
                    TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                    Promociones p = new Promociones();
                    p.Nombre = txtNombre.Text;
                    p.Descripcion = txtDescripcion.Text;
                    ComboBoxItem cbi = (ComboBoxItem)cbTipo.Items[cbTipo.SelectedIndex];
                    p.Tipo = Convert.ToInt32(cbi.Uid);
                    switch (p.Tipo)
                    {
                        case 1:
                            {
                                p.Valor = Convert.ToDecimal(txtPorcentaje.Text);
                                break;
                            }
                        case 2:
                            {
                                p.Valor = Convert.ToDecimal(txtCantidad.Text);
                                break;
                            }
                        case 3:
                            {
                                p.Valor = Convert.ToDecimal(txtPrecioFijo.Text);
                                break;
                            }
                        case 4:
                            {
                                p.Comprar = Convert.ToInt32(txtCompra.Text);
                                p.Pagar = Convert.ToInt32(txtPaga.Text);
                                break;
                            }
                    }
                    if (rbNo.IsChecked == true)
                    {
                        p.Activo = true;
                        p.FechaInicio = null;
                        p.FechaFin = null;
                    }
                    else if (rbSi.IsChecked == true)
                    {
                        p.Activo = true;
                        p.FechaInicio = Convert.ToDateTime(dpDe.Text);
                        p.FechaFin = Convert.ToDateTime(dpHasta.Text);
                    }
                    if (lstProductoA.Count > 0)
                    {
                        p.ParaProducto = true;
                    }
                    else
                    {
                        p.ParaProducto = false;
                    }
                    if (lstPaqueteA.Count > 0)
                    {
                        p.ParaPaquete = true;
                    }
                    else
                    {
                        p.ParaPaquete = false;
                    }
                    if (lstTPA.Count > 0)
                    {
                        p.ParaTipoProducto = true;
                    }
                    else
                    {
                        p.ParaTipoProducto = false;
                    }
                    if (lstGCA.Count > 0)
                    {
                        p.ParaGrupoCliente = true;
                    }
                    else
                    {
                        p.ParaGrupoCliente = false;
                    }
                    Resultado r = tda.InsertPromocion(p);
                    if (r.IdGuardado > 0)
                    {
                        foreach (PromocionDias pd in Llenado.guardarDiasSeleccionadosPromocion(r.IdGuardado, cbLunes, cbMartes, cbMiercoles, cbJueves, cbViernes, cbSabado, cbDomingo))
                        {
                            tda.InsertPromocionDia(pd);
                        }
                        foreach (Productos pa in lstProductoA)
                        {
                            PromocionProductos pp = new PromocionProductos();
                            pp.Promocion = r.IdGuardado;
                            pp.Producto = pa.ID;
                            tda.InsertPromocionProducto(pp);
                        }
                        foreach (Paquetes pa in lstPaqueteA)
                        {
                            PromocionPaquetes pp = new PromocionPaquetes();
                            pp.Promocion = r.IdGuardado;
                            pp.Paquete = pa.ID;
                            tda.InsertPromocionPaquete(pp);
                        }
                        foreach (TipoProductos tp in lstTPA)
                        {
                            PromocionTipoProductos ptp = new PromocionTipoProductos();
                            ptp.Promocion = r.IdGuardado;
                            ptp.TipoProducto = tp.ID;
                            tda.InsertPromocionTipoProducto(ptp);
                        }
                        foreach (GrupoClientes gc in lstGCA)
                        {
                            PromocionGrupoClientes pgc = new PromocionGrupoClientes();
                            pgc.Promocion = r.IdGuardado;
                            pgc.GrupoCliente = gc.ID;
                            tda.InsertPromocionGrupoCliente(pgc);
                        }
                    }
                    tda.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos.");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e) 
        {
            if (!txtNombre.PlaceHolder && !txtDescripcion.PlaceHolder && cbTipo.SelectedIndex != 0 && (!txtPorcentaje.PlaceHolder || !txtCantidad.PlaceHolder || !txtPrecioFijo.PlaceHolder || (!txtPaga.PlaceHolder && !txtCompra.PlaceHolder)))
            {
                if (validacionCampos())
                {
                    TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                    Promociones p = new Promociones();
                    p.ID = lID;
                    p.Nombre = txtNombre.Text;
                    p.Descripcion = txtDescripcion.Text;
                    ComboBoxItem cbi = (ComboBoxItem)cbTipo.Items[cbTipo.SelectedIndex];
                    p.Tipo = Convert.ToInt32(cbi.Uid);
                    switch (p.Tipo)
                    {
                        case 1:
                            {
                                p.Valor = Convert.ToDecimal(txtPorcentaje.Text);
                                break;
                            }
                        case 2:
                            {
                                p.Valor = Convert.ToDecimal(txtCantidad.Text);
                                break;
                            }
                        case 3:
                            {
                                p.Valor = Convert.ToDecimal(txtPrecioFijo.Text);
                                break;
                            }
                        case 4:
                            {
                                p.Comprar = Convert.ToInt32(txtCompra.Text);
                                p.Pagar = Convert.ToInt32(txtPaga.Text);
                                break;
                            }
                    }
                    if (rbNo.IsChecked == true)
                    {
                        p.Activo = true;
                        p.FechaInicio = null;
                        p.FechaFin = null;
                    }
                    else if (rbSi.IsChecked == true)
                    {
                        p.Activo = true;
                        p.FechaInicio = Convert.ToDateTime(dpDe.Text);
                        p.FechaFin = Convert.ToDateTime(dpHasta.Text);
                    }
                    if (lstProductoA.Count > 0)
                    {
                        p.ParaProducto = true;
                    }
                    else
                    {
                        p.ParaProducto = false;
                    }
                    if (lstPaqueteA.Count > 0)
                    {
                        p.ParaPaquete = true;
                    }
                    else
                    {
                        p.ParaPaquete = false;
                    }
                    if (lstTPA.Count > 0)
                    {
                        p.ParaTipoProducto = true;
                    }
                    else
                    {
                        p.ParaTipoProducto = false;
                    }
                    if (lstGCA.Count > 0)
                    {
                        p.ParaGrupoCliente = true;
                    }
                    else
                    {
                        p.ParaGrupoCliente = false;
                    }
                    tda.UpdatePromocion(p);
                    foreach (PromocionDias pd in tda.BuscarPromocionDiaID(p.ID))
                    {
                        tda.DeletePromocionDia(pd);
                    }
                    foreach (PromocionDias pd in Llenado.guardarDiasSeleccionadosPromocion(p.ID, cbLunes, cbMartes, cbMiercoles, cbJueves, cbViernes, cbSabado, cbDomingo))
                    {
                        tda.InsertPromocionDia(pd);
                    }
                    foreach (PromocionProductos pp in tda.BuscarPromocionProductoID(p.ID))
                    {
                        tda.DeletePromocionProducto(pp);
                    }
                    foreach (Productos pa in lstProductoA)
                    {
                        PromocionProductos pp = new PromocionProductos();
                        pp.Promocion = p.ID;
                        pp.Producto = pa.ID;
                        tda.InsertPromocionProducto(pp);
                    }
                    foreach (PromocionPaquetes pp in tda.BuscarPromocionPaqueteID(p.ID))
                    {
                        tda.DeletePromocionPaquete(pp);
                    }
                    foreach (Paquetes pa in lstPaqueteA)
                    {
                        PromocionPaquetes pp = new PromocionPaquetes();
                        pp.Promocion = p.ID;
                        pp.Paquete = pa.ID;
                        tda.InsertPromocionPaquete(pp);
                    }
                    foreach (PromocionTipoProductos tp in tda.BuscarPromocionTipoProductoID(p.ID))
                    {
                        tda.DeletePromocionTipoProducto(tp);
                    }
                    foreach (TipoProductos tp in lstTPA)
                    {
                        PromocionTipoProductos ptp = new PromocionTipoProductos();
                        ptp.Promocion = p.ID;
                        ptp.TipoProducto = tp.ID;
                        tda.InsertPromocionTipoProducto(ptp);
                    }
                    foreach (PromocionGrupoClientes pgc in tda.BuscarPromocionGrupoClienteID(p.ID))
                    {
                        tda.DeletePromocionGrupoCliente(pgc);
                    }
                    foreach (GrupoClientes pa in lstGCA)
                    {
                        PromocionGrupoClientes pgc = new PromocionGrupoClientes();
                        pgc.Promocion = p.ID;
                        pgc.GrupoCliente = pa.ID;
                        tda.InsertPromocionGrupoCliente(pgc);
                    }
                    tda.Close();
                    this.Close();
                }
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
        
        private void esconderTipo()
        {
            txtPorcentaje.Visibility = Visibility.Collapsed;
            txtCantidad.Visibility = Visibility.Collapsed;
            txtPrecioFijo.Visibility = Visibility.Collapsed;
            txtCompra.Visibility = Visibility.Collapsed;
            txtPaga.Visibility = Visibility.Collapsed;
        }

        private void cbTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (cbTipo.IsLoaded)
            {
                Controles.ComboBoxI cb = (Controles.ComboBoxI)sender;

                switch (cb.SelectedIndex)
                {
                    case 0:
                        {
                            esconderTipo();
                            break;
                        }
                    case 1:
                        {
                            esconderTipo();
                            txtPorcentaje.Visibility = Visibility.Visible;
                            break;
                        }
                    case 2:
                        {
                            esconderTipo();
                            txtCantidad.Visibility = Visibility.Visible;
                            break;
                        }
                    case 3:
                        {
                            esconderTipo();
                            txtPrecioFijo.Visibility = Visibility.Visible;
                            break;
                        }
                    case 4:
                        {
                            esconderTipo();                            
                            txtCompra.Visibility = Visibility.Visible;
                            txtPaga.Visibility = Visibility.Visible;
                            break;
                        }
                }
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

        private void btnPaqAdd_Click(object sender, RoutedEventArgs e)
        {
            var sp = dgPaqT.SelectedItems;
            foreach (Paquetes p in sp)
            {
                lstPaqueteT.Remove(p);
                lstPaqueteA.Add(p);
            }
            lstPaqueteA = Llenado.ordenarTabla(lstPaqueteA);
            cargarGridPaquetes();
        }

        private void btnPaqRemove_Click(object sender, RoutedEventArgs e)
        {
            var sp = dgPaqA.SelectedItems;
            foreach (Paquetes p in sp)
            {
                lstPaqueteA.Remove(p);
                lstPaqueteT.Add(p);
            }
            lstPaqueteT = Llenado.ordenarTabla(lstPaqueteT);
            cargarGridPaquetes();
        }

        private void btnTPAdd_Click(object sender, RoutedEventArgs e)
        {
            var stp = dgTPT.SelectedItems;
            foreach (TipoProductos tp in stp)
            {
                lstTPT.Remove(tp);
                lstTPA.Add(tp);
            }
            lstTPA = Llenado.ordenarTabla(lstTPA);
            cargarGridTipoProductos();
        }

        private void btnTPRemove_Click(object sender, RoutedEventArgs e)
        {
            var stp = dgTPA.SelectedItems;
            foreach (TipoProductos tp in stp)
            {
                lstTPA.Remove(tp);
                lstTPT.Add(tp);
            }
            lstTPT = Llenado.ordenarTabla(lstTPT);
            cargarGridTipoProductos();
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
