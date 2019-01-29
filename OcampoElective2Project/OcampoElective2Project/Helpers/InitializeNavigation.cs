using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.ViewModels;
using OcampoElective2Project.Views;
using Xamarin.Forms;

namespace OcampoElective2Project.Helpers
{

    public class InitializeNavigation
    {
        public NavigationService navigationService { get; }
        public InitializeNavigation()
        {
            navigationService = new NavigationService();
            SimpleIoc.Default.Reset();
            SetPages();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

        }

        public void SetPages()
        {
            navigationService.Configure(ViewModelLocator.LogInPage, typeof(LogInPage));
            navigationService.Configure(ViewModelLocator.ClothesPage, typeof(ClothesPage));
            navigationService.Configure(ViewModelLocator.FoodPage, typeof(FoodPage));
            navigationService.Configure(ViewModelLocator.HomePage, typeof(HomePage));
            navigationService.Configure(ViewModelLocator.MenuPage, typeof(MenuPage));
            navigationService.Configure(ViewModelLocator.OthersPage, typeof(OthersPage));
            navigationService.Configure(ViewModelLocator.RegistrationPage, typeof(RegistrationPage));
            navigationService.Configure(ViewModelLocator.TransportationPage, typeof(TransportationPage));


        
        }

        public MasterDetailPage SetMasterDetailMainPage()
        {
            bool isGestureEnabled;
            var navigationPage = new NavigationPage();
            var user = new UserAccount();
            if (SettingsImplementation.IsLoggedIn)
            {
               // var userJsonString = JToken.Parse(SettingsImplementation.User).ToString();
              //  user = JsonConvert.DeserializeObject<UserAccount>(userJsonString);
                navigationPage = new NavigationPage(new HomePage(user));
                isGestureEnabled = true;
            }
            else
            {
                navigationPage = new NavigationPage(new LogInPage());
                isGestureEnabled = false;
            }


            var masterDetailPage = new MasterDetailPage
            {
                Detail = navigationPage,
                Master = new MenuPage(user) { Title = "Menu" }
            };
            navigationService.Initialize(navigationPage);
            masterDetailPage.IsGestureEnabled = isGestureEnabled;

            return masterDetailPage;

        }
    }
}
