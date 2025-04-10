namespace PumpItUp.DAL.Exceptions;

public class EmailAlreadyExists : Exception
{
    public EmailAlreadyExists(string? message) : base(message)
    {
    }

    public EmailAlreadyExists(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public EmailAlreadyExists() : base()
    {
    }
}