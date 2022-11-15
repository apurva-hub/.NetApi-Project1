using ClassLibrary1;

namespace ApiProject1.Interface
{
    public interface IDosage
    {
        public IEnumerable<Dosage> dosageDetails(int userId);
    }
}
