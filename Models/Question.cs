namespace ChatbotApp.Models
{
    public class Questions
    {
        public string? Question { get; set; }
        public List<string>? Options { get; set; }
        public int CorrectIndex { get; set; }
    }
}