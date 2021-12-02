using FindExpert.Models;
using FindExpert.Utility;
using System.Net;

namespace FindExpert.Services
{
    public class ExpertService : IExpertService
    {
        public IExpert _expert;
        public IExpertGraph _expertGraph;

        /// <summary>
        /// Constructor. Expert and ExpertGraph are injected using DI.
        /// </summary>
        /// <param name="expert"></param>
        /// <param name="expertGraph"></param>
        public ExpertService(IExpert expert, IExpertGraph expertGraph)
        {
            _expert = expert;
            _expertGraph = expertGraph;
        }

        /// <summary>
        /// Add Expert in the existing graph.
        /// </summary>
        /// <param name="expert"></param>
        public void AddExpert(Expert expert)
        {
            _expert.Id = expert.Id;
            _expert.Name = expert.Name;

            // I have written some logic to parse the html from given URL using the HtmlAgilityPack.
            // But I was not able to test is due to lack to time. That's why I have not enabled the parsing logic.
            // 

            // _expert.Headings = getHeadingsFromUrl(expert.Url);
            _expertGraph.AddExpert(expert);
        }

        /// <summary>
        /// Business logic to add the reltion between two Experts.
        /// </summary>
        /// <param name="firstExpertId"></param>
        /// <param name="secondExpertId"></param>
        /// <returns></returns>
        public string AddRelation(int firstExpertId, int secondExpertId)
        {
            return _expertGraph.addRelation(firstExpertId, secondExpertId);
        }

        /// <summary>
        /// Get Relation path between two experts.
        /// </summary>
        /// <param name="firstExpertId"></param>
        /// <param name="secondExpertId"></param>
        /// <returns></returns>
        public List<int> GetRelation(int firstExpertId, int secondExpertId) {
            return _expertGraph.GetRelation(firstExpertId, secondExpertId);
        }

        /// <summary>
        /// Get Experts profile for provided ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
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

        /// <summary>
        /// Get the count of experts.
        /// </summary>
        /// <returns></returns>
        public int GetExpertsCount()
        {
            return _expertGraph.GetExpertCount();
        }
        
        private List<string> getHeadingsFromUrl(string url)
        {
            string html = HtmlParser.ReadHtmlPage(url);
            return HtmlParser.ParseHtml(html);
        }
    }
}
