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
    /// Interaction logic for ComboBoxSC.xaml
    /// </summary>
    public partial class ComboBoxSC : UserControl
    {
        public event EventHandler SelectionChanged;

        public virtual void OnSelectionChanged()
        {
            if (SelectionChanged!= null)
            {
                this.SelectionChanged(this, EventArgs.Empty);
            }
        }

        public ComboBoxSC()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return cb.Text; }
            set { cb.Text = value; }
        }

        public int SelectedIndex
        {
            get { return cb.SelectedIndex; }
            set { cb.SelectedIndex = value; }
        }

        public string SelectedValue
        {
            get { return cb.SelectedValue.ToString(); }
        }

        public ItemCollection Items
        {
            get { return cb.Items; }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex != 0)
            {
                cb.Foreground = new SolidColorBrush(Colors.Black);
                cb.FontWeight = FontWeights.Bold;
            }
            else
            {
                cb.Foreground = new SolidColorBrush(Colors.Gray);
                cb.FontWeight = FontWeights.Normal;
            }
            Text = Text;
            string s = cb.SelectedValue.ToString();
            this.OnSelectionChanged();
        }  
    }
}
