using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskTracker.Models
{
    public static class TaskRepository
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "task.json");

        // Load tasks from JSON file
        public static List<TaskModel> LoadTasks()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
                }
            }
            return new List<TaskModel>();
        }

        // Save tasks to JSON file
        public static void SaveTasks(List<TaskModel> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
       
    }
}
