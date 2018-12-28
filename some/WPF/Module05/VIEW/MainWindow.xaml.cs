using DAL.dll.Model;
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
using VIEW.Pages;

namespace VIEW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityModel db = new EntityModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CreateEquip();
        }

        private void Manufacturer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CreateManufacturer();
        }
        private void Model_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CreateModel();
        }
    }
}
