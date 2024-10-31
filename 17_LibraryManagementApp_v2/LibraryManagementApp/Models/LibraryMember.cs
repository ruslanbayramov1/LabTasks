namespace LibraryManagementApp.Models;

public sealed class LibraryMember : Person
{
    public DateTime MembershipDate { get; set; }

    public LibraryMember(string name) : base(name)
    {

    }

    public LibraryMember(string name, DateTime membershipDate) : base(name)
    {
        MembershipDate = membershipDate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{{ Id: {Id}, Name: {Name}, Membership date: {MembershipDate} }}");
    }
}
