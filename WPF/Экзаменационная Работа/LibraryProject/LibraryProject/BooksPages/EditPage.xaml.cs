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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        ModelEntity db = new ModelEntity();
        public EditPage()
        {
            InitializeComponent();
            BooksInfo.ItemsSource = db.Books.ToList();
        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            var v = (Books)(BooksInfo.SelectedItem);
            if (v != null)
            {
                foreach (var item in db.Books)
                {
                    if (item.Id == v.Id)
                    {
                        item.BookAuthor = BookAuthor.Text;
                        item.BookName = BookName.Text;
                        item.BookPrice = Int32.Parse(BookPrice.Text);
                        item.BookPublishName = BookPublisherName.Text;
                        item.BookQuantity = Int32.Parse(BookQuantity.Text);
                        item.BookYearOfPublication = Convert.ToDateTime(YearOfPublication.Text);
                        break;
                    }
                }
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Successfully updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void BooksInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var l = (Books)(((ListView)sender).SelectedItem);
            BookAuthor.Text = l.BookAuthor;
            BookName.Text = l.BookName;
            BookPrice.Text = l.BookPrice.ToString();
            BookPublisherName.Text = l.BookPublishName;
            BookQuantity.Text = l.BookQuantity.ToString();
            YearOfPublication.Text = l.BookYearOfPublication.ToString();
        }
    }
}
