namespace ToDoList.Shared.Domain.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }

    public static void When(object? data, string errorMessage)
    {
        if (data is null)
            throw new NotFoundException(errorMessage);
    }
}
