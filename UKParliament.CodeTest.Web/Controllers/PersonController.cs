using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService) {
        _personService = personService;
    }

    [Route("{id:int}")]
    [HttpGet]
    public ActionResult<PersonViewModel> GetById(int id)
    {
        var person = _personService.GetPerson(id);
        return Ok(person);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonViewModel>> GetPeople()
    {
        var people = _personService.GetPeople();
        return Ok(people);
    }

    [HttpPost]
    public ActionResult AddPerson() {
        return NoContent();
    }

    [Route("{id:int}")]
    [HttpPut]
    public ActionResult UpdatePerson(int id) {
        return NoContent();
    }
}