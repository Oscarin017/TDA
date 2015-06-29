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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Page
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {            
            //TDAServicio.TDAServiceClient client = new TDAServicio.TDAServiceClient();
            //var lPais = client.SelectPais();

            //foreach (Paises p in lPais)
            //{
            //    ComboBoxItem cbi = new ComboBoxItem();
            //    cbi.Content = p.Nombre;
            //    cbPais.Items.Add(cbi);
            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Cliente w = new Popups.Cliente();
            w.ShowDialog();
        }
    }
}
