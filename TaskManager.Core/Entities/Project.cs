using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Status { get; set; } = "Active";
        public int? OwnerId { get; set; }
        public User? Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    }
}
