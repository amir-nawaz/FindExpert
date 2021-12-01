
namespace FindExpert.Models
{
    public interface IExpertGraph
    {
        List<Expert> experts { get; set; }
        int NoOfExperts { get; set; }

        void AddExpert(Expert expert);
        Expert GetExpert(int id);
        string addRelation(int firstExpertId, int secondExpertId);
        List<int> GetRelation(int firstExpertId, int secondExpertId);
        int GetExpertCount();
    }
}