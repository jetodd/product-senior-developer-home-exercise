using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

public class PersonRepository<T> : IDisposable, IRepository<Person> where T : class
{
    private readonly PersonManagerContext _context;

    public PersonRepository(PersonManagerContext context)
    {
        _context = context;
    }

    public void Add(Person entity)
    {
        _context.People.Add(entity).State = EntityState.Added;
        _context.SaveChanges();
    }

    public IEnumerable<Person> GetAll()
    {
        return _context.People.Include(p => p.Department).ToList();
    }

    public Person? GetById(int id)
    {
        return _context.People.Include(p => p.Department).FirstOrDefault(p => p.Id == id);
    }

    public void Update(Person entity)
    {
        var toUpdate = _context.People.Find(entity.Id);

        if (toUpdate != null) {
            toUpdate.FirstName = entity.FirstName;
            toUpdate.LastName = entity.LastName;
            toUpdate.DateOfBirth = entity.DateOfBirth;
            toUpdate.Email = entity.Email;
            toUpdate.DepartmentId = entity.DepartmentId;

            _context.SaveChanges();
        }
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
