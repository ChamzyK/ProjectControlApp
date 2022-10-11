using Microsoft.AspNetCore.Mvc;
using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;

namespace ProjectControl.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipationController : Controller
{
    public ParticipationController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _projectRepo = unitOfWork.GetGenericRepository<Project>();
        _employeeRepo = unitOfWork.GetGenericRepository<Employee>();
    }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Project> _projectRepo;
    private readonly IGenericRepository<Employee> _employeeRepo;

    [HttpPost("{projectId:int}/{employeeId:int}")]
    public IActionResult AddEmployee(int projectId, int employeeId)
    {
        var project = _projectRepo.FindById(projectId);
        var employee = _employeeRepo.FindById(employeeId);

        if (project == null || employee == null)
        {
            return NotFound();
        }

        var employees = project.Employees ?? new List<Employee>();
        if (employees.Contains(employee))
        {
            return Conflict($"Project with id({projectId}) already has employee with id({employeeId})");
        }

        employees.Add(employee);
        _unitOfWork.SaveChanges();

        return Ok();
    }

    [HttpDelete("{projectId:int}/{employeeId:int}")]
    public IActionResult RemoveEmployee(int projectId, int employeeId)
    {
        var project = _projectRepo.FindById(projectId);
        var employee = _employeeRepo.FindById(employeeId);

        if (project == null || employee == null || project.Employees == null)
        {
            return NotFound();
        }

        project.Employees.Remove(employee);
        _unitOfWork.SaveChanges();
        return Json(project);
    }

    [HttpPut("{projectId:int}/{employeeId:int}/{isManager:bool?}")]
    public IActionResult SetManager(int projectId, int employeeId, bool isManager = false)
    {
        var project = _projectRepo.FindById(projectId);
        var employee = _employeeRepo.FindById(employeeId);

        if (project == null || employee == null)
        {
            return NotFound();
        }

        var participation = project.Participations.Find(p => p.EmployeeId == employeeId);
        if (participation == null)
        {
            return NotFound($"Employee {employee.LastName} {employee.FirstName} was not added on the project {project.Name}.");
        }

        if (isManager)
        {
            if (project.Participations.Any(part => part.IsManaged))
            {
                return Conflict($"Manager already define on the project {project.Name}.");
            }
        }

        participation.IsManaged = isManager;
        _unitOfWork.SaveChanges();
        return Json(project);

    }
}
