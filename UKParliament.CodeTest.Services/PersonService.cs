using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly IRepository<Person> _personRepository;


    public PersonService(IRepository<Person> personRepository)
    {
        _personRepository = personRepository;
    }

    public Person GetPerson(int id) 
    {
        return _personRepository.GetById(id);
    }

    public IEnumerable<Person> GetPeople()
    {
        return _personRepository.GetAll();
    }

    public void AddPerson(Person person)
    {
        _personRepository.Add(person);
    }

    public void UpdatePerson(Person person)
    {
        _personRepository.Update(person);
    }
}