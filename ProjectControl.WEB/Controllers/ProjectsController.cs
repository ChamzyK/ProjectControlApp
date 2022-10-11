using Microsoft.AspNetCore.Mvc;
using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;

namespace ProjectControl.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : Controller
{
    public ProjectsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; 
        _projectRepo = unitOfWork.GetGenericRepository<Project>();
    }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Project> _projectRepo;

    #region Project api

    [HttpGet]
    public IActionResult GetProjects()
    {
        var projects = _projectRepo.Get();
        return Json(projects);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProject(int id)
    {
        var project = _projectRepo.FindById(id);

        if (project == null)
        {
            return NotFound();
        }

        return Json(project);
    }

    [HttpPost]
    public IActionResult AddProject(Project project)
    {
        if (_projectRepo.FindById(project.ProjectId) != null)
        {
            return BadRequest();
        }

        _projectRepo.Create(project);
        _unitOfWork.SaveChanges();
        return Json(project);
    }

    [HttpPut]
    public IActionResult EditProject(Project project)
    {
        if (_projectRepo.FindById(project.ProjectId) == null)
        {
            return NotFound();
        }

        _projectRepo.Update(project);
        _unitOfWork.SaveChanges();
        return Json(project);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProject(int id)
    {
        var project = _projectRepo.FindById(id);

        if (project == null)
        {
            return NotFound();
        }

        _projectRepo.Remove(project);
        _unitOfWork.SaveChanges();
        return Json(project);
    }

    #endregion
}
