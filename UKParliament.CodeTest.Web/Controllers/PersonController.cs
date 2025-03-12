using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public PersonController(IPersonService personService, IMapper mapper) {
        _personService = personService;
        _mapper = mapper;
    }

    [Route("{id:int}")]
    [HttpGet]
    public ActionResult<PersonViewModel> GetById(int id)
    {
        var person = _personService.GetPerson(id);

        if (person == null)
            return NotFound();
        
        var personView = _mapper.Map<PersonViewModel>(person);

        return Ok(personView);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonViewModel>> GetPeople()
    {
        var people = _personService.GetPeople();

        var personView = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(people);

        return Ok(personView);
    }

    [HttpPost]
    public ActionResult AddPerson(PersonViewModel person) {
        var personToAdd = _mapper.Map<Person>(person);

        _personService.AddPerson(personToAdd);
        
        return NoContent();
    }

    [Route("{id:int}")]
    [HttpPut]
    public ActionResult UpdatePerson(int id, PersonViewModel person) {
        var personToUpdate = _mapper.Map<Person>(person);
        personToUpdate.Id = id;

        _personService.UpdatePerson(personToUpdate);

        return NoContent();
    }
}
