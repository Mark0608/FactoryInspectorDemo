using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryInsight.Core.Services.DataProvider
{
    public class Machine
    {
        private readonly string _imagePath;

        public Machine(int id, string title)
        {
            if (title == null) throw new ArgumentNullException("title");
            Title = title;
            Id = id;
            _imagePath = string.Format("Assets/{0}.png", Title);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }

        public string ImagePath { get { return _imagePath; } }

        public double CurrentTemperature
        {
            get { return TemperatureHistory.FirstOrDefault(); }
        }

        public TimeSpan Uptime { get; set; }
        public IEnumerable<double> TemperatureHistory { get; set; }
    }
}