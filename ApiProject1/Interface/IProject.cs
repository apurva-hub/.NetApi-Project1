

using ClassLibrary1;

namespace ApiProject1.Interface
{
    public interface IProject
    {
        public IEnumerable<Project> GetProject();
        public IEnumerable<Project> GetProjectById(int id);
        public int CreateNewProject(string ProjectTitle, string ProjectDesc, int currentUserId);
        public bool DeleteProjectById(int projectId);
    }
}
