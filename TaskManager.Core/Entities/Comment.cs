using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public TaskItem? Task { get; set; }
        public User? User { get; set; }

    }
}
