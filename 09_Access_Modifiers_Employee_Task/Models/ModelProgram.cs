namespace Models
{
    public class Employee
    {
        private string _name;
        private int _salary;

        internal string Name
        {
            get
            {
                return _name;
            }
            init
            {
                if (value.Length >= 3) _name = value;
                else Console.WriteLine("Name must contain at lest 3 characters");
            }
        } // makes property readonly after first initialize
        internal bool IsSuccessful { get; set; }
        internal int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value >= 1300) _salary = value;
                else Console.WriteLine("Minimum salary is 1300 for our company!!!");
            }
        }

        public Employee(string name, bool isSuccessfull, int salary)
        {
            Name = name;
            IsSuccessful = isSuccessfull;
            Salary = salary;
        }

        public void PrintEmployeeInfo()
        {
            Console.WriteLine($"Name: {Name}\nIsSuccessful: {IsSuccessful}\nSalary: {Salary}\n");
        }
    }

    public class Assistant : Manager // base class access level must be higer or equal
    {
        public void GetFeedBack(Employee employee)
        {
            if (employee.Name == null || employee.Salary == 0) Console.WriteLine("You can not perform that action without correct employee name or salary\n");
            else if (employee.IsSuccessful)
            {
                GetPromotion(employee);
                Console.WriteLine($"{employee.Name}'s salary promoted to {employee.Salary}\n");
            }
            else Console.WriteLine("The employee is not successful with tasks, no promote!\n");
        }
    }

    public class Manager
    {
        private protected void GetPromotion(Employee employee)
        {
            employee.Salary += 100;
        }
    }
}
