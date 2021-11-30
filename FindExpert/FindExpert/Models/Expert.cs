namespace FindExpert.Models
{
    public class Expert : IExpert
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string> Headings { get; set; } = new List<string>();
        public List<int> Friends { get; set; } = new List<int>();

        public Expert deepCopy()
        {
            Expert temp = new Expert();
            temp.Id = this.Id;
            temp.Name = this.Name;
            temp.Headings = this.Headings;
            return temp;
        }

        public override string ToString()
        {
            return "Expert Id-> " + this.Id + " Exper Name -> " + this.Name;
        }

    }
}
