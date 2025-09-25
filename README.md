# TaskTrackerCLIProject

A simple command-line task tracker built with C# 12 and .NET 8. This tool allows you to manage your tasks directly from the terminal, supporting basic CRUD operations and status management.

## Project Page

[https://github.com/tr0ngnhan879/TaskTrackerCLIProject](https://github.com/tr0ngnhan879/TaskTrackerCLIProject)

**Repository Clone URL:**  
`https://github.com/tr0ngnhan879/TaskTrackerCLIProject.git`

## Features

- Add new tasks with descriptions
- List all tasks or filter by status (`ToDo`, `InProgress`, `Done`)
- Update task descriptions
- Delete tasks by ID
- Change task status to `InProgress` or `Done`
- Persistent storage using a local JSON file (`tasks.json`)

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows, Linux, or macOS terminal

## Getting Started

1. **Clone the repository:**
2. **Restore dependencies:**

   Navigate to the project directory and run the following command:

   ```bash
   dotnet restore
   ```

3. **Run the CLI:**

   ```bash
   dotnet run
   ```

### Commands

- `add <description>`  
  Adds a new task with the given description.

- `list [status]`  
  Lists all tasks, or only those with the specified status (`ToDo`, `InProgress`, `Done`)

- `update <id> <new description>`  
  Updates the description of the task with the given ID.

- `delete <id>` 
  Deletes the task with the specified ID.

- `mark-in-progress <id>`  
  Changes the status of the task to `InProgress`.

- `mark-done <id>`  
  Changes the status of the task to `Done`.

- `exit`  
  Exits the application.

### Example Session

## Data Storage

Tasks are stored in a local JSON file (`tasks.json`) in the project directory. This file is created automatically on first run.

## License

This project is licensed under the MIT License.