using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheAPIGasolina.Share
{
    public class BaseViewModel : BindableBase
    {
        #region Properties

        public IEventAggregator EventAggregator;

        public INavigationService NavigationService;

        #endregion Properties

        #region Constructors

        public BaseViewModel()
        {
        }

        public BaseViewModel(INavigationService navigationService) : base()
        {
            NavigationService = navigationService;
        }

        public BaseViewModel(IEventAggregator eventAggregator, INavigationService navigationService) : base()
        {
            EventAggregator = eventAggregator;
            NavigationService = navigationService;
        }

        #endregion Constructors
    }
}
