using FindExpert.Models;

namespace FindExpert.Services
{
    public class ExpertService : IExpertService
    {
        public IExpert _expert;
        public ExpertService(IExpert expert)
        {
            _expert = expert;
        }
        
        public void AddExpert(Expert expert)
        {
            // expert = new Expert();
            _expert.Id = expert.Id;
            _expert.Name = expert.Name;
        }

        public Expert GetExpert()
        {
            
            return (Expert)(_expert == null ? new Expert() : _expert);
        }
    }
}
