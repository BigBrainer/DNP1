using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_05_S02
{
    class Car
    {
        public string Color { get; set; }
        public int EngineSize { get; set; }
        public double FuelEconomy { get; set; }
        public bool IsManualShift { get; set; }

        public Car(string color, int engineSize, double fuelEconomy, bool isManualShift)
        {
            Color = color;
            EngineSize = engineSize;
            FuelEconomy = fuelEconomy;
            IsManualShift = isManualShift;
        }

        public Car()
        {

        }
        public override string ToString()
        {
            return $"Color of the car: {Color}\nEngine size: {EngineSize}\nFuel economy per in l/100km: {FuelEconomy}\n" +
                $"Manual:{IsManualShift} ";
        }

        public List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car("Yellow",30,12,true),
                new Car("Green", 23,16, false ),
                new Car("Purple", 25, 16, true),
                new Car("Yellow", 25,19, false),
                new Car("Red", 23, 15, true)
            };
        }
    }
}
