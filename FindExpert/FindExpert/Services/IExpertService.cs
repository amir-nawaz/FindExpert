using FindExpert.Models;

namespace FindExpert.Services
{
    public interface IExpertService
    {
        void AddExpert(Expert expert);
        Expert GetExpert(int id);
        void AddRelation(int firstExpertId, int secondExpertId);
        List<int> GetRelation(int firstExpertId, int secondExpertId);
        int GetExpertsCount();
    }
}