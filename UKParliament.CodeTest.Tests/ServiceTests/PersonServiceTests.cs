using Xunit;
using UKParliament.CodeTest.Services;
using Moq;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services.Validators;

namespace UKParliament.CodeTest.Tests.Services;

public class PersonServiceTests
{
    private readonly List<Person> testPeople = new List<Person> {
        new Person { Id = 1, FirstName = "Hello",  LastName = "World", DepartmentId = 1, DateOfBirth = DateTime.Now.AddYears(-20), Email = "hello@world.com" },
        new Person { Id = 2, FirstName = "Theodore", LastName = "Noodle",  DepartmentId = 2, DateOfBirth = DateTime.Now.AddYears(-3), Email = "fake@email.com" }
    };

    [Fact]
    public void GetPerson_PersonExists_ReturnsPerson()
    {
        var personId = 2;

        var mockRepository = new Mock<IRepository<Person>>();
        mockRepository.Setup(r => r.GetById(personId))
            .Returns(testPeople.Find(p => p.Id == personId));

        var personService = new PersonService(mockRepository.Object, new PersonValidator());
        var result = personService.GetPerson(personId);

        mockRepository.Verify(r => r.GetById(personId), Times.Once);

        Assert.Equal(result?.Id, personId);
        Assert.Equivalent(result, testPeople.Find(p => p.Id == personId));
    }

    [Fact]
    public void GetPerson_PersonDoesNotExist_ReturnsNull()
    {
        var personId = -1;

        var mockRepository = new Mock<IRepository<Person>>();
        mockRepository.Setup(r => r.GetById(personId))
            .Returns(testPeople.Find(p => p.Id == personId));

        var personService = new PersonService(mockRepository.Object, new PersonValidator());
        var result = personService.GetPerson(personId);

        mockRepository.Verify(r => r.GetById(personId), Times.Once);

        Assert.Null(result);
    }
}
