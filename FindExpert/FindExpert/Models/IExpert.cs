
namespace FindExpert.Models
{
    public interface IExpert
    {
        List<string> Headings { get; set; }
        int Id { get; set; }
        string? Name { get; set; }
        List<int> Friends { get; set; }
        Expert deepCopy();
        string ToString();
    }
}