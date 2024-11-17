using Repository.Models;

namespace Repository.Repositories.Absctractions;

public interface IStudentRepository
{
    List<Student> GetAllStudents();
    Student GetById(int id);
    int Add(Student student);
    int Delete(int id);
    int Update(int id, Student student);
}
