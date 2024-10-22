namespace _13_Static_Abstract_IdAutoIncrement;

internal abstract class Employee
{
    private static int _uniqueId;
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public abstract double CalculateSalary();
    public abstract void DisplayDetails();

    protected Employee(string name, string surname, int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
        _uniqueId += 1173;
        Id = _uniqueId;
    }
}

internal class HourlyEmployee : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public override double CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Id: {Id}\nName: {Name}\nSurname: {Surname}\nAge: {Age}\nHourlyRate: {HourlyRate}\nHoursWorked: {HoursWorked}\nSalary: {CalculateSalary()}");
    }

    public HourlyEmployee(string name, string surname, int age, double hourlyRate, double hoursWorked) : base(name, surname, age)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }
}

internal class SalariedEmployee : Employee
{
    public double MonthlySalary { get; set; }
    public override double CalculateSalary()
    {
        return 4.3;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Id: {Id}\nName: {Name}\nSurname: {Surname}\nAge: {Age}\nMonthlySalary: {MonthlySalary}");
    }

    public SalariedEmployee(string name, string surname, int age, double monthlySalary) : base(name, surname, age)
    {
        MonthlySalary = monthlySalary;
    }
}
