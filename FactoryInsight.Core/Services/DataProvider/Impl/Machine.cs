using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryInsight.Core.Services.DataProvider
{
    public class Machine
    {
        public Machine(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        public string Name { get; set; }
        public Status Status { get; set; }

        public double CurrentTemperature
        {
            get { return TemperatureHistory.FirstOrDefault(); }
        }

        public TimeSpan Uptime { get; set; }
        public IEnumerable<double> TemperatureHistory { get; set; }
    }
}