using _10_Data_Relations_Project.Models;

namespace _10_Data_Relations_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Data Relation model!\nPress enter to start!");
            Console.ReadLine();

            Console.WriteLine("0 - Create project\n1 - Create employee\n2 - All projects\n3 - All employees");
            Console.WriteLine("4 - Project detailed info\n5 - Employee detailed info");
            Console.WriteLine("6 - Project employees info\n7 - Employee project info");
            Console.WriteLine("8 - Assign employee to project\n9 - Remove employee from project");
            Console.WriteLine("10 - Leave project\n11 - Finish the project\n12 - Exit the dashboard\n");

            Project[] AllProjects = new Project[0];
            Project[] CopyOfAllProjects = (Project[])AllProjects.Clone();
            Employee[] AllEmployees = new Employee[0];
            Employee[] CopyOfAllEmployees = (Employee[])AllEmployees.Clone();

            int projId;
            string projName;
            int empId;
            string empName;

            int prjIndex = 0;
            int empIndex = 0;

            bool isPlaying = true;
            int code;
            while (isPlaying)
            {
                Console.Write("\nTry to permorm an act: ");
                code = Convert.ToInt32(Console.ReadLine());

                switch (code)
                {
                    case 0:
                        Console.Write("Enter project name: ");
                        projName = Console.ReadLine().Trim();
                        Console.Write("Enter project id: ");
                        projId = Convert.ToInt32(Console.ReadLine());

                        CreateProject(ref AllProjects, ref CopyOfAllProjects, projId, projName);
                        Console.WriteLine($"Project {AllProjects[AllProjects.Length - 1].Name} is created!");
                        break;
                    case 1:
                        Console.Write("Enter employee name: ");
                        empName = Console.ReadLine().Trim();
                        Console.Write("Enter employee id: ");
                        empId = Convert.ToInt32(Console.ReadLine());

                        CreateEmployee(ref AllEmployees, ref CopyOfAllEmployees, empId, empName);
                        Console.WriteLine($"Employee {AllEmployees[AllEmployees.Length - 1].FullName} is created!");
                        break;
                    case 2:
                        GetAllInfoProjects(AllProjects);
                        break;
                    case 3:
                        GetAllInfoEmployees(AllEmployees);
                        break;
                    case 4:
                        Console.Write("Enter project id: ");
                        projId = Convert.ToInt32(Console.ReadLine());
                        GetProjectWithId(projId, AllProjects);
                        break;
                    case 5:
                        Console.Write("Enter employee id: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        GetEmployeeWithId(empId, AllEmployees);
                        break;
                    case 6:
                        Console.Write("Enter project id: ");
                        projId = Convert.ToInt32(Console.ReadLine());
                        GetProjectEmployees(projId, AllProjects);
                        break;
                    case 7:
                        Console.Write("Enter employee id: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        GetEmployeeProjects(empId, AllEmployees);
                        break;
                    case 8:
                        Console.Write("Which project you want to assign an employee: ");
                        projId = Convert.ToInt32(Console.ReadLine());
                        prjIndex = FindProject(projId, AllProjects);
                        if (!(prjIndex >= 0))
                        {
                            Console.WriteLine($"The project with id {projId} does not exist!");
                            break;
                        }

                        Console.Write($"Which employee you want to assign project {AllProjects[prjIndex].Name}: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        empIndex = FindEmployee(empId, AllEmployees);
                        if (!(empIndex >= 0))
                        {
                            Console.WriteLine($"The employee with id {empId} does not exist!");
                            break;
                        }

                        AssignEmployeeToProject(AllProjects[prjIndex], AllEmployees[empIndex]);
                        Console.WriteLine($"Employee {AllEmployees[empIndex].FullName} successfully assigned to project {AllProjects[prjIndex].Name}");
                        break;
                    case 9:
                        Console.Write("Which project you want to remove an employee: ");
                        projId = Convert.ToInt32(Console.ReadLine());
                        prjIndex = FindProject(projId, AllProjects);
                        if (!(prjIndex >= 0))
                        {
                            Console.WriteLine($"The project with id {projId} does not exist!");
                            break;
                        }

                        Console.Write($"Which employee you want to remove from project {AllProjects[prjIndex].Name}: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        empIndex = FindEmployee(empId, AllEmployees);
                        if (!(empIndex >= 0))
                        {
                            Console.WriteLine($"The employee with id {empId} does not exist!");
                            break;
                        }

                        RemoveEmployeeFromProject(AllProjects[prjIndex], empId);
                        Console.WriteLine($"Employee {AllEmployees[empIndex].FullName} successfully removed from project {AllProjects[prjIndex].Name}");
                        break;
                    case 10:
                        Console.Write("Which project you want to leave: ");
                        projId = Convert.ToInt32(Console.ReadLine());
                        prjIndex = FindProject(projId, AllProjects);
                        if (!(prjIndex >= 0))
                        {
                            Console.WriteLine($"No project on id {projId}!");
                            break;
                        }

                        Console.Write($"Enter your employee id for leave project {AllProjects[prjIndex].Name}: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        empIndex = FindEmployee(empId, AllEmployees);
                        if (!(empIndex >= 0))
                        {
                            Console.WriteLine($"No employee on id {empId}!");
                            break;
                        }
                        AllEmployees[empIndex].Leave(projId);
                        Console.WriteLine($"{AllEmployees[empIndex].FullName} leaves the project {AllProjects[prjIndex].Name}!");
                        break;
                    case 11:
                        Console.Write("Which project ready to finish: ");
                        projId = Convert.ToInt32(Console.ReadLine());
                        prjIndex = FindProject(projId, AllProjects);
                        if (!(prjIndex >= 0))
                        {
                            Console.WriteLine($"The project with id {projId} does not exist!");
                            break;
                        }
                        AllProjects[prjIndex].Finish();
                        break;
                    case 12:
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("0 - Create project\n1 - Create employee\n2 - All projects\n3 - All employees");
                        Console.WriteLine("4 - Project detailed info\n5 - Employee detailed info");
                        Console.WriteLine("6 - Project employees info\n7 - Employee project info");
                        Console.WriteLine("8 - Assign employee to project\n9 - Remove employee from project");
                        Console.WriteLine("10 - Leave project\n11 - Finish the project\n12 - Exit the dashboard\n");
                        break;
                }
            }
        }

        static void CreateProject(ref Project[] AllGivenProjects,ref Project[] CopyOfAllGivenProjects, int projId, string projName)
        {
            Array.Resize(ref CopyOfAllGivenProjects, CopyOfAllGivenProjects.Length + 1);
            CopyOfAllGivenProjects[CopyOfAllGivenProjects.Length - 1] = new Project(projId, projName);
            AllGivenProjects = CopyOfAllGivenProjects;
        }

        static void CreateEmployee(ref Employee[] AllGivenEmployees, ref Employee[] CopyOfAllGivenEmployees, int empId, string empFullName)
        {
            Array.Resize(ref CopyOfAllGivenEmployees, CopyOfAllGivenEmployees.Length + 1);
            CopyOfAllGivenEmployees[CopyOfAllGivenEmployees.Length - 1] = new Employee(empId, empFullName);
            AllGivenEmployees = CopyOfAllGivenEmployees;
        }

        static void GetAllInfoProjects(Project[] AllGivenProjects)
        {
            Console.WriteLine($"Number of projects: {AllGivenProjects.Length}");
            int count = 0;
            foreach (var prj in AllGivenProjects)
            {
                count++;
                Console.WriteLine($"{count}: {prj.Id} {prj.Name}");
            }
        }

        static void GetAllInfoEmployees(Employee[] AllGivenEmployees)
        {
            Console.WriteLine($"Number of employees: {AllGivenEmployees.Length}");
            int count = 0;
            foreach (var emp in AllGivenEmployees)
            {
                count++;
                Console.WriteLine($"{count}: {emp.Id} {emp.FullName}");
            }
        }

        static void GetProjectWithId(int id, Project[]? AllGivenProjects)
        {
            if (AllGivenProjects == null) return;

            int index = FindProject(id, AllGivenProjects);

            if (index < 0)
            {
                Console.WriteLine($"The project with id {id} does not exist!");
                return;
            }
            else
            { 
                AllGivenProjects[index].GetInfo();
            }
        }

        static void GetEmployeeWithId(int id, Employee[]? AllGivenEmployees)
        {
            if (AllGivenEmployees == null) return;

            int index = FindEmployee(id, AllGivenEmployees);

            if (index < 0)
            {
                Console.WriteLine($"The employee with id {id} does not exist!");
                return;
            }
            else
            {
                AllGivenEmployees[index].GetInfo();
            }
        }

        static void GetProjectEmployees(int id, Project[]? AllGivenProjects)
        {
            if (AllGivenProjects == null) return;

            int index = FindProject(id, AllGivenProjects);

            if (index < 0)
            {
                Console.WriteLine($"The project with id {id} does not exist!");
                return;
            }
            else
            { 
                AllGivenProjects[index].GetInfoEmployees();
            }

        }

        static void GetEmployeeProjects(int id, Employee[]? AllGivenEmployees)
        {
            if (AllGivenEmployees == null) return;

            int index = FindEmployee(id, AllGivenEmployees);

            if (index < 0)
            {
                Console.WriteLine($"The employee with id {id} does not exist!");
                return;
            }
            else
            {
                AllGivenEmployees[index].GetInfoProjects();
            }
        }

        static void AssignEmployeeToProject(Project project, Employee employee)
        {
            project.AssignEmployee(employee);
        }

        static void RemoveEmployeeFromProject(Project project, int empId)
        {
            project.RemoveEmployee(empId);
        }

        static int FindProject(int id, Project[]? AllGivenProjects) // helper function for find project index in Projects array
        {
            if (AllGivenProjects == null) return -1;

            int index = 0;
            int count = 0;
            for (int i = 0; i < AllGivenProjects.Length; i++)
            {
                if (AllGivenProjects[i].Id == id)
                {
                    index = i;
                    break;
                }
                else
                {
                    count++;
                }
            }

            if (count == AllGivenProjects.Length)
            {
                return -1;
            }

            return index;
        }

        static int FindEmployee(int id, Employee[]? AllGivenEmployees) // helper function for find employee index in Employees array
        {
            if (AllGivenEmployees == null) return -1;

            int index = 0;
            int count = 0;
            for (int i = 0; i < AllGivenEmployees.Length; i++)
            {
                if (AllGivenEmployees[i].Id == id)
                {
                    index = i;
                    break;
                }
                else
                {
                    count++;
                }
            }

            if (count == AllGivenEmployees.Length)
            {
                return -1;
            }

            return index;
        }
    }
}
