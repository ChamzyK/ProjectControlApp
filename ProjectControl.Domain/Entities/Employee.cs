namespace ProjectControl.Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public List<Project>? Projects { get; set; } = new();
    public List<Participation> Participations { get; set; } = new();
}
