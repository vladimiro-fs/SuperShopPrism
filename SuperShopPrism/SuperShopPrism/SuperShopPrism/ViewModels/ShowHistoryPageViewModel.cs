namespace SuperShopPrism.ViewModels
{
    using Prism.Navigation;
    using SuperShopPrism.Helpers;

    public class ShowHistoryPageViewModel : ViewModelBase
    {        
        public ShowHistoryPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {        
            Title = Languages.ShowPurchaseHistory;
        }
    }
}
