using FluentValidation;
using UKParliament.CodeTest.Data;

public class PersonValidator : AbstractValidator<Person>
{
  public PersonValidator()
  {
    RuleFor(person => person.FirstName).NotNull();
    RuleFor(person => person.LastName).NotNull();
    RuleFor(person => person.DateOfBirth).NotNull();
    RuleFor(person => person.Email).NotNull();
    RuleFor(person => person.Department).NotNull();
  }
}
