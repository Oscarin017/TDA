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

namespace TDAWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            Usuarios u = tda.BuscarUsuarioAlias(txtAlias.Text);
            tda.Close();
            if (u != null)
            {
                if (u.Contraseña == txtContrasena.Text)
                {
                    MainWindow w = new MainWindow(u.ID);
                    w.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.");
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
