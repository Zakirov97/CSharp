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
    /// Interaction logic for AddQuestions.xaml
    /// </summary>
    public partial class AddQuestions : Page
    {
        ModelEntity db = new ModelEntity();
        public AddQuestions()
        {
            InitializeComponent();
            cbSections.ItemsSource = db.Sections.ToList();
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Horizontal;

            Label lb = new Label() {Content = "Ответ " + (wpListAnswer.Children.Count+1) + ": "};
            TextBox tb = new TextBox() {Width = 150, Name = "tb" + (wpListAnswer.Children.Count + 1)};
            CheckBox cb = new CheckBox() {IsChecked = false};

            wp.Children.Add(lb);
            wp.Children.Add(tb);
            wp.Children.Add(cb);

            wpListAnswer.Children.Add(wp);
        }

        private void btnSaveQ_Click(object sender, RoutedEventArgs e)
        {
            Questions q = new Questions();
            q.CreationDate = DateTime.Now;
            q.QuestionContent = tbxQuestion.Text;
            tests.Model.Sections sec = (tests.Model.Sections)cbSections.SelectedItem;
            q.SectionId = sec.SectionId;
            db.Questions.Add(q);
            db.SaveChanges();


            foreach (WrapPanel item in wpListAnswer.Children)
            {
                Answers aw = new Answers();
                aw.QuestionId = q.QuestionId;
                foreach (object an in item.Children)
                {
                    if (an.GetType().Name == "TextBox")
                    {
                        TextBox tb = (TextBox) an;
                        aw.Content = tb.Text;
                    }
                    else if (an.GetType().Name == "CheckBox")
                    {
                        CheckBox cb = (CheckBox) an;
                        aw.IsCorrect = (bool)cb.IsChecked;
                    }
                }
                db.Answers.Add(aw);
                db.SaveChanges();

            }


            MainWindow.fr.Source = new Uri("/Pages/QuestionList.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
