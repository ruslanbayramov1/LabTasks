using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services.Abstraction;

interface ILibraryMemberService
{
    Task<LibraryMember> GetLibraryMemberById(int id);
    Task<LibraryMember> GetLibraryMemberByName(string name);
    Task<List<LibraryMember>> GetAllLibraryMember();
    Task CreateLibraryMember(LibraryMember libraryMember);
    Task DeleteLibraryMember(int id);
    Task UpdateLibraryMember(int id, LibraryMember newLibraryMember);
}
