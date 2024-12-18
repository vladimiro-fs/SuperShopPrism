namespace SuperShopPrism.ViewModels
{
    using Prism.Navigation;
    using SuperShopPrism.Helpers;

    public class ShowCartPageViewModel : ViewModelBase
    {       
        public ShowCartPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ShowShoppingCart;
        }
    }
}
