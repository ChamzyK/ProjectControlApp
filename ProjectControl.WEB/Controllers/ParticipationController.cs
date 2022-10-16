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
        _participationRepo = unitOfWork.GetGenericRepository<Participation>();
    }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Project> _projectRepo;
    private readonly IGenericRepository<Employee> _employeeRepo;
    private readonly IGenericRepository<Participation> _participationRepo;

    [HttpGet]
    public IActionResult GetParticipation()
    {
        var participations = _participationRepo.GetWithInclude(p => p.Project!, p => p.Employee!);
        return Json(participations);
    }

    [HttpGet("{projectId:int}/{employeeId:int}")]
    public IActionResult GetParticipation(int projectId, int employeeId)
    {
        var participation = _participationRepo.FindById(projectId, employeeId);

        if (participation == null)
        {
            return NotFound();
        }

        return Json(participation);
    }

    [HttpGet("{projectId:int}")]
    public IActionResult GetEmployees(int projectId)
    {
        var projects = _projectRepo.GetWithInclude(
            project => project.ProjectId == projectId,
            project => project.Employees!);
        
        if(projects.Count() != 1)
        {
            return NotFound();
        }

        var project = projects.First();

        return Json(project.Employees);
    }

    [HttpPost]
    public IActionResult AddParticipation(Participation participation)
    {
        var project = _projectRepo.FindById(participation.ProjectId);
        var employee = _employeeRepo.FindById(participation.EmployeeId);

        if (_participationRepo.FindById(participation.ProjectId, participation.EmployeeId) != null)
        {
            return BadRequest();
        }

        if(project == null || employee == null)
        {
            return NotFound();
        }

        _participationRepo.Create(participation);
        _unitOfWork.SaveChanges();
        return Json(participation);
    }

    [HttpPut]
    public IActionResult EditParticipation(Participation participation)
    {
        if (_participationRepo.FindById(participation.ProjectId) == null)
        {
            return NotFound();
        }

        _participationRepo.Update(participation);
        _unitOfWork.SaveChanges();
        return Json(participation);
    }

    [HttpDelete("{projectId:int}/{employeeId:int}")]
    public IActionResult DeleteParticipation(int projectId, int employeeId)
    {
        var participation = _participationRepo.FindById(projectId, employeeId);

        if (participation == null)
        {
            return NotFound();
        }

        _participationRepo.Remove(participation);
        _unitOfWork.SaveChanges();
        return Json(participation);
    }

}
