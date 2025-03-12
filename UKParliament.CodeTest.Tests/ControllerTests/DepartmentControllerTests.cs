using Xunit;
using UKParliament.CodeTest.Data;
using Moq;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UKParliament.CodeTest.Tests.ControllerTests;

public class DepartmentControllerTests
{
     private readonly List<Department> mockDepartments = new List<Department> {
        new Department { Id = 1, Name = "Sales" },
        new Department { Id = 2, Name = "Marketing" },
        new Department { Id = 3, Name = "Finance" },
        new Department { Id = 4, Name = "HR" }
    };

    [Fact]
    public void GetDepartments_ReturnsListOfDepartments() {
        var mockDepartmentService = new Mock<IDepartmentService>();
        mockDepartmentService.Setup(d => d.GetDepartments()).Returns(mockDepartments);

        var controller = new DepartmentController(mockDepartmentService.Object);

        var result = controller.GetDepartments();
        var okResult = result.Result as OkObjectResult;

        mockDepartmentService.Verify(r => r.GetDepartments(), Times.Once);

        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
    }
}
