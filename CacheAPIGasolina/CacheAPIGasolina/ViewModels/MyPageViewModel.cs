using CacheAPIGasolina.Models;
using CacheAPIGasolina.Services;
using CacheAPIGasolina.Share;
using CacheAPIGasolina.Views;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Prism.Navigation;
using Refit;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CacheAPIGasolina.ViewModels
{
    public class MyPageViewModel : BaseViewModel
    {
        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<Character> _fuel;
        public ObservableCollection<Character> FuelCollection {
            get => _fuel;
            set
            {
                if (_fuel != value)
                {
                    _fuel = value;
                    RaisePropertyChanged();
                }
            }
        }

        

        public HttpResponseMessage response;
        public string BaseURL = "https://makeup-api.herokuapp.com";

        public MyPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Count = 100;
            Barrel.ApplicationId = "MonkeyCacheSample2";
            Task.Run(() => GetResponse());
        } 

        async Task<IEnumerable<Fuel>> GetResponse()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: BaseURL))
            {
                var fuels= Barrel.Current.Get<IEnumerable<Character>>(key: BaseURL);
                FuelCollection = new ObservableCollection<Character>(fuels);
                await PopupNavigation.Instance.PushAsync(new PopUpWarning());
            }

            var apiResponse = RestService.For<IFuelsApi>(BaseURL);
            response = await apiResponse.GetFuels();

            if (response.IsSuccessStatusCode)
            {
                var JD = JsonConvert.DeserializeObject<List<Character>>(await response.Content.ReadAsStringAsync());
                    FuelCollection = new ObservableCollection<Character>(JD);
                
                Barrel.Current.Add(key: BaseURL, data: FuelCollection, expireIn: TimeSpan.FromDays(2));
            }
            return null;
        }
    }
}
