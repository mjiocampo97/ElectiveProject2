using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using OcampoElective2Project.Services.LogInService;
using OcampoElective2Project.Services.RegisterService;
using OcampoElective2Project.ViewModels;

namespace OcampoElective2Project.Helpers
{
    public class ViewModelLocator
    {
        public const string LogInPage = "LogInPage";
        public const string ClothesPage = "ClothesPage";
        public const string FoodPage = "FoodPage";
        public const string HomePage = "HomePage";
        public const string MenuPage = "MenuPage";
        public const string OthersPage = "OthersPage";
        public const string RegistrationPage = "RegistrationPage";
        public const string TransportationPage = "TransportationPage";

        public bool IsTestMode { get; set; }

        public ViewModelLocator()
        {
            IsTestMode = true;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LogInViewModel>();
            SimpleIoc.Default.Register<ClothesViewModel>();
            SimpleIoc.Default.Register<FoodViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<OthersViewModel>();
            SimpleIoc.Default.Register<RegistrationViewModel>();
            SimpleIoc.Default.Register<TransportationViewModel>();

            if (IsTestMode == true)
            {
                SimpleIoc.Default.Register<ILogInService, MockLogInService>();
                SimpleIoc.Default.Register<IRegisterService, MockRegisterService>();

            }

            else
            {
                SimpleIoc.Default.Register<ILogInService, LogInService>();
                SimpleIoc.Default.Register<IRegisterService, RegisterService>();
            }

        }
        public LogInViewModel LogInViewModel => ServiceLocator.Current.GetInstance<LogInViewModel>();
        public ClothesViewModel ClothesViewModel => ServiceLocator.Current.GetInstance<ClothesViewModel>();
        public FoodViewModel FoodViewModel => ServiceLocator.Current.GetInstance<FoodViewModel>();
        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public MenuViewModel MenuViewModel => ServiceLocator.Current.GetInstance<MenuViewModel>();
        public OthersViewModel OthersViewModel => ServiceLocator.Current.GetInstance<OthersViewModel>();
        public RegistrationViewModel RegistrationViewModel => ServiceLocator.Current.GetInstance<RegistrationViewModel>();
        public TransportationViewModel TransportationViewModel =>  ServiceLocator.Current.GetInstance<TransportationViewModel>();




    }
}
