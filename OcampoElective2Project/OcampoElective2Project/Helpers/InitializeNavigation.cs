using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.ViewModels;
using OcampoElective2Project.Views;
using SQLite;
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
            InitializeData();



        }

         public void InitializeData()
        {
            //  if (IsTestMode == true)

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Storage.db3");
            
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                //connection.CreateTable<UserAccount>();
                //connection.CreateTable<Clothes>();
                //connection.CreateTable<Food>();
                //connection.CreateTable<Others>();
                //connection.CreateTable<Transportation>();
              

                //var food= connection.Table<Food>();
                //var listOfFood = food.ToList();

                //var others= connection.Table<Others>();
                //var listOfOthers = others.ToList();

                //var clothes = connection.Table<Clothes>();
                //var listOfClothes = clothes.ToList();

                //var transportation = connection.Table<Transportation>();
                //var listOfTransportation = transportation.ToList();

                //var user = connection.Table<UserAccount>();
                //var listOfUser = user.ToList();
                }

            }

        }
         private void CreateMockDataSQL(SQLiteConnection connection)
         {
             for (int i = 0; i < 3; i++)
             {
                 connection.Insert(new Clothes()
                 {
                     Name = $" Clothes {i}",
                     Price = i * 100,
                     UserId = 0
                 });
             }
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
            navigationService.Configure(ViewModelLocator.AddClothesPage, typeof(AddClothesPage));
            navigationService.Configure(ViewModelLocator.AddFoodPage, typeof(AddFoodPage));
            navigationService.Configure(ViewModelLocator.AddOthersPage, typeof(AddOthersPage));
            navigationService.Configure(ViewModelLocator.AddTransportationPage, typeof(AddTransportationPage));



        }

        public MasterDetailPage SetMasterDetailMainPage()
        {
            bool isGestureEnabled;
            var navigationPage = new NavigationPage();
            var user = new UserAccount();
            if (SettingsImplementation.IsLoggedIn)
            {
                var userJsonString = JToken.Parse(SettingsImplementation.User).ToString();
                user = JsonConvert.DeserializeObject<UserAccount>(userJsonString);
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
        //public NavigationPage Intropage()
        //{
        //    bool isGestureEnabled;
        //    var navigationPage = new NavigationPage();
        //    var user = new UserAccount();
        //    if (SettingsImplementation.IsLoggedIn)
        //    {
        //        // var userJsonString = JToken.Parse(SettingsImplementation.User).ToString();
        //        //  user = JsonConvert.DeserializeObject<UserAccount>(userJsonString);
        //        navigationPage = new NavigationPage(new HomePage(user));
        //        isGestureEnabled = true;
        //    }
        //    else
        //    {
        //        navigationPage = new NavigationPage(new LogInPage());
        //        isGestureEnabled = false;
        //    }

        //    var state = new NavigationPage();
        //    return state;
        //}

    }
}
