using System;

namespace ChatbotApp.Models
{
    public class TaskItem
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
