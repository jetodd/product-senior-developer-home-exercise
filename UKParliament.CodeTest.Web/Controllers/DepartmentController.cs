using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService) {
        _departmentService = departmentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetDepartments()
    {
        var departments = _departmentService.GetDepartments();
        List<string> departmentNames = departments.Select(i => i.Name).ToList();

        return Ok(departmentNames);
    }
}