using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
   public class MenuViewModel : OcampoElective2ProjectViewModel
    {
        private UserAccount _user;
        public UserAccount User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }
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
            SettingsImplementation.IsLoggedIn = false;
            NavigationService.NavigateTo(ViewModelLocator.LogInPage, null, true);
            ToggleMasterPageIsPresented();
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
            NavigationService.NavigateTo(ViewModelLocator.ClothesPage, null, true);
            ToggleMasterPageIsPresented();
        }

        public ICommand GoToFoodPageCommand => new RelayCommand(GoToFoodPageProc);

        private void GoToFoodPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.FoodPage, null, true);
            ToggleMasterPageIsPresented();
        }
        public ICommand GoToTransportationPageCommand => new RelayCommand(GoToTransportationPageProc);

        private void GoToTransportationPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.TransportationPage, null, true);
            ToggleMasterPageIsPresented();
        }

        public ICommand GoToOthersPageCommand => new RelayCommand(GoToOthersPageProc);
        private void GoToOthersPageProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.OthersPage, null, true);
            ToggleMasterPageIsPresented();
        }
    }
}
