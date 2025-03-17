namespace PumpItUp.DAL.Exceptions
{
    public class UserNotFoundException : Exception
    {
        private readonly long _userId;

        public UserNotFoundException(string? message, long userId) : base(message)
        {
            _userId = userId;
        }

        public UserNotFoundException() : base()
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}