using ApiProject1.Interface;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web;

namespace ApiProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IRegister _registerService;
        public RegisterController(IRegister RegisterService)
        {
             _registerService = RegisterService;
        }
            task_managerContext data = new task_managerContext();
       
        [HttpGet]
        public IEnumerable<Register> Get(string email, string password)
        {
            var userExists = _registerService.IsUserExists(email, password);
            return userExists;
        }
        
        [HttpPost]
        public bool Post(string firstName, string email, string password)
        {
            bool isUserCreated = _registerService.CreateNewUser(firstName, email, password);
            return isUserCreated;
        }
    }
}
