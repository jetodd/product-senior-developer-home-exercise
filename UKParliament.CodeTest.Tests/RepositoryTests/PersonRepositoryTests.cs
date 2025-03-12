using Xunit;
using UKParliament.CodeTest.Data;
using EntityFrameworkCore.Testing.Moq;

namespace UKParliament.CodeTest.Tests.RespositoryTests;

public class PersonRepositoryTests
{
    private readonly List<Person> mockPeople = new List<Person> {
        new Person { Id = 1, FirstName = "Hello",  LastName = "World", DepartmentId = 1, DateOfBirth = DateTime.Now.AddYears(-20), Email = "hello@world.com" },
        new Person { Id = 2, FirstName = "Theodore", LastName = "Noodle",  DepartmentId = 2, DateOfBirth = DateTime.Now.AddYears(-3), Email = "fake@email.com" }
    };

    private readonly List<Department> mockDepartments = new List<Department> {
        new Department { Id = 1, Name = "Sales" },
        new Department { Id = 2, Name = "Marketing" },
        new Department { Id = 3, Name = "Finance" },
        new Department { Id = 4, Name = "HR" }
    };

    [Fact]
    public void GetById_ValidId_ReturnsPerson()
    {
        var personId = mockPeople.Last().Id;

        var dbContextMock = Create.MockedDbContextFor<PersonManagerContext>();
        dbContextMock.Set<Department>().AddRange(mockDepartments);
        dbContextMock.Set<Person>().AddRange(mockPeople);
        dbContextMock.SaveChanges();

        var peopleRepository = new PersonRepository<Person>(dbContextMock);

        var result = peopleRepository.GetById(personId);

        Assert.NotNull(result);
        Assert.Equivalent(result, mockPeople.Last());
    }
}
