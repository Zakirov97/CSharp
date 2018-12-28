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

namespace Cars.Pages
{
    /// <summary>
    /// Interaction logic for CatmanufPage.xaml
    /// </summary>
    public partial class CatmanufPage : Page
    {

        public CatmanufPage()
        {
            InitializeComponent();

            DirectoryInfo info = new DirectoryInfo(@"C:\Users\diasz\Desktop\Cars\Cars\Images");
            foreach (FileInfo item in info.GetFiles())
            {
                WrapPanel panel = new WrapPanel();
                panel.MouseLeftButtonDown += ClickOnWrapPanel;
                panel.Margin = new Thickness(3);
                panel.Width = 150;
                panel.Orientation = Orientation.Horizontal;

                Image img = new Image();
                img.Source = new BitmapImage(new Uri(item.FullName));
                img.Width = 32;

                string name = item.Name.Substring(0, item.Name.IndexOf('.') - 1);
                Label label = new Label()
                { Content = name, VerticalAlignment = VerticalAlignment.Center };

                //panel.Name = name;
                panel.Children.Add(img);
                panel.Children.Add(label);

                wpMain.Children.Add(panel);
            }
        }

        public string posImage = null;
        private void ClickOnWrapPanel(object sender, MouseButtonEventArgs e)
        {
           // posImage = ((WrapPanel)sender).Name;
        }
    }
}

