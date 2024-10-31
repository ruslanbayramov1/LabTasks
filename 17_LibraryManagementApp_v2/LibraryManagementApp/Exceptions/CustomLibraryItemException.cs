namespace LibraryManagementApp.Exceptions;

public class CustomLibraryItemException : Exception
{
    public CustomLibraryItemException()
    {
    }

    public CustomLibraryItemException(string message) : base(message)
    {

    }
}