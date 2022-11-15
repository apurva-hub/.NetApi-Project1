using ApiProject1.Interface;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiProject1.Controllers
{ 
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _projectService;
        
        public ProjectController(IProject ProjectService)
        {
            _projectService = ProjectService;
            
        }
        task_managerContext data = new task_managerContext();
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            var projects = _projectService.GetProject();   
            return projects;

        }
        [HttpGet("{id}")]
        public IEnumerable<Project> Get(int id)
        {
            var projectById = _projectService.GetProjectById(id); 
            return projectById;

        }
        [HttpPost]
        public int Post(string ProjectTitle, string ProjectDesc, int currentUserId)
        {
            var isProjectCreated = _projectService.CreateNewProject(ProjectTitle, ProjectDesc, currentUserId);            
            return isProjectCreated;

        }
        [HttpDelete]
        public bool Delete(int projectId)
        {
            var deleteTaskById = _projectService.DeleteProjectById(projectId);
            return deleteTaskById;
        }
    }
}
