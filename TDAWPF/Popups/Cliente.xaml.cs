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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void rTipo_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Content.ToString() == "Moral")
            {
                txtApellidoPaterno.Visibility = Visibility.Collapsed;
                txtApellidoMaterno.Visibility = Visibility.Collapsed;
                txtNombre.Text = "Escribe Razon Social";
            }
            else if (rb.Content.ToString() == "Fisica" && rb.IsLoaded)
            {
                txtApellidoPaterno.Visibility = Visibility.Visible;
                txtApellidoMaterno.Visibility = Visibility.Visible;
                txtNombre.Text = "Escribe Nombre";
            }
        }

        private void cbPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
