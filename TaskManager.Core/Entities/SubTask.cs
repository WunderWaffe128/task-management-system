using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class SubTask
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public TaskItem? Task { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string Title { get; set; } = string.Empty;
    }
}
