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
    /// Interaction logic for OverDuePage.xaml
    /// </summary>
    public partial class OverDuePage : Page
    {
        ModelEntity db = new ModelEntity();
        public OverDuePage()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("In Progress");
            list.Add("Closed");
            ComBox.ItemsSource = list;
        }

        private void BTNSearch_Click(object sender, RoutedEventArgs e)
        {
            if (BookID.Text == "" && StudentID.Text == "")
            {
                MessageBox.Show("Input value for search");
            }
            else if (BookID.Text != "" && StudentID.Text != "")
            {
                if (db.AssignBooks.ToList().Exists(p => p.BookId == Int32.Parse(BookID.Text) && p.UserId == Int32.Parse(StudentID.Text) && !p.Status))
                {
                    AssignBooks assign = db.AssignBooks.ToList().FirstOrDefault(p => p.BookId == Int32.Parse(BookID.Text) && p.UserId == Int32.Parse(StudentID.Text) && !p.Status);
                    TBlockBookID.Text = assign.BookId.ToString();
                    TBlockReturnDate.Text = assign.EndDate.ToString();
                    TBlockStartDate.Text = assign.StartDate.ToString();
                    TBlockStudentID.Text = assign.UserId.ToString();
                    var pen = ((assign.EndDate - assign.StartDate).TotalDays) - 15;
                    if (pen > 0)
                    {
                        pen *= 5;
                        TBlockPenality.Text = pen.ToString();
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else
                    {
                        TBlockPenality.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("This User not assigned this Book");
                }
            }
        }

        private void BTNUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (BookID.Text == "" && StudentID.Text == "")
            {
                MessageBox.Show("Input StudentID and BookID");
            }
            else if (BookID.Text != "" && StudentID.Text != "")
            {
                if (db.AssignBooks.ToList().Exists(p => p.BookId == Int32.Parse(BookID.Text) && p.UserId == Int32.Parse(StudentID.Text)))
                {
                    foreach (var item in db.AssignBooks.ToList())
                    {
                        if (item.UserId == Int32.Parse(StudentID.Text) && item.BookId == Int32.Parse(BookID.Text))
                        {
                            if (ComBox.SelectedIndex == 1)
                            {
                                item.Status = true;
                            }
                        }
                    }
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This User not assigned this Book");
                }
            }


        }
    }
}
