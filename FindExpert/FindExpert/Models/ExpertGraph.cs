namespace FindExpert.Models
{
    public class ExpertGraph : IExpertGraph
    {
        public int NoOfExperts { get; set; }
        public List<Expert> experts { get; set; }

        public ExpertGraph()
        {
            experts = new List<Expert>();
        }

        public void AddExpert(Expert expert)
        {
            experts.Add(expert);
        }

        public Expert GetExpert(int id)
        {
            return experts[id];
        }

        public int GetExpertCount()
        {
            return experts.Count;
        }

        public string addRelation(int firstExpertId, int secondExpertId)
        {
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

        public List<int> GetRelation(int firstExpertId, int secondExpertId)
        {
            //  Validation checks as AddRelation
            return FindPath(experts, firstExpertId, secondExpertId);

        }

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

        private List<int> FindPath(List<Expert> graph, int src, int dst)
        {
            Queue<List<int>> queue = new Queue<List<int>>();

            List<int> path = new List<int>();   
            path.Add(src);

            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                path = queue.Dequeue();

                int last = path[path.Count - 1];

                if (last == dst)
                {
                    // printPath
                    return path;
                }

                List<int> lastNode = graph[last].Friends;
                for(int i = 0; i < lastNode.Count; i++)
                {
                    if(isNotVisited(lastNode[i], path))
                    {
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
