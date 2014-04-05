using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryInsight.Core.Services.DataProvider
{
    public class LocalDataProvider:IFactoryDataProvider
    {
        private readonly Random _random;
        private readonly List<Factory> _factories;

        public LocalDataProvider()
        {
            _random = new Random(42);
            _factories = new List<Factory>();
            _factories.Add(CreateMobileFactory(1, "Mobile Factory", "Producing our latest and greates Windows Phones.", 170000, 190000));
            _factories.Add(CreateMobileFactory(2, "Mobile Factory", "Producing our latest and greates Robo Phones.", 1000, 900000));
            _factories.Add(CreateMobileFactory(3, "Tablet Factory", "Producing our latest and greates Windows Tablets.", 120000, 190000));
        }

        public IEnumerable<Factory> GetFactories()
        {
            return _factories;
        }

        private Factory CreateMobileFactory(int id, string name, string description, int minProduction, int maxProduction)
        {
            var mobileFactory = new Factory(id, name, description)
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

            var batteryStation = new Machine(1, "Battery Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 21),
                Uptime = GetRandomTimespan(3),
            };

            var displayStation = new Machine(2, "Display Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 20),
                Uptime = GetRandomTimespan(20),
            };

            var electronicsStation = new Machine(3, "Electronics Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 22),
                Uptime = GetRandomTimespan(20),
            };

            var hullStation = new Machine(4, "Hull Station")
            {
                Status = Status.Running,
                TemperatureHistory = GetRandomTemperaturePoints(10, 22),
                Uptime = GetRandomTimespan(20),
            };

            var assemblyStation = new Machine(5, "Hull Station")
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