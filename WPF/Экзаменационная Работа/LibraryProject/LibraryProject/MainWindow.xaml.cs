using LibraryProject.Model;
using LibraryProject.Pages;
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

namespace LibraryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelEntity db = new ModelEntity();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            Library_Registered_Accounts LRA = db.Library_Registered_Accounts.FirstOrDefault(f => f.AccountName == AccountLogin.Text && f.AccountPassword == AccountPassword.Password);
            if (LRA != null)
            {
                if (LRA.AccountRole)
                {
                    AdminMainWindow adminMainWindow = new AdminMainWindow();
                    adminMainWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Login or Password!");
            }
        }
    }
}
