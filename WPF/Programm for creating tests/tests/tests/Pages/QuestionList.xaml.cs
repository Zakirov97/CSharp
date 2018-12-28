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
using tests.Model;

namespace tests.Pages
{
    /// <summary>
    /// Interaction logic for QuestionList.xaml
    /// </summary>
    public partial class QuestionList : Page
    {
        ModelEntity db = new ModelEntity();
        public QuestionList()
        {
            InitializeComponent();

            foreach (var q in db.Questions)
            {
                Expander ex = new Expander();
                ex.Header = q.QuestionContent;
                WrapPanel wp = new WrapPanel();
                wp.Orientation = Orientation.Vertical;

                foreach (var item in
                    db.Answers.Where(w => w.QuestionId == q.QuestionId))
                {
                    Label l = new Label();
                    l.Content = item.Content;
                    wp.Children.Add(l);
                }

                ex.Content = wp;
                qList.Children.Add(ex);
            }
            


        }
    }
}
