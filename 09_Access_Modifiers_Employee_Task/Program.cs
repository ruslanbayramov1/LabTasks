using Models;

namespace _09_Access_Modifiers_Employee_Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee ruslan = new Employee("Ruslan", true, 4500);
            ruslan.PrintEmployeeInfo();

            Assistant assistant = new Assistant();
            assistant.GetFeedBack(ruslan);

            ruslan.PrintEmployeeInfo();
        }
    }
}
