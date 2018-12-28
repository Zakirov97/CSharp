using DAL.dll.Model;
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

namespace VIEW.Pages
{
    /// <summary>
    /// Interaction logic for CreateModel.xaml
    /// </summary>
    public partial class CreateModel : Page
    {
        EntityModel db = new EntityModel();
        public CreateModel()
        {
            InitializeComponent();
            lvManuf.ItemsSource = db.TablesModel.ToList();
            List<int> myManufId = new List<int>();
            foreach (var item in db.TablesManufacturer.ToList())
            {
                myManufId.Add((((TablesManufacturer)item).intManufacturerID));
            }
            var rock = myManufId.Distinct();
            intManufacturerID.ItemsSource = rock;
        }

        private void lvManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TablesModel tmodel = (TablesModel)lvManuf.SelectedItem;
            if (tmodel != null)
            {
                intModelID.Text = tmodel.intModelID.ToString();
                strName.Text = tmodel.strName;
                intManufacturerID.Text = tmodel.intManufacturerID.ToString();
                intSMCSFamilyID.Text = tmodel.intSMCSFamilyID.ToString();
                strImage.Text = tmodel.strImage;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            TablesModel tmodel = new TablesModel();
            tmodel.strName = strName.Text;
            tmodel.intManufacturerID = Int32.Parse(intManufacturerID.Text);
            tmodel.intSMCSFamilyID = Int32.Parse(intSMCSFamilyID.Text);
            tmodel.strImage = strImage.Text;

            db.TablesModel.Add(tmodel);
            db.SaveChanges();
            lvManuf.ItemsSource = db.TablesModel.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TablesModel tmodel = (TablesModel)lvManuf.SelectedItem;
            if (tmodel != null)
            {
                db.TablesModel.Remove(tmodel);
                db.SaveChanges();
                lvManuf.ItemsSource = db.TablesModel.ToList();
            }
            else
            {
                MessageBox.Show("Please select the item you want to delete");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvManuf.SelectedIndex >= 0)
            {
                TablesModel tmodel = (TablesModel)lvManuf.SelectedItem;
                foreach (var item in db.TablesModel)
                {
                    if (item.intManufacturerID == tmodel.intManufacturerID)
                    {
                        item.intManufacturerID =Int32.Parse(intManufacturerID.Text);
                        item.strName = strName.Text;
                        item.intSMCSFamilyID = Int32.Parse(intSMCSFamilyID.Text);
                        item.strImage = strImage.Text;
                        break;
                    }
                }
                db.SaveChanges();
                lvManuf.ItemsSource = db.TablesModel.ToList();
            }
            else
            {
                MessageBox.Show("Please select the item you want to update");
            }
        }
    }
}
