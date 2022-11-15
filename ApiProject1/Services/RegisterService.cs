using ApiProject1.Interface;
using ClassLibrary1;
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
        public bool CreateNewUser(string firstName, string email, string password)
        {
            Register r = new Register();
            r.FirstName = firstName;
            r.LastName = null;
            r.EmailId = email;
            r.Password = password;
            _context.Registers.Add(r);
            bool isUserCreated = _context.SaveChanges() > 0;
            return isUserCreated;
        }

        public IEnumerable<Register> IsUserExists(string email, string password) 
        { 
            var userExists = _context.Registers.Where(r => r.EmailId == email && r.Password == password); 
            return userExists;
        }

        

    }
}
