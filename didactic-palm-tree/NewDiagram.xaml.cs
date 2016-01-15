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

namespace didactic_palm_tree
{
    /// <summary>
    /// Interaction logic for NewDiagram.xaml
    /// </summary>
    public partial class NewDiagram : Window
    {
        public NewDiagram()
        {
            InitializeComponent();
        }

        public string DialogName => NameBox.Text;
        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
