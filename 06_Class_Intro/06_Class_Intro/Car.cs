using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Class_Intro
{
    internal class Car : Vehicle
    {
        public string Brand;
        public string Model;
        public double FuelCapacity;
        public double FuelFor1km;
        public double CurrentFuel;

        public Car(int year, string brand, string model, double fuelCapacity, double fuelFor1km, int currentFuel = 0, string color = "") : base(color, year)
        {
            Brand = brand;
            Model = model;
            FuelCapacity = fuelCapacity;
            FuelFor1km = fuelFor1km;
            CurrentFuel = currentFuel;
        }

        public void ShowInfo()
        {
            if (Color == "") Console.WriteLine($"Year: {Year}\nBrand: {Brand}\nModel: {Model}\nFuel Capacity: {FuelCapacity} l\nCurrent Fuel: {CurrentFuel} l");
            else Console.WriteLine($"Year: {Year}\nBrand: {Brand}\nModel: {Model}\nColor: {Color}\nFuel Capacity: {FuelCapacity} l\nCurrent Fuel: {CurrentFuel} l");
        }

        public void Drive(double distance)
        {
            double usedFuel = FuelFor1km * distance;
            double remainingFuel = CurrentFuel - usedFuel;
            bool canDrived = remainingFuel < 0 ? false : true;

            if (!canDrived) Console.WriteLine($"\nDistance {distance} km can not be drivig with {CurrentFuel} l fuel. You need {usedFuel} l fuel.");
            else if (canDrived) Console.WriteLine($"\nDistance {distance} km can be drivig with {CurrentFuel} l fuel. Car will use {usedFuel} l fuel and remaining fuel will be {remainingFuel} l");
        }

    }
}
