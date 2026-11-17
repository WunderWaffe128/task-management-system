using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
