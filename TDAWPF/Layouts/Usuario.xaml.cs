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
using TDAWPF.Funcionalidad;

namespace TDAWPF.Layouts
{
    /// <summary>
    /// Interaction logic for Usuario.xaml
    /// </summary>
    public partial class Usuario : Page
    {
        List<Usuarios> lstUsuario = new List<Usuarios>();

        public Usuario()
        {
            InitializeComponent();
        }

        private void realizarBusqueda(Usuarios u)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbTipo.SelectedItem;
            if (cbTipo.SelectedIndex != 0)
            {
                u.Rol = Convert.ToInt64(cbi.Uid);
            }
            if (!txtAlias.PlaceHolder)
            {
                u.Alias = txtAlias.Text;
            }
            cargarGrid(u);
        }

        private void cargarGrid(Usuarios u)
        {
            TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
            var resultado = tda.SelectUsuario(u);
            tda.Close();
            var ordenado = resultado.OrderBy(Usuarios => Usuarios.RolNombre).ToList();
            lstUsuario.Clear();
            foreach (var r in ordenado)
            {
                lstUsuario.Add(new Usuarios()
                {
                    ID = r.ID,
                    Alias = r.Alias,
                    RolNombre = r.RolNombre
                });
            }
            dg.ItemsSource = null;
            dg.ItemsSource = lstUsuario;   
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            Llenado.cargarCBRol(cbTipo);
            realizarBusqueda(new Usuarios());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            realizarBusqueda(new Usuarios());            
        }    
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Popups.Usuario w = new Popups.Usuario();
            w.ShowDialog();
            realizarBusqueda(new Usuarios());
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios r = ((Button)sender).DataContext as Usuarios;
            long lID = r.ID;
            Popups.Usuario w = new Popups.Usuario(lID);
            w.ShowDialog();
            realizarBusqueda(new Usuarios());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios u = ((Button)sender).DataContext as Usuarios;
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres eliminar el proveedor " + u.Alias + ".", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                TDAService.TDAServiceClient tda = new TDAService.TDAServiceClient();
                Resultado r = tda.DeleteUsuario(u);
                if (r.ErrorDB)
                {
                    MessageBox.Show("No se pudo eliminar el producto " + u.Alias + ".");
                }
                realizarBusqueda(new Usuarios());
            }
        }   
    }
}
