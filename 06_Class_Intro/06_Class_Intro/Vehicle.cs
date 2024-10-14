using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Class_Intro
{
    internal class Vehicle
    {
        public string Color;
        public int Year;

        public Vehicle(int year)
        {
            Year = year;
        }

        public Vehicle(string color, int year) : this(year)
        {
            Color = color;
        }
    }
}
