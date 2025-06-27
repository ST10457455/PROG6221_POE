using ChatbotApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ChatbotApp
{
    public partial class QuestionWindow : Window
    {
        private List<Questions> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        public QuestionWindow()
        {
            InitializeComponent();
            LoadQuestions();
            ShowQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<Questions>
            {
                new Questions
                {
                    Question = "What is a strong password?",
                    Options = new List<string> { "12345", "password", "Qw!8zP#2", "abcdef" },
                    CorrectIndex = 2
                },
                new Questions
                {
                    Question = "Which of the following is a phishing attempt?",
                    Options = new List<string> {
                        "Email from your bank asking you to log in via a suspicious link",
                        "Newsletter from a tech site you subscribed to",
                        "Update notification from your antivirus",
                        "Friend sharing a funny video"
                    },
                    CorrectIndex = 0
                }
                // Add more questions here
            };
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var q = questions[currentQuestionIndex];
                QuestionText.Text = q.Question;
                OptionsListBox.ItemsSource = q.Options;
                OptionsListBox.SelectedIndex = -1;
                FeedbackText.Text = "";
            }
            else
            {
                MessageBox.Show($"Quiz Complete! Your score: {score}/{questions.Count}");
                Close();
            }
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsListBox.SelectedIndex == -1)
            {
                FeedbackText.Text = "Please select an answer.";
                return;
            }

            var q = questions[currentQuestionIndex];
            if (OptionsListBox.SelectedIndex == q.CorrectIndex)
            {
                score++;
                FeedbackText.Text = "✅ Correct!";
            }
            else
            {
                FeedbackText.Text = $"❌ Incorrect. Correct answer: {q.Options[q.CorrectIndex]}";
            }

            currentQuestionIndex++;
            ShowQuestion();
        }
    }
}
