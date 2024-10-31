using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services.Abstraction;

interface ILibrarianService
{
    Librarian GetLibrarianById(int id);
    Librarian GetLibrarianByName(string name);
    List<Librarian> GetAllLibrarian();
    void CreateLibrarian(Librarian librarian);
    void DeleteLibrarian(int id);
    void UpdateLibrarian(int id, Librarian newLibrarian);
}
