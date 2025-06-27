using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ChatbotApp
{
    public partial class MainWindow : Window
    {
        private List<string> activityLog = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInputTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            // Add user message to activity log
            AddToActivityLog($"You: {userMessage}");

            // Clear input box
            UserInputTextBox.Clear();

            // Get bot response (replace this with your actual NLP call)
            string botResponse = GetBotResponse(userMessage);

            // Add bot response to activity log
            AddToActivityLog($"Bot: {botResponse}");
        }

        private void AddToActivityLog(string message)
        {
            activityLog.Add(message);

            StringBuilder sb = new StringBuilder();
            foreach (var line in activityLog)
            {
                sb.AppendLine(line);
            }

            ChatLogTextBlock.Text = sb.ToString();
        }

        // Placeholder for your actual NLPService interaction
        private string GetBotResponse(string input)
        {
            // TODO: Replace with NLPService logic
            return $"You said '{input}', but I'm still learning!";
        }
    }
}
