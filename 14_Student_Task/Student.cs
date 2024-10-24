namespace _14_Student_Task;

internal class Student
{
    private static int _id;
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public double GPA { get; set; }
    public StudentStatus Status { get; set; }
    public string Major { get; set; }

    public Student(string firstName, string lastName, string email, string phoneNumber, double gpa, string major)
    {
        Id = ++_id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        GPA = gpa;
        Status = StudentStatus.Pending;
        Major = major;
    }

    public override string ToString()
    {
        return $"{this.GetType().ToString().Split(".")[^1]} {{ Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, PhoneNumber: {PhoneNumber}, GPA: {GPA}, Status: {Status}, Major: {Major} }}";
    }
}
