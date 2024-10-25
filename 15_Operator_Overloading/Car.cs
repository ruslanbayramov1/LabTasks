namespace _15_Operator_Overloading;

internal class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int EngineCode { get; set; }

    public Car(int id, string brand, string model, int year, int engineCode)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        EngineCode = engineCode;
    }

    public static bool operator <(Car leftCar, Car rightCar)
    {
        return leftCar.Year < rightCar.Year;
    }

    public static bool operator >(Car leftCar, Car rightCar)
    {
        return leftCar.Year > rightCar.Year;
    }

    public override string ToString()
    {
        return $"{this.GetType().ToString().Split(".")[^1]} {{ Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, EngineCode: {EngineCode} }}";
    }
}

static class Extension
{
    public static Car[] OrderByYear(this Car[] cars)
    {
        Car[] newCars = (Car[])cars.Clone();
        for (int i = 0; i < newCars.Length; i++)
        {
            for (int j = 0; j < newCars.Length - 1; j++)
            {
                if (newCars[j] > newCars[j + 1])
                {
                    Car temp = newCars[j];
                    newCars[j] = newCars[j + 1];
                    newCars[j + 1] = temp;
                }
            }
        }
        return newCars;
    }
}
