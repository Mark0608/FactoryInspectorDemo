using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FactoryInsight.Core.Services.DataProvider;
using GalaSoft.MvvmLight;

namespace FactoryInsight.Core.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RootViewModel : ViewModelBase
    {
        private readonly IFactoryDataProvider _factoryDataProvider;
        private ObservableCollection<Factory> _factories;

        /// <summary>
        /// Initializes a new instance of the RootViewModel class.
        /// </summary>
        public RootViewModel(IFactoryDataProvider factoryDataProvider)
        {
            if (factoryDataProvider == null) throw new ArgumentNullException("factoryDataProvider");
            _factoryDataProvider = factoryDataProvider;
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
	    Factories = new ObservableCollection<Factory>();
        }

        public async void Init()
        {
            var factories = await _factoryDataProvider.GetFactories();
	    Factories.Clear();
            foreach (var factory in factories)
            {
                Factories.Add(factory);
            }
        }

        public ObservableCollection<Factory> Factories
        {
            get { return _factories; }
            set { _factories = value; }
        }
    }
}