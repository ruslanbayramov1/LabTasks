using LibraryManagementApp.Enums;
using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Concretes;
using Structs;

namespace LibraryManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region BookService

                //Book book1 = new("Atomic Habits", 2017, BookGenre.Art, new LibraryLocation(1, 3));
                //Book book2 = new("Lost", 2015, BookGenre.Fiction, new LibraryLocation(2, 4));
                //Book book3 = new("******", 2016, BookGenre.NonFiction, new LibraryLocation(2, 1));
                //BookService bookService = new BookService();
                //bookService.CreateBook(book1).Wait();
                //bookService.CreateBook(book2).Wait();
                //bookService.CreateBook(book3).Wait();

                //bookService.GetBookByTitle("Lost").Result.DisplayInfo();
                //bookService.GetBookById(1).Result.DisplayInfo();
                //bookService.UpdateBook(3, new Book("Heros", 2016, BookGenre.NonFiction, new LibraryLocation(2, 1))).Wait();
                //bookService.DeleteBook(1).Wait();
                #endregion

                #region LibrarianService

                //Librarian librarian1 = new Librarian("Jack", new DateTime(2024, 10, 15));
                //Librarian librarian2 = new Librarian("Adam", new DateTime(2024, 03, 19));
                //Librarian librarian3 = new Librarian("***", new DateTime(2024, 06, 25));
                //LibrarianService libService = new LibrarianService();
                //libService.CreateLibrarian(librarian1).Wait();
                //libService.CreateLibrarian(librarian2).Wait();
                //libService.CreateLibrarian(librarian3).Wait();

                //libService.GetLibrarianByName("Adam").Result.DisplayInfo();
                //libService.GetLibrarianById(1).Result.DisplayInfo();
                //libService.UpdateLibrarian(3, new Librarian("Tom", new DateTime(2024, 06, 25))).Wait();
                //libService.DeleteLibrarian(1).Wait();
                #endregion

                #region LibraryMemberService

                //LibraryMember libraryMember1 = new LibraryMember("Triss", new DateTime(2024, 10, 15));
                //LibraryMember libraryMember2 = new LibraryMember("*******", new DateTime(2024, 03, 19));
                //LibraryMember libraryMember3 = new LibraryMember("Henry", new DateTime(2024, 06, 25));
                //LibraryMemberService libraryMemberService = new LibraryMemberService();

                //libraryMemberService.CreateLibraryMember(libraryMember1).Wait();
                //libraryMemberService.CreateLibraryMember(libraryMember2).Wait();
                //libraryMemberService.CreateLibraryMember(libraryMember3).Wait();

                //libraryMemberService.GetLibraryMemberByName("Henry").Result.DisplayInfo();
                //libraryMemberService.GetLibraryMemberById(1).Result.DisplayInfo();
                //libraryMemberService.UpdateLibraryMember(2, new LibraryMember("Jennefer", new DateTime(2024, 06, 25))).Wait();
                //libraryMemberService.DeleteLibraryMember(1).Wait();
                #endregion
            }
            catch (Exception ex) when (ex is CustomLibraryItemException || ex is CustomLibrarianException || ex is CustomLibraryMemberException)
            {
                Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
