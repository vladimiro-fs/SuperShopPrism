namespace SuperShopPrism.ViewModels
{
    using Prism.Navigation;
    using SuperShopPrism.Helpers;

    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ModifyUser;
        }
    }
}
