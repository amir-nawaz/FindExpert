
namespace FindExpert.Models
{
    public interface IExpert
    {
        List<string> Headings { get; set; }
        int Id { get; set; }
        string? Name { get; set; }

        string ToString();
    }
}