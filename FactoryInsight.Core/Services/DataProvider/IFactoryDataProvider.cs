using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryInsight.Core.Services.DataProvider
{
    public interface IFactoryDataProvider
    {
        Task<IEnumerable<Factory>> GetFactories();
        Task<Factory> GetFactory(int factoryId);
        Task<Machine> GetMachine(int factoryId, int machineId);
    }
}
