using Xunit;
using UKParliament.CodeTest.Services;
using Moq;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Tests.Services;

public class DepartmentServiceTests
{
    private readonly List<Department> mockDepartments = new List<Department> {
        new Department { Id = 1, Name = "Sales" },
        new Department { Id = 2, Name = "Marketing" },
        new Department { Id = 3, Name = "Finance" },
        new Department { Id = 4, Name = "HR" }
    };

    [Fact]
    public void GetDepartments_ReturnsListOfDepartments()
    {
        var mockRepository = new Mock<IDepartmentRepository<Department>>();
        mockRepository.Setup(r => r.GetAll()).Returns(mockDepartments);

        var departmentService = new DepartmentService(mockRepository.Object);
        var result = departmentService.GetDepartments();

        mockRepository.Verify(r => r.GetAll(), Times.Once);

        Assert.NotEmpty(result);
        Assert.Equivalent(result, mockDepartments);
    }
}
