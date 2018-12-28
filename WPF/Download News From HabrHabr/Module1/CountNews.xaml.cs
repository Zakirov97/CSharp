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
using System.Windows.Shapes;

namespace Module1
{
    /// <summary>
    /// Interaction logic for CountNews.xaml
    /// </summary>
    public partial class CountNews : Window
    {
        public CountNews(int cnt)
        {
            InitializeComponent();
            ShowCount.Content = cnt.ToString() + " news";

        }
    }
}
