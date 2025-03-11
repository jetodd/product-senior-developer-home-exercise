using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly PersonManagerContext _dbcontext;

    public PersonService(PersonManagerContext db)
    {
        _dbcontext = db;
    }

    public Person GetPerson(int id) 
    {
        return _dbcontext.People.Include("Department").First(p => p.Id == id);
    }

    public List<Person> GetPeople()
    {
        return _dbcontext.People.Include("Department").ToList();
    }

    public void AddPerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }
}