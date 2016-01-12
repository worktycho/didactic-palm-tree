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

namespace didactic_palm_tree.components
{
    /// <summary>
    /// Interaction logic for Battery.xaml
    /// </summary>
    public partial class Battery : Window
    {
        public Battery(UIModel.Battery model)
        {
            InitializeComponent();
            VoltageLabel.Content = model.Voltage;
            CurrentLabel.Content = model.Current;
        }
    }
}
