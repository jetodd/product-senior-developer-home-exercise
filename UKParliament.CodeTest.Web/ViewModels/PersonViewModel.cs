namespace UKParliament.CodeTest.Web.ViewModels;

public class PersonViewModel
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int DepartmentId { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
}
