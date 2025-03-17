namespace PumpItUp.DAL.Exceptions
{
    public class AttachmentNotFoundException : Exception
    {
        private readonly long _attachmentId;

        public AttachmentNotFoundException(string? message, long attachmentId) : base(message)
        {
            _attachmentId = attachmentId;
        }

        public AttachmentNotFoundException() : base()
        {
        }

        public AttachmentNotFoundException(string? message) : base(message)
        {
        }

        public AttachmentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}