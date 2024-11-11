using System.IO;
using System.Windows;

namespace SurveyCreator
{
    public partial class MainWindow
    {
        private List<SurveyQuestion> questions = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            string questionText = QuestionTextBox.Text;
            bool isSingleChoice = SingleChoiceRadioButton.IsChecked == true;
            List<string> options = OptionsTextBox.Text.Split(',').Select(o => o.Trim()).ToList();

            if (!string.IsNullOrEmpty(questionText) && options.Count > 0)
            {
                questions.Add(new SurveyQuestion(questionText, isSingleChoice, options));
                RefreshQuestionsList();
                ClearInputFields();
            }
        }

        private void RefreshQuestionsList()
        {
            QuestionsListBox.Items.Clear();
            questions.ForEach(q => QuestionsListBox.Items.Add($"{q.QuestionText} ({(q.IsSingleChoice ? "Jednokrotnego wyboru" : "Wielokrotnego wyboru")})"));
        }

        private void ClearInputFields()
        {
            QuestionTextBox.Clear();
            OptionsTextBox.Clear();
            SingleChoiceRadioButton.IsChecked = true;
        }

        private void SaveSurveyButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("survey.txt"))
            {
                questions.ForEach(q =>
                {
                    writer.WriteLine(q.QuestionText);
                    writer.WriteLine(q.IsSingleChoice ? "Jednokrotnego wyboru" : "Wielokrotnego wyboru");
                    writer.WriteLine(string.Join(", ", q.Options));
                    writer.WriteLine();
                });
            }
            MessageBox.Show("Ankieta została zapisana.");
        }
    }
}