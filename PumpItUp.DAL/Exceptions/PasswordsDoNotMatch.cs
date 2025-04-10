namespace PumpItUp.DAL.Exceptions;

public class PasswordsDoNotMatch : Exception
{
    public PasswordsDoNotMatch(string? message) : base(message)
    {
    }

    public PasswordsDoNotMatch(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public PasswordsDoNotMatch() : base()
    {
    }
}