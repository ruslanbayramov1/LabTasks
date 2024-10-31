using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Abstraction;

namespace LibraryManagementApp.Services.Concretes;

class BookService : IBookService
{
    public List<Book> Books { get; } = new();
    public void CreateBook(Book book)
    {
        Books.Add(book);
    }

    public void CreateBook(params Book[] books)
    {
        foreach (Book book in books)
            Books.Add(book);
    }

    public Book GetBookById(int id)
    {
        Book? book = Books.Find(book => book.Id == id);

        if (book == null)
            throw new CustomLibraryItemException($"There is no book with id {id} !");

        return book;
    }

    public List<Book> GetAllBook()
    {
        return Books;
    }

    public void DeleteBook(int id)
    {
        Book book = GetBookById(id);
        Books.Remove(book);
    }

    public Book GetBookByTitle(string title)
    {
        Book? book = Books.Find(book => book.Title == title);

        if (book == null)
            throw new CustomLibraryItemException($"There is no book with title {title} !");

        return book;
    }

    public void UpdateBook(int id, Book newBook)
    {
        Book book = GetBookById(id);
        int index = Books.IndexOf(book);
        newBook.Id = book.Id;
        Books[index] = newBook;
    }
}
