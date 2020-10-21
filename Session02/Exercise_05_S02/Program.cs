using System;

namespace Exercise_05_S02
{
    public class Program
    {
        static void Main(string[] args)
        {

            var car = new Car();
            Predicate<Car> predicate = FindCarByColor;

            var cars = car.GetCars();
            var yellowCars = cars.FindAll(predicate);
            /*for(int i = 0; i<yellowCars.Count; i++ )
            {
                Console.WriteLine(yellowCars[i]);
            }
*/
            var redCars = cars.FindAll(c => c.Color.Equals("Red"));
            var sixteenPerKm = cars.FindAll(c => c.FuelEconomy == 16);
            var engineSizeGreaterThan24 = cars.FindAll(c => c.EngineSize >= 24);

            /* for (int i = 0; i < redCars.Count; i++)
             {
                 Console.WriteLine(redCars[i]);
             }*/
            /* for (int i = 0; i < sixteenPerKm.Count; i++)
             {
                 Console.WriteLine(sixteenPerKm[i]);
             }*/
            /*for (int i = 0; i < engineSizeGreaterThan24.Count; i++)
            {
                Console.WriteLine(engineSizeGreaterThan24[i]);
            }*/

            var yellowCarsWithFuelConsumptionLowerThan15 = cars.FindAll(c => c.Color.Equals("Yellow") && c.FuelEconomy < 15);

            for (int i = 0; i < yellowCarsWithFuelConsumptionLowerThan15.Count; i++)
            {
                Console.WriteLine(yellowCarsWithFuelConsumptionLowerThan15[i]);
            }
        }

        private static bool FindCarByColor(Car car)
        {
            return car.Color.Equals("Yellow");
        }
    }
}
