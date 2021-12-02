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
            _expertGraph.AddExpert(expert);
        }

        public string AddRelation(int firstExpertId, int secondExpertId)
        {
            return _expertGraph.addRelation(firstExpertId, secondExpertId);
        }

        public List<int> GetRelation(int firstExpertId, int secondExpertId) {
            return _expertGraph.GetRelation(firstExpertId, secondExpertId);
        }

        public Expert GetExpert(int id)
        {
            if(id < 0 )
            {
                throw new ArgumentOutOfRangeException();  
            }
            Expert expert = _expertGraph.GetExpert(id);
            if(expert == null)
                throw new KeyNotFoundException();
            return expert;
        }

        public int GetExpertsCount()
        {
            return _expertGraph.GetExpertCount();
        }
    }
}
