

using ClassLibrary1;

namespace ApiProject1.Interface
{
    public interface IRegister
    {
        public IEnumerable<Register> GetUserDetails();
        public bool CreateNewUser(string firstName, string email, string password);
        public IEnumerable<Register> IsUserExists(string email, string password);
    
    }
}
