using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
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
using didactic_palm_tree.UIModel;
using didactic_palm_tree.Views;

namespace didactic_palm_tree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WindowViewModel WindowViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            WindowViewModel = new WindowViewModel();
            this.DataContext = WindowViewModel;
        }

        private void Load_OnClick(object sender, RoutedEventArgs e)
        {
            WindowViewModel.model = Diagram.Load("test.sql");
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            WindowViewModel.model.Save();
        }
    }
}
