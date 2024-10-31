using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Abstraction;

namespace LibraryManagementApp.Services.Concretes;

class LibraryMemberService : ILibraryMemberService
{
    public List<LibraryMember> Members { get; set; } = new();
    public void CreateLibraryMember(LibraryMember libraryMember)
    {
        Members.Add(libraryMember);
    }

    public void CreateLibraryMember(params LibraryMember[] libraryMembers)
    {
        foreach (LibraryMember libraryMember in libraryMembers)
            Members.Add(libraryMember);
    }

    public void DeleteLibraryMember(int id)
    {
        LibraryMember libraryMember = GetLibraryMemberById(id);
        Members.Remove(libraryMember);
    }

    public List<LibraryMember> GetAllLibraryMember()
    {
        return Members;
    }

    public LibraryMember GetLibraryMemberById(int id)
    {
        LibraryMember? libraryMember = Members.Find(x => x.Id == id);

        if (libraryMember == null)
            throw new CustomLibraryMemberException($"There is no member with id {id} !");

        return libraryMember;
    }

    public LibraryMember GetLibraryMemberByName(string name)
    {
        LibraryMember? libraryMember = Members.Find(x => x.Name == name);

        if (libraryMember == null)
            throw new CustomLibraryMemberException($"There is no member with name {name} !");

        return libraryMember;
    }

    public void UpdateLibraryMember(int id, LibraryMember newLibraryMember)
    {
        LibraryMember libraryMember = GetLibraryMemberById(id);
        int index = Members.IndexOf(libraryMember);
        newLibraryMember.Id = libraryMember.Id;
        Members[index] = newLibraryMember;
    }
}
