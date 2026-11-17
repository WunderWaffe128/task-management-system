using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class TaskHistory
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
        public string ActionText { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }
        public TaskItem? Task { get; set; }
        public User? User { get; set; }
    }
}
