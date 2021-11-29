namespace FindExpert.Models
{
    public class Expert : IExpert
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string> Headings { get; set; } = new List<string>();

        public override string ToString()
        {
            return "Expert Id-> " + this.Id + " Exper Name -> " + this.Name;
        }

    }
}
