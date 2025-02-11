using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class TaskListViewModel
    {
        public List<TaskModel> Tasks { get; set; } = new();
        public int TaskCount { get; set; }
        public string GreetingMessage { get; set; } = string.Empty;
    }
}
