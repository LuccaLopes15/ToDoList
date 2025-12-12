namespace ToDoList.Mobile.Domain.Common.Exceptions;
public class DomainException : Exception
{
    public DomainException(string message) :base(message) { }

    public static void When(bool condition, string errorMessage)
    {
        if (condition)
            throw new DomainException(errorMessage);
    }
}
