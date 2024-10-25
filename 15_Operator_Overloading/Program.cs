namespace _15_Operator_Overloading;

internal class Program
{
    static void Main(string[] args)
    {
        Car[] cars =
        {
                new Car(1, "Mercedes", "AMG GT", 2022, 13492),
                new Car(2, "BMW", "M5", 2018, 99425),
                new Car(3, "AUDI", "R8", 2020, 23482)
            };

        Car[] orderedCars = cars.OrderByYear();

        foreach (Car car in orderedCars)
        {
            Console.WriteLine(car);
        }
    }
}
