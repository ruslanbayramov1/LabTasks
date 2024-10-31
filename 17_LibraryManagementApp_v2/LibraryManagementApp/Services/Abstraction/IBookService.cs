using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services.Abstraction;

interface IBookService
{
    Book GetBookById(int id);
    Book GetBookByTitle(string title);
    List<Book> GetAllBook();
    void CreateBook(Book book);
    void DeleteBook(int id);
    void UpdateBook(int id, Book newBook);
}

