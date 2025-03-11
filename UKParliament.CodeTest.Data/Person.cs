namespace UKParliament.CodeTest.Data;

public class Person
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required DateTime DateOfBirth { get; set; }

    public required Department Department { get; set; }
}