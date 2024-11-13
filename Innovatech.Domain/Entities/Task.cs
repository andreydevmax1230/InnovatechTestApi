namespace Innovatech.Domain.Entities;

/// <summary>
/// Class wich represent entity Task
/// </summary>
public class Task : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCompleted { get; set; }
    public bool Active { get; set; }
}
