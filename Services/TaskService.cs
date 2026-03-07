using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem Create(string title)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = title,
                IsCompleted = false
            };

            _tasks.Add(task);
            return task;
        }

        public bool Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            return false;
            
            _tasks.Remove(task);
            return true;
        }

        public TaskItem? Complete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            return null;

            task.IsCompleted = true;
            return task;
        }
    }
}