namespace LibraryManagementApp.Models;

public abstract class LibraryItem
{
    private static int _counter;
    public int Id { get; set; }
    public string Title { get; set; }
    public int? PublicationYear { get; set; }
    protected LibraryItem(string title, int? publicationYear)
    {
        Title = title;
        PublicationYear = publicationYear;
        _counter++;
        Id = _counter;
    }
    public abstract void DisplayInfo();
}
