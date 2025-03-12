using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

public class DepartmentRepository<T> : IDisposable, IRepository<Department> where T : class
{
    private readonly PersonManagerContext _context;

    public DepartmentRepository(PersonManagerContext context)
    {
        _context = context;
    }

    public void Add(Department entity)
    {
        _context.Departments.Add(entity).State = EntityState.Added;
    }

    public IEnumerable<Department> GetAll()
    {
        return _context.Departments.ToList();
    }

    public Department? GetById(int id)
    {
        return _context.Departments.Find(id);
    }

    public void Update(Department entity)
    {
         _context.Entry(entity).State = EntityState.Modified;
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
