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

namespace TDAWPF.Layouts
{
    /// <summary>
    /// Interaction logic for Modelo.xaml
    /// </summary>
    public partial class Modelo : Page
    {
        public Modelo()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Modelo w = new Popups.Modelo();
            w.ShowDialog();
        }
    }
}
