using ApiProject1.Interface;
using apiProject1_lib;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiProject1.Services
{
    public class RegisterService : IRegister
    {
        private readonly task_managerContext _context;
        public RegisterService(task_managerContext context)
        {
            _context = context;
        }
        public IEnumerable<Register> GetUserDetails()
        {
            var getUserDetails = _context.Registers;
            return getUserDetails;
        }
        public bool CreateNewUser(Register r)
        {
            _context.Registers.Add(r);
            bool isUserCreated = _context.SaveChanges() > 0;
            return isUserCreated;
        }
    }
}
