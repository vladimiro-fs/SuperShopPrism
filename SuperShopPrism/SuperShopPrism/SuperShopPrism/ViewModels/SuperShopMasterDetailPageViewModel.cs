﻿namespace SuperShopPrism.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Prism.Navigation;
    using SuperShopPrism.Helpers;
    using SuperShopPrism.ItemViewModels;
    using SuperShopPrism.Models;
    using SuperShopPrism.Views;

    public class SuperShopMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public SuperShopMasterDetailPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_gift_card",
                    PageName = $"{nameof(ProductsPage)}",
                    Title = Languages.Products
                },

                new Menu
                {
                    Icon = "ic_shopping_cart",
                    PageName = $"{nameof(ShowCartPage)}",
                    Title = Languages.ShowShoppingCart
                },

                new Menu
                {
                    Icon = "ic_history",
                    PageName = $"{nameof(ShowHistoryPage)}",
                    Title = Languages.ShowPurchaseHistory,
                    IsLoginRequired = true
                },

                new Menu
                {
                    Icon = "ic_person",
                    PageName = $"{nameof(ModifyUserPage)}",
                    Title = Languages.ModifyUser,
                    IsLoginRequired = true
                },

                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = $"{nameof(LoginPage)}",
                    Title = Languages.Login
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }
}
