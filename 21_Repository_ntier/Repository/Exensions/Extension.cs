using Repository.Models;
using System.Data;
using System.Text;

namespace Repository.Exensions;

static class Extension
{
    public static void PrintRows(this List<Student> students)
    {
        foreach (Student st in students)
        {
            Console.WriteLine(st.FirstName);
        }
    }
}
