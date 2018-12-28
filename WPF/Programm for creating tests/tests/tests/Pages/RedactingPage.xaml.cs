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
    /// Логика взаимодействия для RedactingPage.xaml
    /// </summary>
    public partial class RedactingPage : Page
    {
        private Model.ModelEntity model = new Model.ModelEntity();

        public RedactingPage()
        {
            InitializeComponent();
            cbSections.ItemsSource = model.Sections.ToList();
        }

        private void cbSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Sections sec = (Model.Sections)((ComboBox)sender).SelectedItem;
            cbQuestions.ItemsSource = model.Questions.Where(p => p.SectionId == sec.SectionId && p.IsDeleted == false).ToList();
            if(cbQuestions.Items.Count > 0)
                cbQuestions.SelectedItem = cbQuestions.Items.GetItemAt(0);
        }

        private void cbQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Questions que = (Model.Questions)((ComboBox)sender).SelectedItem;

            if (que == null)
            {
                tbxQuestionContent.IsEnabled = false;
                tbxQuestionContent.Text = string.Empty;
                wpListAnswer.Children.RemoveRange(0, wpListAnswer.Children.Count);
                SaveButton.IsEnabled = false;
                return;
            }

            tbxQuestionContent.IsEnabled = true;
            SaveButton.IsEnabled = true;
            tbxQuestionContent.Text = que.QuestionContent;

            foreach (var item in model.Answers)
            {
                if(item.QuestionId == que.QuestionId)
                {
                    WrapPanel wp = new WrapPanel();
                    wp.Orientation = Orientation.Horizontal;

                    Label lb = new Label() { Content = "Ответ " + (wpListAnswer.Children.Count + 1) + ": " };
                    Label idLabel = new Label() { Content = item.AnswerId, IsEnabled = false, Name = "id"};
                    TextBox tb = new TextBox() { Width = 150, Name = "tb" + (wpListAnswer.Children.Count + 1) };
                    tb.Text = item.Content;

                    CheckBox cb = new CheckBox() { IsChecked = false };
                    cb.IsChecked = item.IsCorrect;

                    wp.Children.Add(lb);
                    wp.Children.Add(idLabel);
                    wp.Children.Add(tb);
                    wp.Children.Add(cb);


                    wpListAnswer.Children.Add(wp);
                }
            }


        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ((Model.Questions)cbQuestions.SelectedItem).QuestionContent = tbxQuestionContent.Text;

            foreach (WrapPanel item in wpListAnswer.Children)
            {
                Model.Answers answer = new Model.Answers();
                foreach (var item2 in item.Children)
                {

                    if (item2 is TextBox)
                        answer.Content = ((TextBox)item2).Text;

                    else if (item2 is CheckBox)
                        answer.IsCorrect = (bool)((CheckBox)item2).IsChecked;

                    else if (item2 is Label && ((Label)item2).Name == "id")
                        answer.AnswerId = Convert.ToInt32(((Label)item2).Content);
                }



                foreach (var item2 in model.Answers)
                {

                if(item2.AnswerId == answer.AnswerId)
                    {
                        item2.Content = answer.Content;
                        item2.IsCorrect = answer.IsCorrect;
                        break;
                    }
                }

            }

            model.SaveChanges();
        }
    }
}
