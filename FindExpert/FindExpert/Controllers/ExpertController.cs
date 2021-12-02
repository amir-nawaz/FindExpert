using FindExpert.Models;
using FindExpert.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FindExpert.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExpertController : ControllerBase
    {
       // we can use logger to log the details for debugging or tracing purposes.
        private readonly ILogger<ExpertController> _logger;

        private IExpertService _expertService;

        public ExpertController(ILogger<ExpertController> logger, IExpertService expertService)
        {

            _logger = logger;
            _expertService = expertService;
        }


        /// <summary>
        /// Add expert in system.
        /// </summary>
        /// <param name="name"> Name of Expert</param>
        /// <param name="url">Expert's Website URL</param>
        /// <returns>Operation message.</returns>
        [HttpPost("AddExpert/expertname/{name}/expertUrl/{url}")]
        [ActionName("AddExpert")]
        public IActionResult AddExpert(string name, string url)
        {
            /*
             * Sanitization of parameters can be done by using the availble annotation 
             * or we can do it by our self as well.
             * Not added anything regarding this for now.
             */

            Expert e = new Expert();
            e.Id = _expertService.GetExpertsCount();
            e.Name = name;
            e.Url = url;
            _expertService.AddExpert(e);

            return Ok(name + " is added and Id is " + e.Id + ". To create relationship or search use this Id.");
        }

        /// <summary>
        /// Add Relation between the Experts
        /// </summary>
        /// <param name="firstExpertId"></param>
        /// <param name="secondExpertId"></param>
        /// <returns></returns>
        [ActionName("AddRelation")]
        [HttpPost("AddRelation/firstexpert/{firstExpertId}/secondexpert/{secondExpertId}")]
        public IActionResult AddRelation(int firstExpertId, int secondExpertId)
        {
            return Ok(_expertService.AddRelation(firstExpertId, secondExpertId));
        }

        /// <summary>
        /// Get the required Expert details
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        [HttpGet("{identifier}")]
        [ActionName("GetExpert")]
        public IActionResult GetExpert(int identifier)
        {
            return Ok(_expertService.GetExpert(identifier));
        }

        /// <summary>
        /// Get relations between the experts
        /// </summary>
        /// <param name="start">First Expert Id</param>
        /// <param name="end">Second Expert Id</param>
        /// <returns></returns>
        [HttpGet("{start}/{end}")]
        [ActionName("GetRelation")]
        public List<int> GetRelation(int start, int end)
        {
            return _expertService.GetRelation(start, end);  
        }

    }
}