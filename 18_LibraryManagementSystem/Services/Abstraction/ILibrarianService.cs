using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services.Abstraction;

interface ILibrarianService
{
    Task<Librarian> GetLibrarianById(int id);
    Task<Librarian> GetLibrarianByName(string name);
    Task<List<Librarian>> GetAllLibrarian();
    Task CreateLibrarian(Librarian librarian);
    Task DeleteLibrarian(int id);
    Task UpdateLibrarian(int id, Librarian newLibrarian);
}
