using apiProject1_lib;

namespace ApiProject1.Interface
{
    public interface IProject
    {
        public IEnumerable<Project> GetProject();
        public IEnumerable<Project> GetProjectById(int id);
        public int CreateNewProject(string ProjectTitle, string ProjectDesc, int currentUserId);
    }
}
