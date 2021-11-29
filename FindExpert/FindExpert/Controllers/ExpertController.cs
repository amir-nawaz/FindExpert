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
        [HttpPost]
        public String AddRelation()
        {
            abc = "Relation added";
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
        public String GetAbcString(int start, int end)
        {
            return abc;
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