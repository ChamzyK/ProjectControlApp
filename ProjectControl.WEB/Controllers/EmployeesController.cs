using Microsoft.AspNetCore.Mvc;
using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;

namespace ProjectControl.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController: Controller
{
    public EmployeesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _employeeRepo = unitOfWork.GetGenericRepository<Employee>();
    }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Employee> _employeeRepo;

    #region Employee api
     
    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = _employeeRepo.Get();
        return Json(employees);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetEmployee(int id)
    {
        var employee = _employeeRepo.FindById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Json(employee);
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee employee)
    {
        if (_employeeRepo.FindById(employee.EmployeeId) != null)
        {
            return BadRequest();
        }

        _employeeRepo.Create(employee);
        _unitOfWork.SaveChanges();
        return Json(employee);
    }

    [HttpPut]
    public IActionResult EditEmployee(Employee employee)
    {
        if (_employeeRepo.FindById(employee.EmployeeId) == null)
        {
            return NotFound();
        }

        _employeeRepo.Update(employee);
        _unitOfWork.SaveChanges();
        return Json(employee);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = _employeeRepo.FindById(id);

        if (employee == null)
        {
            return NotFound();
        }

        _employeeRepo.Remove(employee);
        _unitOfWork.SaveChanges();
        return Json(employee);
    }

    #endregion
}
