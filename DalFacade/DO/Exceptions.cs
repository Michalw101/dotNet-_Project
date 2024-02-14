namespace DO;

/// <summary>
/// Represents an exception thrown when attempting to access a non-existent entity in the data access layer.
/// </summary>
[Serializable]
public class DalDoesNotExistException : Exception //class for exeptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DalDoesNotExistException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public DalDoesNotExistException(string? message) : base(message) { }
}

/// <summary>
/// Represents an exception thrown when attempting to create an entity that already exists in the data access layer.
/// </summary>
public class DalAlreadyExistsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DalAlreadyExistsException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public DalAlreadyExistsException(string? message) : base(message) { }
}

/// <summary>
/// Represents an exception thrown when attempting to delete an entity that cannot be deleted due to dependencies.
/// </summary>
public class DalDeletionImpossibleException : Exception
{

    /// <summary>
    /// Initializes a new instance of the <see cref="DalDeletionImpossibleException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public DalDeletionImpossibleException(string? message) : base(message) { }
}

/// <summary>
/// Represents an exception thrown when there is an issue with loading or creating a Dal XML file.
/// </summary>

public class DalXMLFileLoadCreateException : Exception
{

    /// <summary>
    /// Initializes a new instance of the <see cref="DalXMLFileLoadCreateException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>

    public DalXMLFileLoadCreateException(string? message) : base(message) { }
}
