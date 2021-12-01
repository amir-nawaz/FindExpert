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

        [HttpPost("AddExpert/expertname/{name}/expertUrl/{url}")]
        [ActionName("AddExpert")]
        public IActionResult AddExpert(string name, string url)
        {
            Expert e = new Expert();
            e.Id = _expertService.GetExpertsCount();
            e.Name = name;
            e.Url = url;
            _expertService.AddExpert(e);

            return Ok(name + " is added and Id is " + e.Id + ". To create relationship or search use this Id.");
        }

        [ActionName("AddRelation")]
        [HttpPost("AddRelation/firstexpert/{firstExpertId}/secondexpert/{secondExpertId}")]
        public IActionResult AddRelation(int firstExpertId, int secondExpertId)
        {
            abc = "Relation added";
            
            return Ok(_expertService.AddRelation(firstExpertId, secondExpertId));
            // return abc;
        }

        [HttpGet("{identifier}")]
        [ActionName("GetExpert")]
        public IActionResult GetExpert(int identifier)
        {
            // a = abc;
            return Ok(_expertService.GetExpert(identifier));

        }

        [HttpGet("{start}/{end}")]
        [ActionName("GetRelation")]
        public List<int> GetRelation(int start, int end)
        {
            return _expertService.GetRelation(start, end);  
            // return "";

        }


        [HttpPost]
        [ActionName("setAbcString")]
        public IActionResult setAbcString(String a)
        {
            //try
            // {
                a = _expertService.setAbcString(a);
                abc = a;
                return Ok(abc);
            // }
            // catch (Exception ex)
           //  {
              //   throw new HttpResponseMessage;
            //}
            
        }
    }
}