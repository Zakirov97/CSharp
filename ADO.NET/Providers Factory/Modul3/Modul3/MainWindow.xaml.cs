using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
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

namespace Modul3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class newEquipment
        {
            public int intEquipmentID { get; set; }
            public string intGarageRoom { get; set; }
            public int intManufacturerID { get; set; }
            public int intModelID { get; set; }
            public string strManufYear { get; set; }
            public string strSerialNo { get; set; }

            public override string ToString()
            {
                string str = string.Format("intEquipmentID: {0}\n\t intGarageRoom: {1}\n\t intManufacturerID: {2}\n\t intModelID: {3}\n\t strManufYear: {4}\n\t strSerialNo: {5}",
                    intEquipmentID, intGarageRoom, intManufacturerID, intModelID, strManufYear, strSerialNo);
                return str;
            }
        }
        static List<newEquipment> newEquipments;
        public static void MyConnection(bool x)
        {
            newEquipments = new List<newEquipment>();
            DbProviderFactory provider;
            DbConnection con;
            if (x)
            {
                string factory = ConfigurationManager.AppSettings["factorySQL"];
                provider = DbProviderFactories.GetFactory(factory);
                con = provider.CreateConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionSQL"].ConnectionString;
            }
            else
            {
                string factory = ConfigurationManager.AppSettings["factoryOLEDB"];
                provider = DbProviderFactories.GetFactory(factory);
                con = provider.CreateConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionOLEDB"].ConnectionString;
            }

            //Создать команду
            DbCommand cmd = provider.CreateCommand();
            cmd.CommandText = ConfigurationManager.AppSettings["newEquipment"];
            cmd.Connection = con;

            //Открыть соединение и получить данные
            using (con)
            {
                con.Open();
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    newEquipment equipment = new newEquipment();
                    equipment.intEquipmentID = Convert.ToInt32(reader["intEquipmentID"]);
                    equipment.intGarageRoom = reader["intGarageRoom"].ToString();
                    equipment.intManufacturerID = Convert.ToInt32(reader["intManufacturerID"]);
                    equipment.intModelID = Convert.ToInt32(reader["intModelID"]);
                    equipment.strManufYear = reader["strManufYear"].ToString();
                    equipment.strSerialNo = reader["strSerialNo"].ToString();

                    newEquipments.Add(equipment);
                }
            }

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSQL_Click(object sender, RoutedEventArgs e)
        {
            MyConnection(true);
            lvManuf.ItemsSource = newEquipments;
        }

        private void ButtonAccess_Click(object sender, RoutedEventArgs e)
        {
            MyConnection(false);
            lvManuf.ItemsSource = newEquipments;
        }
    }
}
