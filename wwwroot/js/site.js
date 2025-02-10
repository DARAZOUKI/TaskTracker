// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function() {
    document.querySelector("form").addEventListener("submit", function(event) {
        let nameInput = document.querySelector("[name='Name']");
        let dueDateInput = document.querySelector("[name='DueDate']");
        let priorityInput = document.querySelector("[name='Priority']");

        if (!nameInput.value.trim()) {
            alert("Task name is required!");
            event.preventDefault();
        }

        if (!dueDateInput.value) {
            alert("Please select a due date.");
            event.preventDefault();
        }

        if (!priorityInput.value) {
            alert("Please select a priority level.");
            event.preventDefault();
        }
    });
});
