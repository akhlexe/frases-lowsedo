using System.Runtime.Serialization;

namespace Frases_Lowsedo.Exceptions
{
    [Serializable]
    internal class QuoteNotFoundException : Exception
    {
        public QuoteNotFoundException()
        {
        }

        public QuoteNotFoundException(string? message) : base(message)
        {
        }

        public QuoteNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected QuoteNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}