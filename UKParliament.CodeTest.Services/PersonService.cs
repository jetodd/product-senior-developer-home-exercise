﻿using FluentValidation;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services.Exceptions;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly IRepository<Person> _personRepository;
    private readonly IValidator<Person> _validator;

    public PersonService(IRepository<Person> personRepository, IValidator<Person> validator)
    {
        _personRepository = personRepository;
        _validator = validator;
    }

    public Person? GetPerson(int id) 
    {
        var person = _personRepository.GetById(id);
        return person;
    }

    public IEnumerable<Person> GetPeople()
    {
        return _personRepository.GetAll();
    }

    public void AddPerson(Person person)
    {
        var validationResult = _validator.Validate(person);

        if (validationResult.IsValid) {
            _personRepository.Add(person);
        } else {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new InvalidPersonException(errors);
        }
    }

    public void UpdatePerson(Person person)
    {
        var validationResult = _validator.Validate(person);

        if (validationResult.IsValid) {
            _personRepository.Update(person);
        } else {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new InvalidPersonException(errors);
        }
    }
}
