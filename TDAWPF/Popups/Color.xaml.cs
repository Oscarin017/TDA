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
    /// Interaction logic for Color.xaml
    /// </summary>
    public partial class Color : Window
    {
        private string sID;

        public Color()
        {
            InitializeComponent();
        }

        public Color(string ID)
        {
            InitializeComponent();
            sID = ID;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (sID == null)
            {
                btnRegistrar.Visibility = Visibility.Visible;
            }
            else if (sID != null)
            {
                btnModificar.Visibility = Visibility.Visible;
            }
        }
    }
}
