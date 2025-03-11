using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class DepartmentService : IDepartmentService
{
    private readonly PersonManagerContext _dbcontext;

    public DepartmentService(PersonManagerContext db)
    {
        _dbcontext = db;
    }

    List<Department> IDepartmentService.GetDepartments()
    {
        return _dbcontext.Departments.ToList();
    }
}
