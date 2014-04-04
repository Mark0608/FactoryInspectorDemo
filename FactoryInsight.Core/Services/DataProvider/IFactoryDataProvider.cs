using System.Collections.Generic;

namespace FactoryInsight.Core.Services.DataProvider
{
    public interface IFactoryDataProvider
    {
        IEnumerable<Factory> GetFactories();
    }
}
