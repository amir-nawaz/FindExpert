namespace FindExpert.Models
{
    /// <summary>
    /// This class is created to handle the graph of experts. 
    /// This class includs all the related methods to manuplate the Experts Graph.
    /// </summary>
    public class ExpertGraph : IExpertGraph
    {
        /// <summary>
        /// Total No of Experts.
        /// </summary>
        public int NoOfExperts { get; set; }

        /// <summary>
        /// List of all available Experts.
        /// </summary>
        public List<Expert> experts { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ExpertGraph()
        {
            experts = new List<Expert>();
        }

        /// <summary>
        /// Add new expert in the graph.
        /// </summary>
        /// <param name="expert"></param>
        public void AddExpert(Expert expert)
        {
            experts.Add(expert);
        }

        /// <summary>
        /// Get Expert Profile 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Expert GetExpert(int id)
        {
            return experts[id];
        }

        /// <summary>
        /// Count of Experts available in the graph.
        /// </summary>
        /// <returns></returns>
        public int GetExpertCount()
        {
            return experts.Count;
        }

        /// <summary>
        /// Add relation between two Experts.s
        /// </summary>
        /// <param name="firstExpertId"></param>
        /// <param name="secondExpertId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string addRelation(int firstExpertId, int secondExpertId)
        {
            //These Validation checks can be moved into separate functions / classes.

            // Check for identical experts.
            if (firstExpertId == secondExpertId) return "Experts are identical";

            // check both are valid experts
            if(!(experts.Count > firstExpertId && experts.Count > secondExpertId))
            {
                // Need to throw porper exception
                throw new ArgumentException();
            }
            
            // Check whether both experts are already friends.
            if (experts[firstExpertId].Friends.FindAll(p => (p == secondExpertId)).Count > 0)
            {
                // Need to throw proper message that already friends
                return "Both experts are already freinds";
            }

            // add as friends
            experts[firstExpertId].Friends.Add(secondExpertId);
            experts[secondExpertId].Friends.Add(firstExpertId);

            return "Both experts are connected.";
        }

        /// <summary>
        /// Get Relation Path between two experts.
        /// </summary>
        /// <param name="firstExpertId"></param>
        /// <param name="secondExpertId"></param>
        /// <returns></returns>
        public List<int> GetRelation(int firstExpertId, int secondExpertId)
        {
            //  Seach path between experts.
            List<int> path = FindPath(experts, firstExpertId, secondExpertId);

            // reutrn path if exists otherwise throw exception.
            return (path == null || path.Count == 0) ? throw new Exception("No Path found between two Experts") : path;
        }

        /// <summary>
        /// function to find whether this node is already visited or not.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool isNotVisited(int node, List<int> path)
        {
            for(int i =0; i < path.Count; i++)
            {
                if (path[i] == node)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Search the path between two experts.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        private List<int> FindPath(List<Expert> graph, int src, int dst)
        {
            Queue<List<int>> queue = new Queue<List<int>>();

            // maintains the list of current path.
            List<int> path = new List<int>();   
            path.Add(src);

            // Queue of visited paths to keep the record of path to return.
            queue.Enqueue(path);

            // loop through untill all paths have been traversed.
            while (queue.Count > 0)
            {
                path = queue.Dequeue();

                // check the last node
                int last = path[path.Count - 1];

                // if node matches with the destination then return the path.
                // I am not sure whether it will be short path or not.
                // was not able to do the detailed end to end testing.
                if (last == dst)
                {
                    // return the path between experts
                    return path;
                }

                // get the list of neighboring nodes.
                List<int> lastNode = graph[last].Friends;
                for(int i = 0; i < lastNode.Count; i++)
                {
                    // check whether this not is already visited.
                    if(isNotVisited(lastNode[i], path))
                    {
                        // enqueue the new path.
                        List<int> newPath = new List<int>(path);
                        newPath.Add(lastNode[i]);  
                        queue.Enqueue(newPath);
                    }
                }
            }

            return new List<int>();
        }
    }
}
