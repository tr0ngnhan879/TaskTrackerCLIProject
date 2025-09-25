using System.Threading.Tasks;
using TaskTrackerCLIProject.Models;

namespace TaskTrackerCLIProject.Services
{
    public class TaskManager
    {
        private readonly TaskStorage _storage;
        public TaskManager(TaskStorage storage) {
            _storage = storage;
        }

        public void Run()
        {
            Console.WriteLine("Task Tracker CLI (type 'exit' to quit)");
            while (true)
            {
                Console.Write("task-cli ");
                string? input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) continue;
                input = input.Trim();
                if (input.ToLower() == "exit") break;
                if (String.IsNullOrEmpty(input)) input = "list";

                Excute(input);
            }
        }
        public void Excute(string input)
        {
            string[] parts = input.Split(new[] { ' ' }, 2);
            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1] : string.Empty;

            switch (command)
            {
                case "add":
                    TaskModel task = _storage.Add(argument);
                    Console.WriteLine($"Task added successfully (ID: {task.Id})");
                    break;
                case "list":
                    Status? status = Enum.TryParse<Status>(argument, true, out var s) ? s : null;
                    List<TaskModel> tasks = _storage.GetAll(status);
                    foreach (TaskModel t in tasks)
                    {
                        Console.WriteLine($"[{t.Id}] {t.Description} - {t.Status}");
                    }
                    break;
                case "update":
                    var updateParts = argument.Split(new[] { ' ' }, 2);
                    _storage.Update(int.Parse(updateParts[0]), updateParts[1]);
                    break;
                case "delete":
                    _storage.Delete(int.Parse(argument));
                    Console.WriteLine("Task deleted successfully.");
                    break;
                case "mark-in-progress":
                    _storage.ChangeStatus(int.Parse(argument), Status.InProgress);
                    Console.WriteLine("Task marked as InProgress.");
                    break;
                case "mark-done":
                    _storage.ChangeStatus(int.Parse(argument), Status.Done);
                    Console.WriteLine("Task marked as Done.");
                    break;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    break;
            }
        }
    }
}
