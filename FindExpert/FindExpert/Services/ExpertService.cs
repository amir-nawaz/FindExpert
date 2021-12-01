using FindExpert.Models;

namespace FindExpert.Services
{
    public class ExpertService : IExpertService
    {
        public IExpert _expert;
        public IExpertGraph _expertGraph;

        public ExpertService(IExpert expert, IExpertGraph expertGraph)
        {
            _expert = expert;
            _expertGraph = expertGraph;
        }
        
        public void AddExpert(Expert expert)
        {
            _expert.Id = expert.Id;
            _expert.Name = expert.Name;
            _expertGraph.addExperts(expert);
        }

        public void AddRelation(int firstExpertId, int secondExpertId)
        {
            _expertGraph.addRelation(firstExpertId, secondExpertId);
            return;
        }

        public List<int> GetRelation(int firstExpertId, int secondExpertId) {
            return _expertGraph.GetRelation(firstExpertId, secondExpertId);
        }

        public Expert GetExpert(int id)
        {
            return _expertGraph.GetExpert(id);
            // return (Expert)(_expert == null ? new Expert() : _expert);
        }

        public int GetExpertsCount()
        {
            return _expertGraph.GetExpertCount();
        }
    }
}
