using ApiProject1.Interface;
using apiProject1_lib;

namespace ApiProject1.Services
{
    public class TaskService : ITask
    {
        private readonly task_managerContext _context;
        public TaskService(task_managerContext context)
        {
            _context = context;
        }
        public int DeleteTaskById(int taskId)
        {
            var deleteTaskById = _context.Tasks.Where(t => t.TaskId == taskId).FirstOrDefault();
            int isTaskDeleted = 0;
            if (deleteTaskById != null)
            {
                _context.Tasks.Remove(deleteTaskById);
                isTaskDeleted = _context.SaveChanges();
            }
            return isTaskDeleted;
        }
        
    }
}
