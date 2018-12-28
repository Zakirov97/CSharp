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
using StylesStuff.Windows;

namespace StylesStuff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Style1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label l = (Label)sender;
            switch (l.Name)
            {
                case "Style1":
                    {
                        WindowStyle1 style1 = new WindowStyle1();
                        style1.Show();
                    }
                    break;
                case "Style2":
                    {
                        WindowStyle2 style2 = new WindowStyle2();
                        style2.Show();
                    }
                    break;
                case "Style3":
                    {
                        WindowStyle3 style3 = new WindowStyle3();
                        style3.Show();
                    }
                    break;
                case "Style4":
                    {
                        WindowStyle4 style4 = new WindowStyle4();
                        style4.Show();
                    }
                    break;
            }
        }
    }
}
