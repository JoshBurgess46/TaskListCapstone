using System;
using System.Collections.Generic;

namespace TaskListCapstone.Models
{
    public partial class TaskList
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Complete { get; set; }
    }
}
