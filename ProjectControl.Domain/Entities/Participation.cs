namespace ProjectControl.Domain.Entities;

public class Participation
{
    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public bool IsManaged { get; set; }
}
