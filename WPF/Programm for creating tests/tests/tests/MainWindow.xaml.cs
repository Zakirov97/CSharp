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

namespace tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame fr;
        public MainWindow()
        {
            InitializeComponent();
            fr = MainFrame;
        }

        private void addSection_Click(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("/Pages/AddSection.xaml", UriKind.RelativeOrAbsolute);
        }

        private void SecList_Click(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("/Pages/Sections.xaml", UriKind.RelativeOrAbsolute);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("/Pages/AddQuestions.xaml", UriKind.RelativeOrAbsolute);
        }

        private void QustionList_Click(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("/Pages/Qustions.xaml", UriKind.RelativeOrAbsolute);
        }

        private void RedactQuestion_Click(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("/Pages/RedactingPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
