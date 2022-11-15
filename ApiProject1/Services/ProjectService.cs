using ApiProject1.Interface;
using ClassLibrary1;

namespace ApiProject1.Services
{
    public class ProjectService : IProject
    {
        private readonly task_managerContext _context;
        public ProjectService(task_managerContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> GetProject()
        {
            var projects = _context.Projects;
            return projects;
        }
        public IEnumerable<Project> GetProjectById(int id)
        {
            var projectById = _context.Projects.Where(i => i.UserId == id);
            return projectById;

        }
        public int CreateNewProject(string ProjectTitle, string ProjectDesc, int currentUserId)
        {
            Project newProject = new Project();
            newProject.ProjectTitle = ProjectTitle;
            newProject.ProjectDescription = ProjectDesc;
            newProject.UserId = currentUserId;
            _context.Projects.Add(newProject);

            int isProjectCreated = _context.SaveChanges();
            return isProjectCreated;
        }
        public bool DeleteProjectById(int projectId)
        {
            var deleteProjectById = _context.Projects.Where(p => p.ProjectId == projectId).FirstOrDefault();
            bool isProjectDeleted = false;
            if (deleteProjectById != null)
            {
                _context.Projects.Remove((Project)deleteProjectById);
                isProjectDeleted = _context.SaveChanges() > 0;
            }
            return isProjectDeleted;
        }
    }
}
