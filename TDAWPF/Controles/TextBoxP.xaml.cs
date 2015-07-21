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

namespace TDAWPF.Controles
{
    /// <summary>
    /// Interaction logic for TextBoxP.xaml
    /// </summary>
    public partial class TextBoxP : UserControl
    {
        private bool bInicial = false;
        private bool bPlaceHolder = true;
        private string sPlaceHolder = "";
        private string sPassword = "";

        public event EventHandler Click;

        public virtual void OnClick()
        {
            if (Click != null)
            {
                this.Click(this, EventArgs.Empty);
            }
        }

        public TextBoxP()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return pb.Password; }
            set { tb.Text = value; }
        }

        public bool PlaceHolder
        {
            get { return bPlaceHolder; }
            set { bPlaceHolder = value; }
        }

        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            tb.Visibility = Visibility.Hidden;
            pb.Visibility = Visibility.Visible;
            pb.Focus();
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!bInicial)
            {
                sPlaceHolder = tb.Text;
                bInicial = true;
            }
        }

        private void pb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pb.Password == "")
            {
                tb.Visibility = Visibility.Visible;
                i.Visibility = Visibility.Visible;
                pb.Visibility = Visibility.Hidden;
                btn.Visibility = Visibility.Hidden;
            }
        } 
        
        private void pb_KeyUp(object sender, KeyEventArgs e)
        {
            if (pb.Password == "")
            {
                i.Visibility = Visibility.Visible;
                btn.Visibility = Visibility.Hidden;
            }
            else
            {
                i.Visibility = Visibility.Hidden;
                btn.Visibility = Visibility.Visible;
            }
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            tb.Visibility = Visibility.Visible;
            tb.Text = pb.Password;
            pb.Visibility = Visibility.Hidden;
        }   
        
        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            tb.Visibility = Visibility.Hidden;
            tb.Text = sPlaceHolder;
            pb.Visibility = Visibility.Visible;
            pb.Focus();
        }     
    }
}