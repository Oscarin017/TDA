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
    /// Interaction logic for ComboBoxS.xaml
    /// </summary>
    public partial class ComboBoxS : UserControl
    {
        bool bInicial = false;
        string sPlaceHolder = "";

        public event EventHandler SelectionChanged;

        public virtual void OnSelectionChanged()
        {
            if (SelectionChanged!= null)
            {
                this.SelectionChanged(this, EventArgs.Empty);
            }
        }

        public ComboBoxS()
        {
            InitializeComponent();
        }

        public ItemCollection Items
        {
            get { return cb.Items; }
        }

        public int SelectedIndex
        {
            get { return cb.SelectedIndex; }
            set { cb.SelectedIndex = value; }
        }

        public object SelectedItem
        {
            get { return cb.SelectedItem; }
            set { cb.SelectedItem = value; }
        }

        public string SelectedValue
        {
            get { return cb.SelectedValue.ToString(); }
            set { cb.SelectedValue = value; }
        }

        public string Text
        {
            get { return cb.Text; }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            this.OnSelectionChanged();
        }
        
        public void Clear()
        {
            if (!bInicial)
            {
                bInicial = true;
                ComboBoxItem cbi = (ComboBoxItem)cb.Items[0];
                sPlaceHolder = cbi.Content.ToString();
            }
            cb.Items.Clear();
            ComboBoxItem cbi1 = new ComboBoxItem();
            cbi1.Content = sPlaceHolder;
            cbi1.IsSelected = true;
            cb.Items.Add(cbi1);
        }
    }
}
