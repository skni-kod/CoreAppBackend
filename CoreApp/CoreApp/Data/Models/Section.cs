namespace CoreApp.Data.Models;

public class Section
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public virtual List<Project>? Projects { get; set; }
}