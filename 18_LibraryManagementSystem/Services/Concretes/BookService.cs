using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Utils;

namespace LibraryManagementApp.Services.Concretes;

class BookService
{
    private string path = @"C:\AB108\lab-tasks\18_LibraryManagementSystem\Data\books.json";
    public async Task CreateBook(Book book)
    {
        List<Book> books = await FileHelper.ReadFileAsync<Book>(path);
        books.Add(book);

        await FileHelper.WriteFileAsync(path, books);
    }

    public async Task<Book> GetBookById(int id)
    {
        List<Book> books = await FileHelper.ReadFileAsync<Book>(path);
        Book? book = books.Find(book => book.Id == id);

        if (book == null)
            throw new CustomLibraryItemException($"There is no book with id {id}");

        return book;
    }

    public async Task<List<Book>> GetAllBook()
    {
        List<Book> books = await FileHelper.ReadFileAsync<Book>(path);

        return books;
    }

    public async Task DeleteBook(int id)
    {
        List<Book> books = await FileHelper.ReadFileAsync<Book>(path);
        Book? book = books.Find(book => book.Id == id);
        if (book == null)
            throw new CustomLibraryItemException($"There is no book with id {id}");

        books.Remove(book);
        await FileHelper.WriteFileAsync(path, books);
    }

    public async Task<Book> GetBookByTitle(string title)
    {
        List<Book> books = await FileHelper.ReadFileAsync<Book>(path);
        Book? book = books.Find(book => book.Title == title);

        if (book == null)
            throw new CustomLibraryItemException($"There is no book with title {title}");

        return book;
    }

    public async Task UpdateBook(int id, Book newBook)
    {
        List<Book> books = await FileHelper.ReadFileAsync<Book>(path);
        Book? book = books.Find(book => book.Id == id);
        if (book == null)
            throw new CustomLibraryItemException($"There is no book with id {id}");

        int index = books.IndexOf(book);
        newBook.Id = book.Id;
        books[index] = newBook;

        await FileHelper.WriteFileAsync(path, books);
    }

    public BookService()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            Console.WriteLine("File created at " + Path.GetFullPath(path));
        }
    }
}
