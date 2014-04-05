using System;
using System.Collections.Generic;

namespace FactoryInsight.Core.Services.DataProvider
{
    public class Factory
    {
        public Factory(int id, string name, string description)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (description == null) throw new ArgumentNullException("description");

            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        // machines
        public IEnumerable<Machine> Machines { get; set; }
        // status
        public Status Status { get; set; }
        // produced units (12 months)
        public IEnumerable<int> ProducedUnits { get; set; }
    }
}