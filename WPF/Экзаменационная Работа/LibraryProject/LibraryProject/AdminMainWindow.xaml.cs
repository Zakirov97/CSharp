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

namespace LibraryProject
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public static Frame adminFrame;
        public AdminMainWindow()
        { 
            InitializeComponent();
            AdminMainFrame.Source = new Uri(@"Pages/HomePage.xaml", UriKind.RelativeOrAbsolute);
            adminFrame = AdminMainFrame;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            AdminMainFrame.Source = new Uri(@"Pages/HomePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            AdminMainFrame.Source = new Uri(@"Pages/AdminBooksPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            AdminMainFrame.Source = new Uri(@"Pages/BookAssignment.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnOverDue_Click(object sender, RoutedEventArgs e)
        {
            AdminMainFrame.Source = new Uri(@"Pages/OverDuePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminMainFrame.Source = new Uri(@"Pages/UsersPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
    }
}
