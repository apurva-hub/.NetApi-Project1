using ApiProject1.Interface;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosageController : ControllerBase
    {
        

        private readonly IDosage _dosageService;
            
            public DosageController(IDosage DosageService)
            {
                _dosageService = DosageService;
             
            }
        [HttpGet("{id}")]
        public IEnumerable<Dosage> Get(int id)
        {
            var projectById = _dosageService.dosageDetails(id);
            return projectById;

        }
    }
}
