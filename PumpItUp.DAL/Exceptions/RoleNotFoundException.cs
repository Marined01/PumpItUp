namespace PumpItUp.DAL.Exceptions
{
    public class RoleNotFoundException : Exception
    {
        private readonly long _roleId;

        public RoleNotFoundException(string? message, long roleId) : base(message)
        {
            _roleId = roleId;
        }

        public RoleNotFoundException() : base()
        {
        }

        public RoleNotFoundException(string? message) : base(message)
        {
        }

        public RoleNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public long RoleId => _roleId;
    }
}