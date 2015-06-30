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
    /// Interaction logic for Color.xaml
    /// </summary>
    public partial class Color : Window
    {
        private long lID = 0;
        List<Colores> lstColor = new List<Colores>();

        public Color()
        {
            InitializeComponent();
        }

        public Color(long ID)
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
                TDAService.TDAServiceClient color = new TDAService.TDAServiceClient();
                var resultado = color.BuscarColorID(lID);
                color.Close();
                lstColor.Clear();

                foreach (var r in resultado)
                {
                    txtNombre.Text = r.Nombre;
                }
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TDAService.TDAServiceClient color = new TDAService.TDAServiceClient();
            Colores c = new Colores();
            c.Nombre = txtNombre.Text;
            color.InsertColor(c);
            color.Close();
            this.Close();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            TDAService.TDAServiceClient color = new TDAService.TDAServiceClient();
            Colores c = new Colores();
            c.ID = lID;
            c.Nombre = txtNombre.Text;
            color.UpdateColor(c);
            color.Close();
            this.Close();
        }
    }
}
