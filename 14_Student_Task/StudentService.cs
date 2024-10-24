namespace _14_Student_Task;

public enum StudentStatus
{ 
    Active = 1,
    Graduate,
    Pending,
    Removed
}

internal class StudentService : IStudentService
{
    private Student[] _students;
    public Student[] Students { get { return _students; } }

    public StudentService()
    {
        _students = new Student[0];
    }

    public Student GetStudentById(int id)
    {
        for (int i = 0; i < Students.Length; i++)
        {
            if(Students[i].Id == id) 
                return Students[i];
        }

        Console.WriteLine($"No student with id: {id}");
        return null;
    }

    public Student[] GetAllStudents()
    {
        return Students;
    }

    public Student[] GetStudentsByName(string name)
    {
        Student[] matchedStudents = new Student[0];

        for (int i = 0; i < Students.Length; i++)
        {
            if (Students[i].FirstName.ToLower() == name.ToLower())
            { 
                Array.Resize(ref matchedStudents, matchedStudents.Length + 1);
                matchedStudents[matchedStudents.Length - 1] = Students[i];
            }
        }

        return matchedStudents;
    }

    public void AddStudent(Student student)
    {
        student.Status = StudentStatus.Active;
        Array.Resize(ref _students, _students.Length + 1);
        _students[_students.Length - 1] = student;
    }
    
    public void UpdateStudent(int id, Student student)
    { 
        Student studentById = GetStudentById(id);

        if (studentById == null)
            return;

        student.Id = studentById.Id;
        student.Status = StudentStatus.Active;

        int index = Array.IndexOf(_students, studentById);
        _students[index] = student;
    }

    public void RemoveStudent(int id, bool isSoftDelete)
    {
        Student studentById = GetStudentById(id);

        if (studentById == null)
            return;

        int index = Array.IndexOf(_students, studentById);

        if (isSoftDelete)
            _students[index].Status = StudentStatus.Removed;

        Student[] newStudents = new Student[Students.Length - 1];
        if (!isSoftDelete)
        { 
            for (int i = 0; i < Students.Length; i++)
            { 
                if (i < index)
                    newStudents[i] = Students[i];
                else if (i == index)
                    continue;
                else if (i > index)
                    newStudents[i - 1] = Students[i];
            }
            _students = newStudents;
        }
    }
}
