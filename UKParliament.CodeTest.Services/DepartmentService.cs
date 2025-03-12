using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository<Department> _departmentRepository;

    public DepartmentService(IDepartmentRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IEnumerable<Department> GetDepartments()
    {
        return _departmentRepository.GetAll();
    }
}
