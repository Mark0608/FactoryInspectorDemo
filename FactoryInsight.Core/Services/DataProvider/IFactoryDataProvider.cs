using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryInsight.Core.Services.DataProvider
{
    public interface IFactoryDataProvider
    {
        IEnumerable<Factory> GetFactories();
    }

    public class LocalDataProvider:IFactoryDataProvider
    {
        public IEnumerable<Factory> GetFactories()
        {
            var factories = new List<Factory>();
	    factories.Add(CreateMobileFactory("Mobile Factory", "Producing our latest and greates Windows Phones."));
        }

        private Factory CreateMobileFactory(string mobileFactory, string producingOurLatestAndGreatesWindowsPhones)
        {
            throw new NotImplementedException();
        }
    }

    public class Factory
    {
        public string Name { get; set; }
        public string Description { get; set; }
	// machines
        public IEnumerable<Machine> Machines { get; set; }
	// status
        public Status Status { get; set; }
	// produced units (12 months)
        public IEnumerable<int> ProducedUnits { get; set; }
    }

    public enum Status
    {
	running,
	notRunning
    }

    public class Machine
    {
        public Status Status { get; set; }
        public double Temperature { get; set; }
        public TimeSpan Uptime { get; set; }
    }
}
