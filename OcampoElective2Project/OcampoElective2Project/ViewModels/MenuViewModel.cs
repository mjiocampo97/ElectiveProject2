using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Views;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
   public class MenuViewModel : OcampoElective2ProjectViewModel
    {
        public MenuViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
        }
        private UserAccount _user;
       public UserAccount User { get; set; }
        private void ToggleMasterPageIsPresented()
        {
            if (((MasterDetailPage)(App.Current.MainPage)).IsPresented)
            {
                ((MasterDetailPage)(App.Current.MainPage)).IsPresented = false;
            }
            else
            {
                ((MasterDetailPage)(App.Current.MainPage)).IsPresented = true;
            }
        }
        public ICommand LogoutCommand => new RelayCommand(LogoutProc);
        public void LogoutProc()
        {
            //HomePageService.Logout();
            SettingsImplementation.User = "";
            SettingsImplementation.IsLoggedIn = false;
            NavigationService.NavigateTo(ViewModelLocator.LogInPage, null, true);
            ((MasterDetailPage)App.Current.MainPage).IsGestureEnabled = false;
            ToggleMasterPageIsPresented();
            Application.Current.MainPage.DisplayAlert("Alert Message","You have logout successfully", "Close");
        }
        public ICommand GoToHomePageCommand => new RelayCommand(GoToHomePageProc);
        private void GoToHomePageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.HomePage, User, true);
            ToggleMasterPageIsPresented();
        }
        public ICommand GoToClothesPageCommand => new RelayCommand(GoToClothesPageProc);

        private void GoToClothesPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.ClothesPage, User, true);
            ToggleMasterPageIsPresented();
        }

        public ICommand GoToFoodPageCommand => new RelayCommand(GoToFoodPageProc);

        private void GoToFoodPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.FoodPage, User, true);
            ToggleMasterPageIsPresented();
        }
        public ICommand GoToTransportationPageCommand => new RelayCommand(GoToTransportationPageProc);

        private void GoToTransportationPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.TransportationPage, User, true);
            ToggleMasterPageIsPresented();
        }

        public ICommand GoToOthersPageCommand => new RelayCommand(GoToOthersPageProc);
        private void GoToOthersPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.OthersPage, User, true);
            ToggleMasterPageIsPresented();
        }

        public ICommand GoToExpensePageCommand => new  RelayCommand(GoToExpensePageProc);

        private void GoToExpensePageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.ExpensePage,User,true);
            ToggleMasterPageIsPresented();
        }


        public ICommand GoToIncomePageCommand => new RelayCommand(GoToIncomePageProc);

        private void GoToIncomePageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.IncomePage, User, true);
            ToggleMasterPageIsPresented();
        }
    }
}
