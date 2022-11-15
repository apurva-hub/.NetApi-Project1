using ApiProject1.Interface;
using ClassLibrary1;

namespace ApiProject1.Services
{
    public class DosageService: IDosage
    {
        private readonly task_managerContext _context;
    public DosageService(task_managerContext context)
    {
        _context = context;
    }
    
        public IEnumerable<Dosage> dosageDetails(int userId)
        {
            var dosageDetails = _context.Dosages.Where(r => r.UserId == userId);
            return dosageDetails;
        }
    }
}
