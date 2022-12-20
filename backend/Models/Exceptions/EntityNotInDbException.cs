using System;

namespace Bookish.Exceptions
{
    [Serializable]
    public class EntityNotInDbException : Exception
    {
        public EntityNotInDbException()
        { }

        public EntityNotInDbException(string message)
            : base(message)
        { }

        public EntityNotInDbException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
