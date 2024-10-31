using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services.Abstraction;

interface ILibraryMemberService
{
    LibraryMember GetLibraryMemberById(int id);
    LibraryMember GetLibraryMemberByName(string name);
    List<LibraryMember> GetAllLibraryMember();
    void CreateLibraryMember(LibraryMember libraryMember);
    void DeleteLibraryMember(int id);
    void UpdateLibraryMember(int id, LibraryMember newLibraryMember);
}
