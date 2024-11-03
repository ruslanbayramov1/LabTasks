using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Abstraction;
using LibraryManagementApp.Utils;

namespace LibraryManagementApp.Services.Concretes;

class LibraryMemberService : ILibraryMemberService
{
    private string path = @"C:\AB108\lab-tasks\18_LibraryManagementSystem\Data\library_members.json";
    public async Task CreateLibraryMember(LibraryMember libraryMember)
    {
        List<LibraryMember> libraryMembers = await FileHelper.ReadFileAsync<LibraryMember>(path);
        libraryMembers.Add(libraryMember);

        await FileHelper.WriteFileAsync(path, libraryMembers);
    }

    public async Task DeleteLibraryMember(int id)
    {
        List<LibraryMember> libraryMembers = await FileHelper.ReadFileAsync<LibraryMember>(path);
        LibraryMember? libraryMember = libraryMembers.Find(libraryMember => libraryMember.Id == id);

        if (libraryMember == null)
            throw new CustomLibraryItemException($"There is no library member with id {id}");

        libraryMembers.Remove(libraryMember);
        await FileHelper.WriteFileAsync(path, libraryMembers);
    }

    public async Task<List<LibraryMember>> GetAllLibraryMember()
    {
        List<LibraryMember> libraryMembers = await FileHelper.ReadFileAsync<LibraryMember>(path);

        return libraryMembers;
    }

    public async Task<LibraryMember> GetLibraryMemberById(int id)
    {
        List<LibraryMember> libraryMembers = await FileHelper.ReadFileAsync<LibraryMember>(path);
        LibraryMember? libraryMember = libraryMembers.Find(libraryMember => libraryMember.Id == id);

        if (libraryMember == null)
            throw new CustomLibraryItemException($"There is no library member with id {id}");

        return libraryMember;
    }

    public async Task<LibraryMember> GetLibraryMemberByName(string name)
    {
        List<LibraryMember> libraryMembers = await FileHelper.ReadFileAsync<LibraryMember>(path);
        LibraryMember? libraryMember = libraryMembers.Find(libraryMember => libraryMember.Name == name);

        if (libraryMember == null)
            throw new CustomLibraryItemException($"There is no library member with name {name}");

        return libraryMember;
    }

    public async Task UpdateLibraryMember(int id, LibraryMember newLibraryMember)
    {
        List<LibraryMember> libraryMembers = await FileHelper.ReadFileAsync<LibraryMember>(path);
        LibraryMember? libraryMember = libraryMembers.Find(libraryMember => libraryMember.Id == id);

        if (libraryMember == null)
            throw new CustomLibraryItemException($"There is no library member with id {id}");

        int index = libraryMembers.IndexOf(libraryMember);
        newLibraryMember.Id = libraryMember.Id;
        libraryMembers[index] = newLibraryMember;

        await FileHelper.WriteFileAsync(path, libraryMembers);
    }

    public LibraryMemberService()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            Console.WriteLine("File created at " + Path.GetFullPath(path));
        }
    }
}
