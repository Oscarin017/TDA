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

namespace TDAWPF.Popups
{
    /// <summary>
    /// Interaction logic for GrupoCliente.xaml
    /// </summary>
    public partial class GrupoCliente : Window
    {
        private long lID = 0;

        public GrupoCliente()
        {
            InitializeComponent();
        }

        public GrupoCliente(long ID)
        {
            InitializeComponent();
            lID = ID;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (lID == 0)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (lID != 0)
            {
                btnModificar.Visibility = Visibility.Visible;
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                var resultado = tda.BuscarGrupoClienteID(lID);
                tda.Close();

                foreach (var r in resultado)
                {
                    txtNombre.Text = r.Nombre;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            GrupoClientes gc = new GrupoClientes();
            gc.Nombre = txtNombre.Text;
            tda.InsertGrupoCliente(gc);
            tda.Close();
            this.Close();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            GrupoClientes gc = new GrupoClientes();
            gc.ID = lID;
            gc.Nombre = txtNombre.Text;
            tda.UpdateGrupoCliente(gc);
            tda.Close();
            this.Close();
        }
    }
}