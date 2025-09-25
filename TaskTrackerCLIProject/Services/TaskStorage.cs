using System.Text.Json;
using TaskTrackerCLIProject.Models;

namespace TaskTrackerCLIProject.Services
{
    public class TaskStorage
    {
        private readonly string _filePath = String.Empty;
        public TaskStorage(string filePath)
        {
            _filePath = filePath;
        }
        public List<TaskModel> Load() { 
            if(!File.Exists(_filePath))
            {
                return new List<TaskModel>();
            }
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }
        public void Save(List<TaskModel> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public TaskModel Add(string description)
        {
            List<TaskModel> tasks = Load();
            int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            TaskModel newTask = new TaskModel { Id = newId, Description = description, Status = Status.ToDo, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
            tasks.Add(newTask);
            Save(tasks);

            return newTask;
        }

        public void Update(int id, string newDescription)
        {
            List<TaskModel> tasks = Load();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Description = newDescription;
                task.UpdatedAt = DateTime.UtcNow;
                Save(tasks);
            }
        }

        public bool Delete(int id)
        {
            List<TaskModel> tasks = Load();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            tasks.Remove(task);
            Save(tasks);
            return true;
        }

        public bool ChangeStatus(int id, Status newStatus)
        {
            List<TaskModel> tasks = Load();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            task.Status = newStatus;
            task.UpdatedAt = DateTime.UtcNow;
            Save(tasks);
            return true;
        }

        public List<TaskModel> GetAll(Status? status = null)
        {
            List<TaskModel> tasks = Load();
            return status == null ? tasks : tasks.Where(t => t.Status == status).ToList();
        }
    }
}
