namespace _14_Student_Task;

internal class Program
{
    static void Main(string[] args)
    {
        StudentService firstService = new();
        Student henry = new("Henry", "Jefferson", "henryjeff@gmail.com", "+1 023492", 3.8, "Computer Engineering");
        Student ashe = new("Ashe", "Breton", "asheton@gmail.com", "+1 082345", 3.2, "Computer Science");
        Student ashe2 = new("Ashe", "Hoodson", "asheson@gmail.com", "+1 034753", 3.0, "IT");

        firstService.AddStudent(henry);
        firstService.AddStudent(ashe);
        firstService.AddStudent(ashe2);
        firstService.UpdateStudent(1, new Student(henry.FirstName, henry.LastName, "henryy@gmail.com", henry.PhoneNumber, henry.GPA, henry.Major));

        Student studentById = firstService.GetStudentById(1);
        Console.WriteLine(studentById);
        Console.WriteLine("---------------------");

        Student[] allStudentsWithName = firstService.GetStudentsByName("ashe");
        foreach (Student student in allStudentsWithName)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine("---------------------");

        firstService.RemoveStudent(3, false);
        Console.WriteLine("---------------------");

        Student[] allStudents = firstService.GetAllStudents();
        foreach (Student student in allStudents)
        {
            Console.WriteLine(student);
        }
    }
}
