namespace ProjectControl.Domain.Entities;

public class Project
{
    public int ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Client { get; set; }
    public string? Executor { get; set; }

    public int Priority { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<Employee>? Employees { get; set; } = new();
    public List<Participation> Participations { get; set; } = new();
}
