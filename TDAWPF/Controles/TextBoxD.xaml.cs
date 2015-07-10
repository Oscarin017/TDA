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
    /// Interaction logic for TextBoxD.xaml
    /// </summary>
    public partial class TextBoxD : UserControl
    {
        private bool bInicial = false;
        private bool bPlaceHolder = true;
        private string sPlaceHolcer = "";

        public TextBoxD()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return tb.Text; }
            set { tb.Text = value; }
        }

        public bool PlaceHolder
        {
            get { return bPlaceHolder; }
            set { bPlaceHolder = value; }
        }

        public bool IsReadOnly
        {
            get { return tb.IsReadOnly; }
            set { tb.IsReadOnly = value; }
        }

        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            if(sPlaceHolcer == tb.Text)
            {
                tb.Text = "";
                bPlaceHolder = false;
                tb.Foreground = new SolidColorBrush(Colors.Black);
                tb.FontWeight = FontWeights.Bold;
            }
        }

        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb.Text == "")
            {
                tb.Text = sPlaceHolcer;
                bPlaceHolder = true;
                tb.Foreground = new SolidColorBrush(Colors.Gray);
                tb.FontWeight = FontWeights.Normal;
            }
        }

        private void tb_Loaded(object sender, RoutedEventArgs e)
        {
            if (sPlaceHolcer != tb.Text)
            {
                tb.Foreground = new SolidColorBrush(Colors.Black);
                tb.FontWeight = FontWeights.Bold;
                bPlaceHolder = false;
            }
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!bInicial)
            {
                sPlaceHolcer = tb.Text;
                bInicial = true;
            }
        }
    }
}