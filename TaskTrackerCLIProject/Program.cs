using TaskTrackerCLIProject.Services;

namespace TaskTrackerCLIProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            TaskStorage storage = new TaskStorage("tasks.json");
            TaskManager manager = new TaskManager(storage);
            manager.Run();
        }
    }
}
