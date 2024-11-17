using Repository.Exensions;
using Repository.Models;
using Repository.Repositories.Absctractions;
using Repository.Repositories.Implements;

namespace Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository st = new StudentRepository();
            Student student = st.GetById(2);
            Console.WriteLine(student.FirstName);

            Console.ReadLine();
            List<Student> students = st.GetAllStudents();
            students.PrintRows();

            Console.ReadLine();
            int res = st.Add(new Student
            {
                FirstName = "Ilham",
                LastName = "Hesenov",
                DateOfBirth = new DateTime(2000, 10, 11),
                Username = "ilhasanov",
                Password = "ilh12345",
                EnrollmentDate = new DateTime(2024, 06, 08)
            });
            if (res == 1)
            {
                Console.WriteLine("Created Successfully");
            }

            Console.ReadLine();
            int res2 = st.Delete(10);
            if (res2 == 1)
            {
                Console.WriteLine("Deleted Successfully");
            }

            Console.ReadLine();
        }
    }
}
