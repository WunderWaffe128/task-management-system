using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int? PositionId { get; set; }
        public Position? Position { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public string? Skills { get; set; }
        public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
        public ICollection<TaskItem> CreatedTasks { get; set; } = new List<TaskItem>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();                                                                                    //ti lox
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
