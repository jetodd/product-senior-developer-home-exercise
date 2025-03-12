using Xunit;
using UKParliament.CodeTest.Data;
using EntityFrameworkCore.Testing.Moq;

namespace UKParliament.CodeTest.Tests.RespositoryTests;

public class DepartmentRepositoryTests
{
    private readonly List<Department> mockDepartments = new List<Department> {
        new Department { Id = 1, Name = "Sales" },
        new Department { Id = 2, Name = "Marketing" },
        new Department { Id = 3, Name = "Finance" },
        new Department { Id = 4, Name = "HR" }
    };

    [Fact]
    public void GetAll_ReturnsList_OfDepartments()
    {
        var dbContextMock = Create.MockedDbContextFor<PersonManagerContext>();
        dbContextMock.Set<Department>().AddRange(mockDepartments);
        dbContextMock.SaveChanges();

        var departmentRepository = new DepartmentRepository<Department>(dbContextMock);

        var result = departmentRepository.GetAll();

        Assert.NotEmpty(result);
        Assert.Equal(result.Count(), mockDepartments.Count);
        Assert.Equivalent(result, mockDepartments);
    }
}
