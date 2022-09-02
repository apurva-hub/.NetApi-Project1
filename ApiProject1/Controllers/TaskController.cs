using ApiProject1.Interface;
using apiProject1_lib;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {                
        private readonly ITask _taskService;
        public TaskController(ITask TaskService)
        {
            _taskService = TaskService;
        }
        task_managerContext data = new task_managerContext();
        [HttpDelete]
        public int Delete(int taskId)
        {
            var deleteTaskById = _taskService.DeleteTaskById(taskId);
            return deleteTaskById;
        }
    }
}
