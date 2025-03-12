using Xunit;
using UKParliament.CodeTest.Data;
using Moq;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UKParliament.CodeTest.Web.ViewModels;

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
    public void GetDepartments_ReturnsOk() {
        var mockDepartmentService = new Mock<IDepartmentService>();
        mockDepartmentService.Setup(d => d.GetDepartments()).Returns(mockDepartments);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<Department, DepartmentViewModel>(It.IsAny<Department>()))
            .Returns(new DepartmentViewModel { Id = 1, Name = "Bob" });

        var controller = new DepartmentController(mockDepartmentService.Object, mockMapper.Object);

        var result = controller.GetDepartments();
        var okResult = result.Result as OkObjectResult;

        mockDepartmentService.Verify(r => r.GetDepartments(), Times.Once);

        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
    }
}
