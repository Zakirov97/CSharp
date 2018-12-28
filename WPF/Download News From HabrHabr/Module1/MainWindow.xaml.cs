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
using System.Xml;
using Xml;

namespace Module1
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

        private void GetInformation_Click(object sender, RoutedEventArgs e)
        {
            var tuple = XMLDoc.GetInfo();
            List<Item> myListInfo = tuple.Item1;
            List<string> titles = new List<string>();
            foreach (var item in myListInfo)
            {
                titles.Add(item.Title);
            }
            lbox.ItemsSource = titles;
            labelManagingEditor.Content = "Managing editor: " + tuple.Item2;
            labelGenerator.Content = "Generator: " + tuple.Item3;
            CountNews cn = new CountNews(titles.Count);
            cn.Show();
        }

        private void lbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = lbox.SelectedIndex;
            Item it = getInfoForOneTitle(index);
            labelDescription.Text = it.Description;
            labelPubdate.Content = "Date publication: " + it.PubDate;
            link.Content = "Link: " + it.Link;
        }

        private Item getInfoForOneTitle(int index)
        {
            var tuple = XMLDoc.GetInfo();
            List<Item> myListInfo = tuple.Item1;
            Item infoAboutOneNews = new Item();

            for (int i = 0; i < myListInfo.Count; i++)
            {
                if (i == index)
                {
                    infoAboutOneNews.Description = myListInfo[i].Description;
                    infoAboutOneNews.Link = myListInfo[i].Link;
                    infoAboutOneNews.PubDate = myListInfo[i].PubDate;
                    break;
                }
            }
            return infoAboutOneNews;
        }

        private void CreateXML_Click(object sender, RoutedEventArgs e)
        {
            if (txtb.Text != "Место сохранения файла")
            {
                XMLDoc.Serialise(txtb.Text);
            }
            else
            {

                PathError pe = new PathError();
                pe.Show();
            }
        }
    }
}
