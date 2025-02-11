using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using System.Linq;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        // Display all tasks
        public IActionResult Index()
{
    var tasks = TaskRepository.LoadTasks(); 

    // Använd ViewData
    ViewData["TaskCount"] = tasks.Count;

    // Använd ViewBag
    ViewBag.Greeting = "Welcome to My Task Manager!";

    // Use ViewModel for parameter passing
    var viewModel = new TaskListViewModel
    {
        Tasks = tasks,
        TaskCount = tasks.Count,
        GreetingMessage = "This is the Tasks"
    };

    return View(viewModel); // Return an instance of a ViewModel
}


        // Show form for adding a task
        public IActionResult Create()
        {
            return View();
        }
          public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(string name, string email, string message)
        {
            TempData["Message"] = "Your message has been sent successfully!";
            return RedirectToAction("Index");
        }

        // Handle form submission
        [HttpPost]
public IActionResult Create(TaskModel task, List<string> tags)
{
    var tasks = TaskRepository.LoadTasks();
    task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1; 
    
    // Convert list of tags to a comma-separated string
    task.Tags = tags != null ? string.Join(", ", tags) : "";

    tasks.Add(task);
    TaskRepository.SaveTasks(tasks);
    TempData["Message"] = "Task added successfully!";
    return RedirectToAction("Index");
}



        // Mark task as completed
       public IActionResult Complete(int id)
{
    var tasks = TaskRepository.LoadTasks();
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task != null)
    {
        task.IsCompleted = true;
        TaskRepository.SaveTasks(tasks); // Save after updating
        TempData["Message"] = "Task marked as completed!";
    }
    return RedirectToAction("Index");
}


        // Edit GET - Displays the task details for editing
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tasks = TaskRepository.LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Edit POST - Saves the modified task
        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, TaskModel task, List<string> tags)
{
    if (id != task.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        var tasks = TaskRepository.LoadTasks();
        var existingTask = tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask != null)
        {
            existingTask.Name = task.Name;
            existingTask.Description = task.Description;
            existingTask.Priority = task.Priority;
            existingTask.DueDate = task.DueDate;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.Tags = tags != null ? string.Join(", ", tags) : "";
            existingTask.IsUrgent = task.IsUrgent; 

            TaskRepository.SaveTasks(tasks);
            TempData["Message"] = "Task updated successfully!";
        }
        return RedirectToAction(nameof(Index));
    }
    return View(task);
}


        // Delete GET - Displays confirmation for deleting a task
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tasks = TaskRepository.LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Delete POST - Executes the task deletion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tasks = TaskRepository.LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                TaskRepository.SaveTasks(tasks); // Save tasks after deletion
                TempData["Message"] = "Task deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
