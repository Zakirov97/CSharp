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
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        ModelEntity db = new ModelEntity();
        public UsersPage()
        {
            InitializeComponent();
            UsersInfo.ItemsSource = db.Library_Users.ToList();
        }

        private void UsersInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var l = (Library_Users)(((ListView)sender).SelectedItem);
            UserAddress.Text = l.UserAddress;
            UserName.Text = l.UserName;
            UserIdentificationNumber.Text = l.UserIdentificationNumber.ToString();
            UserYearOfBirth.Text = l.UserYearOfBirth.ToString();
        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            var v = (Library_Users)(UsersInfo.SelectedItem);
            if (v != null)
            {
                foreach (var item in db.Library_Users)
                {
                    if (item.Id == v.Id)
                    {
                        item.UserAddress = UserAddress.Text;
                        item.UserName = UserName.Text;
                        item.UserIdentificationNumber = Int32.Parse(UserIdentificationNumber.Text);
                        item.UserYearOfBirth = Convert.ToDateTime(UserYearOfBirth.Text);
                        break;
                    }
                }
                try
                {
                    db.SaveChanges();
                    UsersInfo.ItemsSource = db.Library_Users.ToList();
                    MessageBox.Show("Successfully updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select User");
            }
        }

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            Library_Users lu = new Library_Users();
            try
            {
                lu.UserAddress = UserAddress.Text;
                lu.UserName = UserName.Text;
                lu.UserIdentificationNumber = Int32.Parse(UserIdentificationNumber.Text);
                lu.UserYearOfBirth = Convert.ToDateTime(UserYearOfBirth.Text);
                db.Library_Users.Add(lu);
                db.SaveChanges();
                UsersInfo.ItemsSource = db.Library_Users.ToList();
                MessageBox.Show("User successfully added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
