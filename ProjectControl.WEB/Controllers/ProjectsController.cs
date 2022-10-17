using Microsoft.AspNetCore.Mvc;
using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;

namespace ProjectControl.WEB.Controllers;

//TODO: try rewrite to generic controller
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

    [HttpGet("{propName}/{filter}")]
    public IActionResult FilterByString(string propName, string filter) //TODO: rewrite to switch method?
    {
        if(propName == nameof(Project.Name))
        {
            var projects = _projectRepo.Get(project => project.Name!.Contains(filter));
            return Json(projects);
        }
        else if(propName == nameof(Project.Client))
        {
            var projects = _projectRepo.Get(project => project.Client!.Contains(filter));
            return Json(projects);
        }
        else if (propName == nameof(Project.Executor))
        {
            var projects = _projectRepo.Get(project => project.Executor!.Contains(filter));
            return Json(projects);
        }
        return BadRequest();
    }

    [HttpGet("{propName}/{filter:int}")]
    public IActionResult FilterByInt(string propName, int filter)
    {
        if (propName == nameof(Project.Priority))
        {
            var projects = _projectRepo.Get(project => project.Priority == filter);
            return Json(projects);
        }
        return BadRequest();
    }

    [HttpGet("{propName}/{startFilter}/{endFilter}")]
    public IActionResult FilterByDate(string propName, DateTime startFilter, DateTime endFilter)
    {
        if (propName == nameof(Project.StartDate))
        {
            var projects = _projectRepo.Get(project => project.StartDate >= startFilter && project.StartDate <= endFilter);
            return Json(projects);
        }
        else if (propName == nameof(Project.EndDate))
        {
            var projects = _projectRepo.Get(project => project.EndDate >= startFilter && project.EndDate <= endFilter);
            return Json(projects);
        }
        return BadRequest();
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
