using System;

namespace _07_Class_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grade[] grades =
                {
                    new Grade(90, "math", 5),
                    new Grade(80, "biology", 3)
                };

            Student ruslan = new Student("Ruslan", "Bayramov", grades);

            ruslan.AddGrades(new Grade(70, "geography", 4));
            ruslan.AddGrades(new Grade(75, "english", 4));

            ruslan.PrintGrades();
            Console.WriteLine($"Average points: {ruslan.GetAvgGrade()}");
            Console.WriteLine($"Count credits: {ruslan.GetCreditCount()}");
        }
    }
}

