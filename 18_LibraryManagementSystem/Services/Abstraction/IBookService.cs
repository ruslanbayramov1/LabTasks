using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services.Abstraction;

interface IBookService
{
    Task<Book> GetBookById(int id);
    Task<Book> GetBookByTitle(string title);
    Task<List<Book>> GetAllBook();
    Task CreateBook(Book book);
    Task DeleteBook(int id);
    Task UpdateBook(int id, Book newBook);
}

