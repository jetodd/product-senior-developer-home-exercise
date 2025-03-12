using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _departmentRepository;

    public DepartmentService(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    IEnumerable<Department> IDepartmentService.GetDepartments()
    {
        return _departmentRepository.GetAll();
    }
}
