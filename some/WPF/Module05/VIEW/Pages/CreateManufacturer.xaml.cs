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
    /// Interaction logic for CreateManufacturer.xaml
    /// </summary>
    public partial class CreateManufacturer : Page
    {
        EntityModel db = new EntityModel();
        public CreateManufacturer()
        {
            InitializeComponent();
            lvManuf.ItemsSource = db.TablesManufacturer.ToList();
        }

        private void lvManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TablesManufacturer manuf = (TablesManufacturer)lvManuf.SelectedItem;
            if (manuf != null)
            {
                strManufacturerChecklistId.Text = manuf.strManufacturerChecklistId;
                strName.Text = manuf.strName;
                intManufacturerID.Text = manuf.intManufacturerID.ToString();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (strName.Text != "")
            {
                TablesManufacturer manuf = new TablesManufacturer();
                manuf.strManufacturerChecklistId = strManufacturerChecklistId.Text;//50 chisel
                manuf.strName = strName.Text;//50 chisel
                db.TablesManufacturer.Add(manuf);
                db.SaveChanges();
                lvManuf.ItemsSource = db.TablesManufacturer.ToList();
            }
            else
            {
                MessageBox.Show("FIll strName");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TablesManufacturer manuf = (TablesManufacturer)lvManuf.SelectedItem;
            if (manuf != null)
            {
                db.TablesManufacturer.Remove(manuf);
                db.SaveChanges();
                lvManuf.ItemsSource = db.TablesManufacturer.ToList();
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
                TablesManufacturer manuf = (TablesManufacturer)lvManuf.SelectedItem;
                foreach (var item in db.TablesManufacturer)
                {
                    if (item.intManufacturerID == manuf.intManufacturerID)
                    {
                        item.strManufacturerChecklistId = strManufacturerChecklistId.Text;
                        item.strName = strName.Text;
                        break;
                    }
                }
                db.SaveChanges();
                lvManuf.ItemsSource = db.TablesManufacturer.ToList();
            }
            else
            {
                MessageBox.Show("Please select the item you want to update");
            }
        }
    }
}
