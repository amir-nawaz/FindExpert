using FindExpert.Models;

namespace FindExpert.Services
{
    public interface IExpertService
    {
        void AddExpert(Expert expert);
        Expert GetExpert();
    }
}