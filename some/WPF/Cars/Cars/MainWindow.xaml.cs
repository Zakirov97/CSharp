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
using System.IO;

namespace Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// 

    public partial class MainWindow : Window
    {
            //string path =
            //    System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //MessageBox.Show((path));

        public static Frame StaticFrameItem1;
        public MainWindow()
        {
            InitializeComponent();
            StaticFrameItem1 = frameItem1;
        }

        private void tcMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((TabItem)tcMain.SelectedItem).Name == "item1")
            {
                frameItem1.Source = new Uri("/Pages/CatmanufPage.xaml", UriKind.RelativeOrAbsolute);
            }


            //if (((TabItem)tcMain.SelectedItem).Name == "item2")
            //{
            //    frameItem1.Source = new Uri("/Pages/CatmanufPage.xaml", UriKind.RelativeOrAbsolute)
            //}
        }
    }
}
