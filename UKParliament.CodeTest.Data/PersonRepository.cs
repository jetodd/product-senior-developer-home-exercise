using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

public class PersonRepository<T> : IRepository<Person> where T : class, IDisposable
{
    private readonly PersonManagerContext _context;

    public PersonRepository(PersonManagerContext context)
    {
        _context = context;
    }

    public void Add(Person entity)
    {
        _context.People.Add(entity).State = EntityState.Added;
    }

    public IEnumerable<Person> GetAll()
    {
        return _context.People.ToList();
    }

    public Person GetById(int id)
    {
        var person = _context.People.Find(id);

        return person;
    }

    public void Update(Person entity)
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