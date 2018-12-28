using LibraryProject.Model;
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

namespace LibraryProject.Pages
{
    /// <summary>
    /// Interaction logic for AdminBooksPage.xaml
    /// </summary>
    public partial class AdminBooksPage : Page
    {
        public static Frame Booksframe;
        ModelEntity db = new ModelEntity();
        public AdminBooksPage()
        {
            InitializeComponent();
            BookFrame.Source = new Uri(@"../BooksPages/AddPage.xaml", UriKind.RelativeOrAbsolute);
            Booksframe = BookFrame;
        }

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            BookFrame.Source = new Uri(@"../BooksPages/AddPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            BookFrame.Source = new Uri(@"../BooksPages/EditPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            BookFrame.Source = new Uri(@"../BooksPages/DeletePage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
