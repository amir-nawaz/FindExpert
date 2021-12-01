
namespace FindExpert.Models
{
    public interface IExpertGraph
    {
        List<Expert> experts { get; set; }
        int NoOfExperts { get; set; }

        void addExperts(Expert expert);
        Expert GetExpert(int id);
        void addRelation(int firstExpertId, int secondExpertId);
        List<int> GetRelation(int firstExpertId, int secondExpertId);
        int GetExpertCount();
    }
}