using Holiday.DAL.Model;
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

namespace Holiday.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplyForVacation.xaml
    /// </summary>
    public partial class ApplyForVacation : Page
    {
        public ApplyForVacation()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ModelHoliday db = new ModelHoliday();
            tbl_ApplicationData myApp = new tbl_ApplicationData();

            myApp.ApplicationDescription = Application_description.Text;
            myApp.ApplyingDate = Applying_date.SelectedDate;
            if (Ending_date.SelectedDate != null)
            {
                myApp.EndingDate = (DateTime)Ending_date.SelectedDate;
            }
            if (Starting_date != null)
            {
                myApp.StartingDate = (DateTime)Starting_date.SelectedDate;
            }
            myApp.UserName = User_name.Text;
            myApp.LeavePurpose = Leave_purpose.Text;
            myApp.LeaveTypeId = Convert.ToInt32(Leave_type_id.Text);
            myApp.NoOfDays = Convert.ToInt32(numbers_of_days.Text);

            db.tbl_ApplicationData.Add(myApp);
            db.SaveChanges();
            MainWindow.cframe.Source = new Uri(@"Pages/AdminHomePage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
