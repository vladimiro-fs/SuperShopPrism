namespace SuperShopPrism
{
    using Prism;
    using Prism.Ioc;
    using SuperShopPrism.Services;
    using SuperShopPrism.ViewModels;
    using SuperShopPrism.Views;
    using Syncfusion.Licensing;
    using Xamarin.Essentials.Implementation;
    using Xamarin.Essentials.Interfaces;
    using Xamarin.Forms;

    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzYyNzM1M0AzMjM4MmUzMDJlMzBhUUpDYVFNUTQrSjNFbVlwMDRJU0NzUnF5VjZZcUJoY2tFSEJnSnFhL2JBPQ ==");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ProductsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IApiService, ApiService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();
        }
    }
}
