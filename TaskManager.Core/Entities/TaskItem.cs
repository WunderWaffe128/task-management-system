using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? AssigneeId { get; set; }
        public int? AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "To Do";
        public string Priority { get; set; } = "Medium";
        public DateTime Deadline { get; set; }
        public Project? Project { get; set; }
        public User? Assignee { get; set; }
        public User? Author { get; set; }
        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();

    }
}
