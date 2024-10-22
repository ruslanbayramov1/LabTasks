namespace _13_Static_Abstract_IdAutoIncrement;

internal class Program
{
    static void Main(string[] args)
    {
        Employee ruslan = new HourlyEmployee("Ruslan", "Bayramov", 19, 40, 85);
        Employee jack = new SalariedEmployee("Jack", "Robinson", 25, 6750);

        ruslan.DisplayDetails();
        Console.WriteLine();
        jack.DisplayDetails();
    }
}
