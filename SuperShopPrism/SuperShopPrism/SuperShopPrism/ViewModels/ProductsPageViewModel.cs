namespace SuperShopPrism.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Prism.Commands;
    using Prism.Navigation;
    using SuperShopPrism.ItemViewModels;
    using SuperShopPrism.Models;
    using SuperShopPrism.Services;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<ProductItemViewModel> _products;
        private bool _isRunning;
        private string _search;
        private List<ProductResponse> _myProducts;
        private DelegateCommand _searchCommand;

        public ProductsPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Products Page";
            LoadProductsAsync();
        }

        public DelegateCommand SearchComand => 
            _searchCommand ?? 
            (_searchCommand = new DelegateCommand(ShowProducts));

        public string Search 
        {
            get => _search;
            set 
            {
                SetProperty(ref _search, value);
                ShowProducts();
            } 
        }

        public bool IsRunning 
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<ProductItemViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private async void LoadProductsAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(async () => 
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error", 
                        "Check internet connection", 
                        "OK");
                });

                return;
            }

            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "OK");
                return;
            }

            _myProducts = (List<ProductResponse>)response.Result;
            ShowProducts();
        }

        private void ShowProducts()
        {
            if (string.IsNullOrEmpty(Search))
                Products = new ObservableCollection<ProductItemViewModel>(_myProducts.Select(p => 
                new ProductItemViewModel(_navigationService) 
                { 
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageId = p.ImageId,
                    LastPurchase = p.LastPurchase,
                    LastSale = p.LastSale,
                    IsAvailable = p.IsAvailable,
                    Stock = p.Stock,
                    User = p.User,
                    ImageFullPath = p.ImageFullPath,
                }).ToList());

            else
                Products = new ObservableCollection<ProductItemViewModel>(
                    _myProducts.Select(p => 
                    new ProductItemViewModel(_navigationService) 
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageId = p.ImageId,
                        LastPurchase = p.LastPurchase,
                        LastSale = p.LastSale,
                        IsAvailable = p.IsAvailable,
                        Stock = p.Stock,
                        User = p.User,
                        ImageFullPath = p.ImageFullPath,
                    })
                    .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());
        }
    }
}
