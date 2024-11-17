using Repository.Helpers;
using Repository.Models;
using Repository.Repositories.Absctractions;
using System.Data;

namespace Repository.Repositories.Implements;

public class StudentRepository : IStudentRepository
{
    public int Add(Student student)
    {
        return SqlHelper.Exec(
            $"INSERT INTO Students(FirstName, LastName, DateOfBirth, Username, Password, EnrollmentDate) VALUES " +
            $"('{student.FirstName}', '{student.LastName}', '{student.DateOfBirth}', '{student.Username}', '{student.Password}', '{student.EnrollmentDate}')"
            ).Result;
    }

    public int Delete(int id)
    {
        return SqlHelper.Exec($"DELETE FROM Students WHERE Id = {id}").Result;
    }

    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();
        DataTable dt = SqlHelper.Read("SELECT * FROM Students").Result;

        if (dt.Rows.Count >= 1)
        {
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString()!,
                    LastName = dr["LastName"].ToString()!,
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Username = dr["UserName"].ToString()!,
                    Password = dr["Password"].ToString()!,
                    EnrollmentDate = Convert.ToDateTime(dr["EnrollmentDate"])
                });
            }
        }

        return students;
    }

    public Student GetById(int id)
    {
        DataTable dt = SqlHelper.Read($"SELECT * FROM Students WHERE Id = {id}").Result;
        Student st = new Student();
        if (dt.Rows.Count == 1)
        {
            foreach (DataRow dr in dt.Rows)
            {
                st = new Student()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString()!,
                    LastName = dr["LastName"].ToString()!,
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Username = dr["Username"].ToString()!,
                    Password = dr["Password"].ToString()!,
                    EnrollmentDate = Convert.ToDateTime(dr["EnrollmentDate"])
                };
            }
        }

        return st;
    }

    public int Update(int id, Student student)
    {
        return SqlHelper.Exec(
            $"UPDATE Students SET FirstName = '{student.FirstName}' SET LastName = '{student.LastName}' SET DateOfBirth = '{student.DateOfBirth}' SET Username = '{student.Username}' SET Password = '{student.Password}' SET EnrollmentDate = '{student.EnrollmentDate}' WHERE Id = {id}"
            ).Result;
    }
}
