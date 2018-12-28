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

namespace LibraryProject.BooksPages
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        ModelEntity db = new ModelEntity();
        public AddPage()
        {
            InitializeComponent();
        }

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            Books book = new Books();
            try
            {
                book.BookAuthor = BookAuthor.Text;
                book.BookName = BookName.Text;
                book.BookPrice = Int32.Parse(BookPrice.Text);
                book.BookPublishName = BookPublisherName.Text;
                book.BookQuantity = Int32.Parse(BookQuantity.Text);
                book.BookYearOfPublication = Convert.ToDateTime(YearOfPublication.Text);
                db.Books.Add(book);
                db.SaveChanges();
                MessageBox.Show("Your books have been added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
