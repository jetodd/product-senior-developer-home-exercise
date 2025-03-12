namespace UKParliament.CodeTest.Data; 

public class DepartmentRepository<T> : IDisposable, IDepartmentRepository<Department> where T : class
{
    private readonly PersonManagerContext _context;

    public DepartmentRepository(PersonManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAll()
    {
        return _context.Departments.ToList();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
