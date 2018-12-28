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
    /// Interaction logic for DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        ModelEntity db = new ModelEntity();
        public DeletePage()
        {
            InitializeComponent();
            BooksInfo.ItemsSource = db.Books.ToList();
        }

        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            if (BookID.Text != "")
            {
                if (db.Books.ToList().Exists(p => p.Id == Int32.Parse(BookID.Text)))
                {
                    try
                    {
                        db.Books.Remove((Books)BooksInfo.SelectedItem);
                        db.SaveChanges();
                        BooksInfo.ItemsSource = db.Books.ToList();
                        MessageBox.Show("Successfully deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Book with this ID is not exist");
                    return;
                }
            }
            else if (BookID.Text == "")
            {
                try
                {
                    db.Books.Remove((Books)BooksInfo.SelectedItem);
                    db.SaveChanges();
                    BooksInfo.ItemsSource = db.Books.ToList();
                    MessageBox.Show("Successfully deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
