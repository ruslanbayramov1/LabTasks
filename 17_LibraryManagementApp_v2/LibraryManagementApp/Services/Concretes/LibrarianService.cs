using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Abstraction;

namespace LibraryManagementApp.Services.Concretes;

class LibrarianService : ILibrarianService
{
    public List<Librarian> Librarians { get; } = new();

    public void CreateLibrarian(Librarian librarian)
    {
        Librarians.Add(librarian);
    }

    public void CreateLibrarian(params Librarian[] librarians)
    {
        foreach (Librarian librarian in librarians)
            Librarians.Add(librarian);
    }

    public Librarian GetLibrarianById(int id)
    {
        Librarian? librarian = Librarians.Find(librarian => librarian.Id == id);

        if (librarian == null)
            throw new CustomLibrarianException($"There is no librarian with id {id} !");

        return librarian;
    }

    public List<Librarian> GetAllLibrarian()
    {
        return Librarians;
    }

    public Librarian GetLibrarianByName(string name)
    {
        Librarian? librarian = Librarians.Find(librarian => librarian.Name == name);

        if (librarian == null)
            throw new CustomLibrarianException($"There is no librarian with name {name} !");

        return librarian;
    }

    public void DeleteLibrarian(int id)
    {
        Librarian librarian = GetLibrarianById(id);
        Librarians.Remove(librarian);
    }

    public void UpdateLibrarian(int id, Librarian newLibrarian)
    {
        Librarian librarian = GetLibrarianById(id);
        int index = Librarians.IndexOf(librarian);
        newLibrarian.Id = librarian.Id;
        Librarians[index] = newLibrarian;
    }
}
