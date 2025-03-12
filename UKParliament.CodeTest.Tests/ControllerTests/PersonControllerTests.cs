using Xunit;
using Moq;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.Controllers;
using AutoMapper;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace UKParliament.CodeTest.Tests.ControllerTests;

public class PersonControllerTests
{
    private readonly Person mockPerson = new Person { 
        Id = 1, 
        FirstName = "Hello",
        LastName = "World",
        DepartmentId = 1,
        DateOfBirth = DateTime.Now.AddYears(-20),
        Email = "hello@world.com"
    };

     [Fact]
    public void GetPerson_ReturnsOk() {
        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(d => d.GetPerson(mockPerson.Id)).Returns(mockPerson);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<Person, PersonViewModel>(It.IsAny<Person>()))
            .Returns(new PersonViewModel {
                Id = mockPerson.Id,
                FirstName = mockPerson.FirstName,
                LastName = mockPerson.LastName,
                DateOfBirth = mockPerson.DateOfBirth,
                Email = mockPerson.Email,
                DepartmentId = mockPerson.DepartmentId
            });

        var controller = new PersonController(mockPersonService.Object, mockMapper.Object);

        var result = controller.GetById(mockPerson.Id);
        var okResult = result.Result as OkObjectResult;

        mockPersonService.Verify(r => r.GetPerson(mockPerson.Id), Times.Once);

        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
    }
}
