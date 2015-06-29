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

namespace TDAWPF.Popups
{
    /// <summary>
    /// Interaction logic for Paquete.xaml
    /// </summary>
    public partial class Paquete : Window
    {
        public Paquete()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            }
            else if (rb.Content.ToString() == "Grupo Cliente")
            {
                tiGrupos.Visibility = Visibility.Visible;
            }
        }
    }
}
