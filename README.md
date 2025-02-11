## Task Tracker

A Task Tracker built using ASP.NET Core MVC that allows users to create, manage, and track tasks efficiently.


## Features

✔ Add Tasks – Create new tasks with details like name, description, priority, due date, and tags.
✔ Edit Tasks – Modify existing tasks and update their details.
✔ Complete Tasks – Mark tasks as completed.
✔ Delete Tasks – Remove unwanted tasks from the list.
✔ Task Count – Display the total number of tasks on the index page.
✔ Data Persistence – Tasks are stored and retrieved from a JSON file.


## Project Structure

* Task Model: The TaskModel represents a task with the following properties.
* Task Repository: Tasks are stored in a JSON file for persistence. The TaskRepository provides methods to load and save tasks.



## Routes & Endpoints

| Endpoint              | Description                 |
|-----------------------|---------------------------|
| `/Task`              | View all tasks            |
| `/Task/Create`       | Add a new task           |
| `/Task/Edit/{id}`    | Edit a task              |
| `/Task/Complete/{id}`| Mark task as completed  |
| `/Task/Delete/{id}`  | Delete a task           |
