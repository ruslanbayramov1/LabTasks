namespace LibraryManagementApp.Models;

public abstract class Person
{
    private static int _id;
    public int Id { get; set; }
    public string Name { get; set; }

    protected Person() { }

    protected Person(string name)
    {
        Id = ++_id;
        Name = name;
    }

    public abstract void DisplayInfo(); 
}
