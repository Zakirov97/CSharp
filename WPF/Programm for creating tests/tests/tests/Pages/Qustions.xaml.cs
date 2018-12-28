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

namespace tests.Pages
{
    /// <summary>
    /// Логика взаимодействия для Qustions.xaml
    /// </summary>
    public partial class Qustions : Page
    {
        Model.ModelEntity model = new Model.ModelEntity();
        public Qustions()
        {
            InitializeComponent();
            cbSections.ItemsSource = model.Sections.ToList();
        }


        private void cbSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Sections sec = (Model.Sections)((ComboBox)sender).SelectedItem;
            expQuestion.Header = string.Empty;
            expQuestion.Content = null;
            expQuestion.IsEnabled = false;
            cbQuestions.SelectedItem = null;
            cbQuestions.ItemsSource = model.Questions.Where(p => p.SectionId == sec.SectionId && p.IsDeleted == false).ToList();
        }

        private void cbQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Questions que = (Model.Questions)((ComboBox)sender).SelectedItem;

            if (que == null)
                return;

            expQuestion.Header = que.QuestionContent;

            WrapPanel panel = new WrapPanel();
            panel.Orientation = Orientation.Vertical;

            List<Model.Answers> ans = model.Answers.Where(p=>p.QuestionId == que.QuestionId).ToList();
            foreach (var item in ans)
            {
                Label label = new Label();
                label.Content = item.Content;

                if (item.IsCorrect == false)
                    label.Foreground = Brushes.Red;
                else
                    label.Foreground = Brushes.Green;

                panel.Children.Add(label);
            }
            expQuestion.Content = panel;
            expQuestion.IsEnabled = true;
        }
    }
}
