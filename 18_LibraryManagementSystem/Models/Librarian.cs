namespace LibraryManagementApp.Models;

public class Librarian : Person
{
    public DateTime HireDate { get; set; }

    public Librarian() { }

    public Librarian(string name) : base(name)
    {
    }

    public Librarian(string name, DateTime hireDate) : base(name)
    {
        HireDate = hireDate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{{ Id: {Id}, Name: {Name}, Hire date: {HireDate} }}");
    }
}
