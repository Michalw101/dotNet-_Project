namespace BO
{
    /// <summary>
    /// Represents an exception thrown when a Business Logic entity does not exist.
    /// </summary>
    [Serializable]
    public class BlDoesNotExistException : Exception
    {
        public BlDoesNotExistException(string? message) : base(message) { }
        public BlDoesNotExistException(string message, Exception innerException)
                    : base(message, innerException) { }
    }

    /// <summary>
    /// Represents an exception thrown when a Business Logic entity already exists.
    /// </summary>
    [Serializable]
    public class BlAlreadyExistsException : Exception
    {
        public BlAlreadyExistsException(string? message) : base(message) { }
        public BlAlreadyExistsException(string message, Exception innerException)
                    : base(message, innerException) { }
    }

    /// <summary>
    /// Represents an exception thrown when a Business Logic entity has a null property.
    /// </summary>
    [Serializable]
    public class BlNullPropertyException : Exception
    {
        public BlNullPropertyException(string? message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when a Business Logic entity is invalid.
    /// </summary>
    [Serializable]
    public class BlUnvalidException : Exception
    {
        public BlUnvalidException(string? message) : base(message) { }
    }

    /// <summary>
    /// Represents an exception thrown when deletion of a Business Logic entity is impossible.
    /// </summary>
    [Serializable]
    public class BlDeletionImpossibleException : Exception
    {
        public BlDeletionImpossibleException(string? message) : base(message) { }
        public BlDeletionImpossibleException(string? message, Exception innerException)
                    : base(message, innerException) { }
    }
}
