using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Abstraction;
using LibraryManagementApp.Utils;

namespace LibraryManagementApp.Services.Concretes;

class LibrarianService : ILibrarianService
{
    private string path = @"C:\AB108\lab-tasks\18_LibraryManagementSystem\Data\librarians.json";

    public async Task CreateLibrarian(Librarian librarian)
    {
        List<Librarian> librarians = await FileHelper.ReadFileAsync<Librarian>(path);
        librarians.Add(librarian);

        await FileHelper.WriteFileAsync(path, librarians);
    }

    public async Task<Librarian> GetLibrarianById(int id)
    {
        List<Librarian> librarians = await FileHelper.ReadFileAsync<Librarian>(path);
        Librarian? librarian = librarians.Find(librarian => librarian.Id == id);

        if (librarian == null)
            throw new CustomLibraryItemException($"There is no librarian with id {id}");

        return librarian;
    }

    public async Task<List<Librarian>> GetAllLibrarian()
    {
        List<Librarian> librarians = await FileHelper.ReadFileAsync<Librarian>(path);

        return librarians;
    }

    public async Task<Librarian> GetLibrarianByName(string name)
    {
        List<Librarian> librarians = await FileHelper.ReadFileAsync<Librarian>(path);

        Librarian? librarian = librarians.Find(librarian => librarian.Name == name);

        if (librarian == null)
            throw new CustomLibraryItemException($"There is no librarian with name {name}");

        return librarian;
    }

    public async Task DeleteLibrarian(int id)
    {
        List<Librarian> librarians = await FileHelper.ReadFileAsync<Librarian>(path);
        Librarian? librarian = librarians.Find(librarian => librarian.Id == id);
        if (librarian == null)
            throw new CustomLibraryItemException($"There is no librarian with id {id}");

        librarians.Remove(librarian);
        await FileHelper.WriteFileAsync(path, librarians);
    }

    public async Task UpdateLibrarian(int id, Librarian newLibrarian)
    {
        List<Librarian> librarians = await FileHelper.ReadFileAsync<Librarian>(path);
        Librarian? librarian = librarians.Find(librarian => librarian.Id == id);
        if (librarian == null)
            throw new CustomLibraryItemException($"There is no librarian with id {id}");

        int index = librarians.IndexOf(librarian);
        newLibrarian.Id = librarian.Id;
        librarians[index] = newLibrarian;

        await FileHelper.WriteFileAsync(path, librarians);
    }

    public LibrarianService()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            Console.WriteLine("File created at " + Path.GetFullPath(path));
        }
    }
}
