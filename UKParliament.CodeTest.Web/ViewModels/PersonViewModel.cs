using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Web.ViewModels;

public class PersonViewModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int DepartmentId { get; set; }
    public required Department Department { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
}