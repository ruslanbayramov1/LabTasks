using System;

namespace _07_Class_Inheritance
{
    class Student
    {
        public string Name;
        public string Surname;
        public Grade[] Grades;

        public Student(string name, string surname, Grade[] grades)
        {
            Name = name;
            Surname = surname;
            Grades = grades;
        }

        public void PrintGrades()
        {
            int count = 1;
            foreach (Grade grade in Grades)
            {
                Console.WriteLine($"{count}.\nSubject: {grade.Subject}\nPoint: {grade.Point}\nCredit: {grade.CreditCount}\n");
                count++;
            }
        }

        public double GetAvgGrade()
        {
            double sum = 0;
            foreach (Grade grade in Grades)
            {
                sum += grade.Point;
            }
            return sum / Grades.Length;
        }

        public double GetCreditCount()
        {
            double sum = 0;
            foreach (Grade grade in Grades)
            {
                sum += grade.CreditCount;
            }
            return sum;
        }

        public void AddGrades(Grade grade)
        {
            //int length = Grades.Length;
            //Array.Resize(ref Grades, length + 1);
            //Grades[length] = grade; 

            Grade[] newGrades = new Grade[Grades.Length + 1]; //creating new grade with + 1 length
            for (int i = 0; i < Grades.Length; i++)
            {
                newGrades[i] = Grades[i]; // copying objects of grades
            }
            newGrades[Grades.Length] = grade; // adding new grade to new grades array

            Grades = newGrades; // re-assign Grades with new size
        }
    }
}

