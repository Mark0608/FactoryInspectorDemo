using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryInsight.Core.Services.DataProvider
{
    public class LocalDataProvider:IFactoryDataProvider
    {
        private readonly Random _random;

        public LocalDataProvider()
        {
            _random = new Random(42);
        }

        public IEnumerable<Factory> GetFactories()
        {
            var factories = new List<Factory>();
            factories.Add(CreateMobileFactory("Mobile Factory", "Producing our latest and greates Windows Phones.", 170000, 190000));
            factories.Add(CreateMobileFactory("Mobile Factory", "Producing our latest and greates Robo Phones.", 1000, 900000));
            factories.Add(CreateMobileFactory("Tablet Factory", "Producing our latest and greates Windows Tablets.", 120000, 190000));

            return factories;
        }

        private Factory CreateMobileFactory(string name, string description, int minProduction, int maxProduction)
        {
            var mobileFactory = new Factory(name, description)
            {
                Machines = CreateMobileFactoryMachines(),
                ProducedUnits = CreateProducedUnits(minProduction, maxProduction)
            };
            mobileFactory.Status = mobileFactory.Machines.All(m => m.Status == Status.Running)
                ? Status.Running
                : Status.NotRunning;
            return mobileFactory;
        }

        private IEnumerable<int> CreateProducedUnits(int minimum, int maximum)
        {
            var producedUnits = new List<int>(12);
            for (int i = 0; i < 12; ++i)
            {
                producedUnits.Add(_random.Next(minimum, maximum));
            }
            return producedUnits;
        }

        private IEnumerable<Machine> CreateMobileFactoryMachines()
        {
            var machines = new List<Machine>();

            var batteryStation = new Machine("Battery Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 21),
                Uptime = GetRandomTimespan(3),
            };

            var displayStation = new Machine("Display Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 20),
                Uptime = GetRandomTimespan(20),
            };

            var electronicsStation = new Machine("Electronics Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 22),
                Uptime = GetRandomTimespan(20),
            };

            var hullStation = new Machine("Hull Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 22),
                Uptime = GetRandomTimespan(20),
            };

            var assemblyStation = new Machine("Hull Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 22),
                Uptime = GetRandomTimespan(20),
            };

            machines.Add(batteryStation);
            machines.Add(displayStation);
            machines.Add(electronicsStation);
            machines.Add(hullStation);
            machines.Add(assemblyStation);

            return machines;
        }

        private TimeSpan GetRandomTimespan(int dayOffset)
        {
            int hours = _random.Next(0, 23);
            int minutes = _random.Next(0, 59);
            int seconds = _random.Next(0, 59);

            return new TimeSpan(dayOffset, hours, minutes, seconds);
        }

        private IEnumerable<double> GetRandomTemperaturePoints(int count, int baseTemperature)
        {
            var temperaturePoints = new List<double>();

            for (int i = 0; i < count; ++i)
            {
                var deltaTemperature = _random.NextDouble();
                var newTemperature = baseTemperature +
                                     (_random.Next(0, 1) == 1 ? deltaTemperature : deltaTemperature*-1);
                temperaturePoints.Add(newTemperature);
            }

            return temperaturePoints;
        }
    }
}