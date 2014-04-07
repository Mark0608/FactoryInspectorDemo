using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryInsight.Core.Services.DataProvider;
using GalaSoft.MvvmLight;

namespace FactoryInsight.Core.ViewModel
{
    public class ItemViewModel:ViewModelBase
    {
        private IFactoryDataProvider _factoryDataProvider;
        private Factory _factory;

        /// <summary>
        /// Initializes a new instance of the RootViewModel class.
        /// </summary>
        public ItemViewModel(IFactoryDataProvider factoryDataProvider)
        {
            if (factoryDataProvider == null) throw new ArgumentNullException("factoryDataProvider");
            _factoryDataProvider = factoryDataProvider;
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                Factory = new LocalDataProvider().GetFactoriesNonAsync().First();
            }
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public async void Init(int id)
        {
            Factory = await _factoryDataProvider.GetFactory(id);
        }

        public Factory Factory
        {
            get { return _factory; }
            set
            {
                if (value == _factory) return;
                _factory = value;
		RaisePropertyChanged(() => Factory);
            }
        }
    }
}
