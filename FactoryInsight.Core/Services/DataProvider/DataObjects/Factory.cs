using System;
using System.Collections.Generic;

namespace FactoryInsight.Core.Services.DataProvider
{
    public class Factory
    {
        public Factory(int id, string title, string description)
        {
            if (title == null) throw new ArgumentNullException("title");
            if (description == null) throw new ArgumentNullException("description");

            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        // machines
        public IEnumerable<Machine> Machines { get; set; }
        // status
        public Status Status { get; set; }
        // produced units (12 months)
        public IEnumerable<int> ProducedUnits { get; set; }
    }
}