using LibraryManagementApp.Enums;
using Structs;

namespace LibraryManagementApp.Models;

public class Book : LibraryItem
{
    public BookGenre BookGenre { get; set; }
    public LibraryLocation LibraryLocation { get; set; }

    public Book(string title, int? publicationYear) : base(title, publicationYear)
    {

    }

    public Book(string title, int? publicationYear, BookGenre bookGenre, LibraryLocation libraryLocation) : base(title, publicationYear)
    {
        BookGenre = bookGenre;
        LibraryLocation = libraryLocation;
    }

    public override void DisplayInfo()
    { 
        Console.WriteLine($"{{ Id: {Id}, Title: {Title}, Publication Year: {PublicationYear}, Genre: {BookGenre}, Aisle: {LibraryLocation.Aisle}, Shelf: {LibraryLocation.Shelf} }}");
    }
}
