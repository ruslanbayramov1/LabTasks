using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Class_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car mercedes = new Car(2024, "Mercedes", "AMG GT 63 S", 65, 0.25, 35, "Black");
            mercedes.ShowInfo();
            mercedes.Drive(120);
        }
    }
}
