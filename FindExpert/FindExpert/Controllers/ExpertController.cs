using FindExpert.Models;
using FindExpert.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindExpert.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExpertController : ControllerBase
    {
       
        private readonly ILogger<ExpertController> _logger;
        public static string abc = "inital search expert";

        private IExpertService _expertService;

        public ExpertController(ILogger<ExpertController> logger, IExpertService expertService)
        {

            _logger = logger;
            _expertService = expertService;
        }

        [HttpPost]
        [ActionName("AddExpert")]
        public String AddExpert()
        {
            abc = "Expert is added";
            // return "successfully added";

            Expert e = new Expert();
            e.Id = _expertService.GetExpert().Id + 1;
            e.Name = "Amir" + e.Id;
            _expertService.AddExpert(e);

            return "successfully added";
        }

        [ActionName("AddRelation")]
        [HttpPost("/firstexpert/{firstExpertId}/secondexpert/{secondExpertId}")]
        public String AddRelation(int firstExpertId, int secondExpertId)
        {
            abc = "Relation added";
            
            _expertService.AddRelation(firstExpertId, secondExpertId);
            return abc;
        }

        [HttpGet("{identifier}")]
        [ActionName("GetExpert")]
        public String GetExpert(int identifier)
        {
            // a = abc;
            return _expertService.GetExpert().ToString();

        }

        [HttpGet("{start}/{end}")]
        [ActionName("GetRelation")]
        public List<int> GetAbcString(int start, int end)
        {
            return _expertService.GetRelation(start, end);  
            // return "";

        }


        [HttpPost]
        [ActionName("setAbcString")]
        public String setAbcString(String a)
        {
            abc = a;
            return abc;
        }
    }
}