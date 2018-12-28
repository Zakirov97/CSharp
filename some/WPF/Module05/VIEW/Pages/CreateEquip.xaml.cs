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
    /// Interaction logic for CreateEquip.xaml
    /// </summary>
    public partial class CreateEquip : Page
    {
        EntityModel db = new EntityModel();
        public CreateEquip()
        {
            InitializeComponent();
            lvManuf.ItemsSource = db.newEquipment.ToList();
            #region For Combobox
            ////////intManufacturerID
            List<int> sourceForId = new List<int>();

            foreach (var item in db.newEquipment.ToList())
            {
                sourceForId.Add((((newEquipment)item).intManufacturerID));
            }
            var rock = sourceForId.Distinct();
            intManufacturerID.ItemsSource = rock;
            ////////intModelID
            List<int> sourceForModelId = new List<int>();

            foreach (var item in db.newEquipment.ToList())
            {
                sourceForModelId.Add((((newEquipment)item).intModelID));
            }
            var rock2 = sourceForModelId.Distinct();
            intModelID.ItemsSource = rock2;
            ////////intLocationId
            List<int> sourceForIntLocationId = new List<int>();

            foreach (var item in db.newEquipment.ToList())
            {
                sourceForIntLocationId.Add((((newEquipment)item).intLocationId));
            }
            var rock3 = sourceForIntLocationId.Distinct();
            intLocationId.ItemsSource = rock3;
            #endregion
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (intManufacturerID.SelectedItem != null && intModelID.SelectedItem != null && intLocationId.SelectedItem != null)
            {
                newEquipment newEquip = new newEquipment();
                newEquip.intManufacturerID = (int)intManufacturerID.SelectedItem;
                newEquip.intModelID = (int)intModelID.SelectedItem;
                newEquip.intLocationId = (int)intLocationId.SelectedItem;
                newEquip.intGarageRoom = intGarageRoom.Text;//50 chisel
                newEquip.strManufYear = strManufYear.Text;//4 chisla
                newEquip.strSerialNo = strSerialNo.Text;//20 chisel
                newEquip.intMetered = Convert.ToDouble(intMetered.Text);
                newEquip.LastDate = Convert.ToDateTime(LastDate.Text);
                if (CreateDate.Text != null)
                    newEquip.CreateDate = Convert.ToDateTime(CreateDate.Text);
                db.newEquipment.Add(newEquip);

                db.SaveChanges();
                lvManuf.ItemsSource = db.newEquipment.ToList();
            }
            else
            {
                if (intManufacturerID.SelectedItem == null)
                {
                    MessageBox.Show("FIll Manufacturer ID");
                }
                else if (intModelID.SelectedItem == null)
                {
                    MessageBox.Show("FIll intModelID");
                }
                else if (intLocationId.SelectedItem == null)
                {
                    MessageBox.Show("FIll intLocationId");
                }
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            newEquipment ne = (newEquipment)lvManuf.SelectedItem;
            if (ne != null)
            {
                db.newEquipment.Remove(ne);
                db.SaveChanges();
                lvManuf.ItemsSource = db.newEquipment.ToList();
            }
            else
            {
                MessageBox.Show("Please select the item you want to delete");
            }
        }

        private void lvManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newEquipment ne = (newEquipment)lvManuf.SelectedItem;
            if (ne != null)
            {
                intManufacturerID.SelectedItem = ne.intManufacturerID;
                intModelID.SelectedItem = ne.intModelID;
                intLocationId.SelectedItem = ne.intLocationId;
                intGarageRoom.Text = ne.intGarageRoom;
                strManufYear.Text = ne.strManufYear;
                strSerialNo.Text = ne.strSerialNo;
                intMetered.Text = ne.intMetered.ToString();
                LastDate.Text = ne.LastDate.ToString();
                CreateDate.Text = ne.CreateDate.ToString();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvManuf.SelectedIndex >= 0)
            {
                newEquipment ne = (newEquipment)lvManuf.SelectedItem;
                foreach (var item in db.newEquipment)
                {
                    if (item.intManufacturerID == ne.intManufacturerID && item.intModelID == ne.intModelID &&
                        item.intLocationId == ne.intLocationId && item.intGarageRoom == ne.intGarageRoom &&
                        item.strManufYear == ne.strManufYear && item.strSerialNo == ne.strSerialNo && item.intMetered == ne.intMetered &&
                        item.LastDate == ne.LastDate)
                    {
                        item.intManufacturerID = (int)intManufacturerID.SelectedItem;
                        item.intModelID = (int)intModelID.SelectedItem;
                        item.intLocationId = (int)intLocationId.SelectedItem;
                        item.intGarageRoom = intGarageRoom.Text;//50 chisel
                        item.strManufYear = strManufYear.Text;//4 chisla
                        item.strSerialNo = strSerialNo.Text;//20 chisel
                        item.intMetered = Convert.ToDouble(intMetered.Text);
                        item.LastDate = Convert.ToDateTime(LastDate.Text);
                        if (CreateDate.Text != null)
                            item.CreateDate = Convert.ToDateTime(CreateDate.Text);
                        break;
                    }
                }
                db.SaveChanges();
                lvManuf.ItemsSource = db.newEquipment.ToList();
            }
        }
    }
}
