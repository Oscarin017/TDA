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
    /// Interaction logic for Promocion.xaml
    /// </summary>
    public partial class Promocion : Window
    {
        public Promocion()
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
        
        private void esconderTipo()
        {
            txtPorcentaje.Visibility = Visibility.Collapsed;
            txtCantidad.Visibility = Visibility.Collapsed;
            txtPrecioFijo.Visibility = Visibility.Collapsed;
            txtLleva.Visibility = Visibility.Collapsed;
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
                            txtPaga.Visibility = Visibility.Visible;
                            txtLleva.Visibility = Visibility.Visible;
                            break;
                        }
                }
            }
        }
    }
}
