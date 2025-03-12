using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public DepartmentController(IDepartmentService departmentService, IMapper mapper) {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DepartmentViewModel>> GetDepartments()
    {
        var departments = _departmentService.GetDepartments();

        var departmentsView = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);

        return Ok(departmentsView);
    }
}