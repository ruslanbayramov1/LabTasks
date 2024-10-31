using LibraryManagementApp.Enums;
using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Extensions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Concretes;
using Structs;

namespace LibraryManagementApp;

class Program
{ 
    public static void Main(string[] args)
    {
        try
        {
            #region BookService

            //Book book1 = new Book("Athomic Habits", 2017, BookGenre.Fiction, new LibraryLocation(1, 2));
            //Book book2 = new Book("Body Language", 2015, BookGenre.Science, new LibraryLocation(1, 3));
            //Book book3 = new Book("Losts", 2019, BookGenre.NonFiction, new LibraryLocation(1, 5));
            //BookService bookService = new BookService();

            //bookService.CreateBook(book1, book2, book3);
            //bookService.GetAllBook().DisplayAllBook();

            //Console.WriteLine("---------------");
            //bookService.GetBookById(2).DisplayInfo();
            //bookService.GetBookByTitle("Losts").DisplayInfo();

            //Console.WriteLine("---------------");
            //bookService.DeleteBook(2);
            //bookService.UpdateBook(1, new Book("Athomic Habits", 2015, BookGenre.Fiction, new LibraryLocation(1, 1)));
            //bookService.GetAllBook().DisplayAllBook();
            #endregion

            #region LibrarianService

            //Librarian librarian1 = new Librarian("Jack", new DateTime(2024, 10, 15));
            //Librarian librarian2 = new Librarian("Adam", new DateTime(2024, 03, 19));
            //Librarian librarian3 = new Librarian("Tom", new DateTime(2024, 06, 25));
            //LibrarianService libService = new LibrarianService();

            //libService.CreateLibrarian(librarian1, librarian2, librarian3);
            //libService.Librarians.DisplayAllLibrarian();

            //Console.WriteLine("---------------");
            //libService.GetLibrarianById(3).DisplayInfo();
            //libService.GetLibrarianByName("Adam").DisplayInfo();

            //Console.WriteLine("---------------");
            //libService.DeleteLibrarian(1);
            //libService.UpdateLibrarian(3, new Librarian("Tom", new DateTime(2024, 06, 27)));
            //libService.Librarians.DisplayAllLibrarian();
            #endregion

            #region LibraryMemberService

            //LibraryMember libraryMember1 = new LibraryMember("Jack", new DateTime(2024, 10, 15));
            //LibraryMember libraryMember2 = new LibraryMember("Adam", new DateTime(2024, 03, 19));
            //LibraryMember libraryMember3 = new LibraryMember("Tom", new DateTime(2024, 06, 25));
            //LibraryMemberService libraryMemberService = new LibraryMemberService();

            //libraryMemberService.CreateLibraryMember(libraryMember1, libraryMember2, libraryMember3);
            //libraryMemberService.Members.DisplayAllMember();

            //Console.WriteLine("---------------");
            //libraryMemberService.GetLibraryMemberById(3).DisplayInfo();
            //libraryMemberService.GetLibraryMemberByName("Adam").DisplayInfo();

            //Console.WriteLine("---------------");
            //libraryMemberService.DeleteLibraryMember(1);
            //libraryMemberService.UpdateLibraryMember(3, new LibraryMember("Tom", new DateTime(2024, 06, 27)));
            //libraryMemberService.Members.DisplayAllMember();
            #endregion

        }
        catch (Exception ex) when (ex is CustomLibrarianException || ex is CustomLibraryItemException || ex is CustomLibraryMemberException)
        {
            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Operations finished!");
        }
    }
}
