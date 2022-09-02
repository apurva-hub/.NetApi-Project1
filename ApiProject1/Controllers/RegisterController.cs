using ApiProject1.Interface;
using apiProject1_lib;
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
        Class1 ob = new Class1();
        [HttpGet]
        public IEnumerable<Register> Get()
        {
            var getUserDetails = _registerService.GetUserDetails();
            return getUserDetails;
        }
        
        [HttpPost]
        public bool Post([FromBody] Register r)
        {
            bool isUserCreated = _registerService.CreateNewUser(r);
            return isUserCreated;
        }
    }
}
