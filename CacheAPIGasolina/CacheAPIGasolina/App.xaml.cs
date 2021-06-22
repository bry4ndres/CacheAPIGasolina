using CacheAPIGasolina.ViewModels;
using CacheAPIGasolina.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;

using Xamarin.Forms;

namespace CacheAPIGasolina
{
    public partial class App : PrismApplication
    {
        #region Constructor

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        #endregion Constructor

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MyPage").ConfigureAwait(false);
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MyPage, MyPageViewModel>();
        }
    }
}