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
    /// Interaction logic for BookAssignment.xaml
    /// </summary>
    public partial class BookAssignment : Page
    {
        ModelEntity db = new ModelEntity();
        bool FBook = false;
        bool FStud = false;
        public BookAssignment()
        {
            InitializeComponent();
        }

        private void BtnFindBook_Click(object sender, RoutedEventArgs e)
        {
            if (db.Books.ToList().Exists(p => p.Id == Int32.Parse(TxtBoxBookFind.Text)))
            {
                Books book = new Books();
                foreach (var item in db.Books.ToList())
                {
                    if (item.Id == Int32.Parse(TxtBoxBookFind.Text))
                    {
                        book = item;
                        FBook = true;
                        break;
                    }
                }
                TxtBoxBookAssigningDate.Text = DateTime.Now.ToString();
                TxtBoxBookName.Text = book.BookName;
                TxtBoxBookQuantity.Text = book.BookQuantity.ToString();
            }
        }

        private void BtnFindStudent_Click(object sender, RoutedEventArgs e)
        {
            if (db.Library_Users.ToList().Exists(p => p.Id == Int32.Parse(TxtBoxStudFind.Text)))
            {
                Library_Users users = new Library_Users();
                foreach (var item in db.Library_Users.ToList())
                {
                    if (item.Id == Int32.Parse(TxtBoxBookFind.Text))
                    {
                        users = item;
                        FStud = true;
                        break;
                    }
                }
                TxtBoxReturnDate.Text = DateTime.Now.AddDays(15).ToString();
                TxtBoxStudName.Text = users.UserName;
                TxtBoxStudIIN.Text = users.UserIdentificationNumber.ToString();
            }
        }

        private void BTNAssignBook_Click(object sender, RoutedEventArgs e)
        {
            if (FBook && FStud)
            {
                Books book = new Books();
                AssignBooks assign = new AssignBooks();
                foreach (var item in db.Books.ToList())
                {
                    if (item.Id == Int32.Parse(TxtBoxBookFind.Text))
                    {
                        book = item;
                        break;
                    }
                }

                if (book.BookQuantity >= 1)
                {
                    foreach (var item in db.Books.ToList())
                    {
                        if (item.Id == book.Id)
                        {
                            item.BookQuantity -= 1;
                            break;
                        }
                    }
                    try
                    {
                        assign.BookId = book.Id;
                        assign.UserId = Int32.Parse(TxtBoxStudFind.Text);
                        assign.StartDate =Convert.ToDateTime(TxtBoxBookAssigningDate.Text);
                        assign.EndDate = Convert.ToDateTime(TxtBoxReturnDate.Text);
                        assign.Penality = 0;
                        assign.Status = false;
                        db.AssignBooks.Add(assign);
                        db.SaveChanges();
                        FBook = false;
                        FStud = false;
                        MessageBox.Show("Book Successufully Assigned ");
                    }
                    catch (Exception ex)
                    {
                        foreach (var item in db.Books.ToList())
                        {
                            if (item.Id == book.Id)
                            {
                                item.BookQuantity += 1;
                                break;
                            }
                        }
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient Quantity Of Books");
                }
            }
            else if (!FBook)
            {
                MessageBox.Show("Enter Book ID and then press button \"Find Book\"");
            }
            else if (!FStud)
            {
                MessageBox.Show("Enter Student ID and then press button \"Find Student\"");
            }
        }
    }
}
