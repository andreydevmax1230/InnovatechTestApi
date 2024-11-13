namespace Innovatech.Application.Model;

/// <summary>
/// Represent data information Task for final user
/// </summary>
public class TaskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCompleted { get; set; }
    public bool Active { get; set; }
}