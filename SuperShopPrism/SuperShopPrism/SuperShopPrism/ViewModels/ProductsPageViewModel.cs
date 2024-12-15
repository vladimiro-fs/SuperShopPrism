namespace SuperShopPrism.ViewModels
{
    using System.Collections.Generic;
    using Prism.Navigation;
    using SuperShopPrism.Models;
    using SuperShopPrism.Services;

    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<ProductResponse> _products;

        public ProductsPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Products Page";
            LoadProductsAsync();
        }

        public List<ProductResponse> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private async void LoadProductsAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "OK");
                return;
            }

            Products = (List<ProductResponse>)response.Result;
        }
    }
}
