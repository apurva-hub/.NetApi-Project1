using apiProject1_lib;

namespace ApiProject1.Interface
{
    public interface IRegister
    {
        public IEnumerable<Register> GetUserDetails();
        public bool CreateNewUser(Register r);
    }
}
