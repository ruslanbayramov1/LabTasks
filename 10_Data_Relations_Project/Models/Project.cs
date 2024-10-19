namespace _10_Data_Relations_Project.Models
{
    internal class Project
    {
        #region Encapsulation
        private int _id;
        private string _name;
        private Employee[] _employees = { }; //prevent from error
        private DateTime _startTime;
        private DateTime _deadline;
        private string _status;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public Employee[] Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
            }
        }

        private DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
            }
        }

        private DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                _deadline = value;
            }
        }

        private string Status 
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }
        #endregion

        public Project(int projId, string projName)
        {
            Id = projId;
            Name = projName;
            StartTime = DateTime.Now;
            Deadline = new DateTime(StartTime.Year, StartTime.Month + 1, StartTime.Day);
            Status = "Working...";
        }

        public void GetInfo()
        {
            DateTime current = DateTime.Now;
            Console.WriteLine($"Id: {Id}\nProject: {Name}\nNumber of employees: {Employees.Length}\nStatus: {Status}");
            Console.WriteLine($"StartDate: {StartTime}\nDeadline: {Deadline}\nDays remains: {(Deadline - current).Days}");
        }

        public void GetInfoEmployees()
        {
            if (Employees.Length >= 1)
            {
                Console.WriteLine($"{Name}'s all employees:");
                int count = 0;
                foreach (Employee employee in Employees)
                {
                    count++;
                    Console.WriteLine($"{count}.\nId: {employee.Id}\nName: {employee.FullName}");
                }
            }
            else
            {
                Console.WriteLine($"The project {Name} have no employee");
            }
        }

        public void AssignEmployee(Employee givenEmployee)
        {
            Employee[] clonedEmployees = (Employee[])Employees.Clone();
            Array.Resize(ref clonedEmployees, clonedEmployees.Length + 1);
            clonedEmployees[clonedEmployees.Length - 1] = givenEmployee;
            Employees = clonedEmployees;

            // adding project to given employee
            AssignProjectToEmployee(givenEmployee);
        }

        private void AssignProjectToEmployee(Employee givenEmployee)
        {
            Project[] clonedProjects = (Project[])givenEmployee.Projects.Clone();
            Array.Resize(ref clonedProjects, clonedProjects.Length + 1);
            clonedProjects[clonedProjects.Length - 1] = this;
            givenEmployee.Projects = clonedProjects;
        }

        public void RemoveEmployee(int employeeId)
        {
            int length = 0;
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Id != employeeId) length++;
            }

            if (length == Employees.Length)
            {
                return;
            }

            Employee[] tempEmployees = new Employee[length];
            int index = 0;
            int remIndex = 0;
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Id != employeeId)
                {
                    tempEmployees[index] = Employees[i];
                    index++;
                }
                else if (Employees[i].Id == employeeId) remIndex = i;
            }

            Employees[remIndex].RemoveProject(Id); // remindex is removed employee and calling its leave method for remove project from employee

            Employees = tempEmployees; // last action to re-assign removed element array
        }

        public void Finish()
        {
            DateTime curretTime = DateTime.Now;
            if (curretTime > Deadline)
            {
                Status = "Fail";
                Console.WriteLine($"Oops! You reached the deadline, unsuccessful project! Status {Status} added");
            }
            else if (curretTime <= Deadline && curretTime >= StartTime)
            { 
                Status = "Successful";
                Console.WriteLine($"The project finished successfully. Status {Status} added.");
            }
        }
    }

    internal class Employee
    {
        #region Encapsulation
        private int _id;
        private string _fullName;
        private Project[] _projects = { };

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
            }
        }

        public Project[] Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
            }
        }
        #endregion

        public Employee(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Id: {Id}\nName: {FullName}\nNumber of projects: {Projects.Length}");
        }

        public void GetInfoProjects()
        {
            if (Projects.Length >= 1)
            {
                Console.WriteLine($"{FullName}'s all projects:");
                int count = 0;
                foreach (Project project in Projects)
                {
                    count++;
                    Console.WriteLine($"{count}.\nId: {project.Id}\nName: {project.Name}");
                }
            }
            else
            {
                Console.WriteLine($"The employee {FullName} have no projects");
            }
        }

        public Project RemoveProject(int projectId) // removes project from employee
        {
            int length = 0;
            for (int i = 0; i < Projects.Length; i++)
            {
                if (Projects[i].Id != projectId) length++;
            }

            if (length == Projects.Length)
            {
                return null;
            }

            Project[] tempProjects = new Project[length];
            int index = 0;
            int remIndex = 0;
            for (int i = 0; i < Projects.Length; i++)
            {
                if (Projects[i].Id != projectId)
                {
                    tempProjects[index] = Projects[i];
                    index++;
                }
                else if (Projects[i].Id == projectId) remIndex = i;
            }

            Project removedPrj = Projects[remIndex];

            Projects = tempProjects; // last action to re-assign removed element array

            return removedPrj;
        }

        public void Leave(int projectId)
        {
            Project removedPrj = RemoveProject(projectId);

            if (removedPrj == null)
            {
                return;
            }

            removedPrj.RemoveEmployee(Id);
        }
    }
}
