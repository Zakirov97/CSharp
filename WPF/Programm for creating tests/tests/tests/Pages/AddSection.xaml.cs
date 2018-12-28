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
using tests.Model;

namespace tests.Pages
{
    /// <summary>
    /// Interaction logic for AddSection.xaml
    /// </summary>
    public partial class AddSection : Page
    {
        ModelEntity db = new ModelEntity();
        public AddSection()
        {
            InitializeComponent();
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                tests.Model.Sections sec = new tests.Model.Sections();
                sec.Name = tbSection.Text;
                db.Sections.Add(sec);
                db.SaveChanges();

                MainWindow.fr.Source = new Uri("/Pages/Sections.xaml", UriKind.RelativeOrAbsolute);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
