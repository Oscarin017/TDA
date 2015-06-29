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
    /// Interaction logic for Pais.xaml
    /// </summary>
    public partial class Pais : Window
    {
        public Pais()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
