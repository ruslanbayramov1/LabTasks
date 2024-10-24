namespace _14_Student_Task;

internal interface IStudentService
{
    Student GetStudentById(int id);
    Student[] GetAllStudents();
    Student[] GetStudentsByName(string name);
    void AddStudent(Student student);
    void UpdateStudent(int id, Student student);
    void RemoveStudent(int id, bool isSoftDelete);
}
