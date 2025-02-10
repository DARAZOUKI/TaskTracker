using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(100, ErrorMessage = "Task name cannot exceed 100 characters.")]
        [Display(Name = "Task Name")]
        public required string Name { get; set; } 

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public required string Description { get; set; } 

        [Required(ErrorMessage = "Priority is required.")]
        public TaskPriority Priority { get; set; }  

        [Required(ErrorMessage = "Due Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; } 

        public bool IsCompleted { get; set; } = false;

        // Store selected tags as a comma-separated string
        public string Tags { get; set; } = "";

        public bool IsUrgent { get; set; }
    }
     public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
}
