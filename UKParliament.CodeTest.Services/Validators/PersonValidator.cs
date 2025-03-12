using FluentValidation;
using UKParliament.CodeTest.Data;

public class PersonValidator : AbstractValidator<Person>
{
  public PersonValidator()
  {
      RuleFor(person => person.FirstName)
        .NotEmpty()
          .WithMessage("First Name is required.");
      RuleFor(person => person.LastName)
        .NotEmpty()
          .WithMessage("Last Name is required.");
      RuleFor(person => person.DateOfBirth)
        .NotEmpty()
          .WithMessage("Date of Birth is required.")
        .LessThanOrEqualTo(DateTime.Now)
          .WithMessage("You cannot use future dates for Date of Birth.");
      RuleFor(person => person.Email)
        .NotEmpty()
          .WithMessage("Email address is required.")
        .EmailAddress()
          .WithMessage("A valid email address is required.");
      RuleFor(person => person.DepartmentId)
        .NotEmpty()
          .WithMessage("Department is required.");
  }
}
