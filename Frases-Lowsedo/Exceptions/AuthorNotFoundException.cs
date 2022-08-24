using System.Runtime.Serialization;

namespace Frases_Lowsedo.Exceptions
{
    [Serializable]
    internal class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException()
        {
        }

        public AuthorNotFoundException(string? message) : base(message)
        {
        }

        public AuthorNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AuthorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}