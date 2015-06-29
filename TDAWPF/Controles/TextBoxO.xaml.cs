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
    /// Interaction logic for TextBoxO.xaml
    /// </summary>
    public partial class TextBoxO : UserControl
    {
        private bool bPlaceHolder = false;
        private string sPlaceHolcer = "";

        public TextBoxO()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return tbP.Text; }
            set { tbP.Text = value; }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!bPlaceHolder)
            {
                sPlaceHolcer = tb.Text;
                tb.Text = "";
                bPlaceHolder = true;
                tb.Foreground = new SolidColorBrush(Colors.Black);
                tb.FontWeight = FontWeights.Bold;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = sPlaceHolcer;
                tb.Foreground = new SolidColorBrush(Colors.Gray);
                tb.FontWeight = FontWeights.Normal;
            }
        }

    }
}