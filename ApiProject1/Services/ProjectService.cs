using ApiProject1.Interface;
using apiProject1_lib;

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
            var projectById = _context.Projects.Where(i => i.ProjectId == id);
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
        public int DeleteProjectById(int projectId)
        {
            IEnumerable<Project> deleteProjectById = (IEnumerable<Project>)_context.Projects.Where(p => p.ProjectId == projectId).FirstOrDefault();
            int isProjectDeleted = 0;
            if (deleteProjectById != null)
            {
                _context.Projects.Remove((Project)deleteProjectById);
                isProjectDeleted = _context.SaveChanges();
            }
            return isProjectDeleted;
        }
    }
}
