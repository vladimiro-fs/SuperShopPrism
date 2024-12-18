﻿namespace SuperShopPrism.ViewModels
{
    using Prism.Navigation;
    using SuperShopPrism.Models;

    public class ProductDetailPageViewModel : ViewModelBase
    {
        private ProductResponse _product;

        public ProductDetailPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
        }

        public ProductResponse Product 
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("product")) 
            {
                Product = parameters.GetValue<ProductResponse>("product");
                Title = Product.Name;
            }
        }
    }
}
