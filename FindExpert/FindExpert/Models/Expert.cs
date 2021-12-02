namespace FindExpert.Models
{
    public class Expert : IExpert
    {


        /// <summary>
        /// Id to recognise the unique Expert. it will be assigned while adding the Expert.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Contains the name of expert.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// contains the URL provided to add with Expert.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// List of Heading coming form 
        /// </summary>
        public List<string> Headings { get; set; } = new List<string>();

        /// <summary>
        /// Used List of int to store the Ids of friends.
        /// </summary>
        public List<int> Friends { get; set; } = new List<int>();

        /*public Expert deepCopy()
        {
            Expert temp = new Expert();
            temp.Id = this.Id;
            temp.Name = this.Name;
            temp.Headings = this.Headings;
            return temp;
        }*/

        public override string ToString()
        {
            return "Expert Id-> " + this.Id + " Exper Name -> " + this.Name;
        }

    }
}
