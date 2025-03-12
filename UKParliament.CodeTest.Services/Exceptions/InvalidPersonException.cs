namespace UKParliament.CodeTest.Services.Exceptions;

public class InvalidPersonException: Exception
{
    public List<string> Errors { get; private set; }

    public InvalidPersonException(List<string> errors)
    {
        Errors = errors;
    }
}
