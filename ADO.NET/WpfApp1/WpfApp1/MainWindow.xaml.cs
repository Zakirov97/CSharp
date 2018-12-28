using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            string myLogs = "";
            try
            {
                if (File.Exists("1.txt"))
                {
                    myLogs = File.ReadAllText("1.txt");
                }
                else
                {
                    File.CreateText("1.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with read logs from file. More info ---> " + ex.Message);
            }
            TBmain.Text = myLogs;
            BTNStop.IsEnabled = false;
        }

        private void insertLogInFile(string s)
        {
            TBmain.Text += "\n" + "[" + DateTime.Now.ToString() + "]" + s;
            try
            {
                using (StreamWriter file = new StreamWriter("1.txt", true))
                {
                    file.WriteLine("\n" + "[" + DateTime.Now.ToString() + "]" + s);
                }
            }
            catch (Exception ex)
            {
                TBmain.Text += string.Format("\n[{0}]Cannot insert log in file.", DateTime.Now.ToString());
                MessageBox.Show("Cannot insert logs in file." + "\n" + ex.Message);
            }
        }

        private void BTNStart_Click(object sender, RoutedEventArgs e)
        {
            insertLogInFile("Programm is started working.");
            BTNStart.IsEnabled = false;
            BTNStop.IsEnabled = true;
            #region Connection to database 
            Program pr;
            try
            {
                pr = new Program();
            }
            catch (Exception ex)
            {
                insertLogInFile("Connection string doesn't exist. More info: " + ex.Message);
            }
            #endregion
            #region Load Rates
            try
            {
                Program.LoadRates();
                insertLogInFile("Successfully loaded Rates");
                insertLogInFile("Programm is paused");
            }
            catch (Exception ex)
            {
                insertLogInFile("Cannot Load Rates. More info: " + ex.Message);
            }
            #endregion
            dispatcherTimer.Tick -= DispatcherTimer_Tick;

            dispatcherTimer.Interval = new TimeSpan(0, 5, 0);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            insertLogInFile("Auto update after 5 min");
            BTNStart_Click(null, null);
        }

        private void BTNStop_Click(object sender, RoutedEventArgs e)
        {
            insertLogInFile("Timer off.");
            insertLogInFile("Programm is disabled. ");
            dispatcherTimer.Stop();
            BTNStop.IsEnabled = false;
            BTNStart.IsEnabled = true;
        }
    }
}
