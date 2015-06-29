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
    /// Interaction logic for Color.xaml
    /// </summary>
    public partial class Color : Page
    {
        List<Colores> lstColor = new List<Colores>();

        public Color()
        {
            InitializeComponent();
        }

        private void cargarGrid()
        {
            TDAService.TDAServiceClient color = new TDAService.TDAServiceClient();
            var resultado = color.SelectColor();
            color.Close();
            lstColor.Clear();

            foreach (var r in resultado)
            {
                lstColor.Add(new Colores()
                {
                    Nombre = r.Nombre
                });
            }

            dg.ItemsSource = null;
            dg.ItemsSource = lstColor;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrid();
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Color w = new Popups.Color();
            w.ShowDialog();
        }        
    }
}
