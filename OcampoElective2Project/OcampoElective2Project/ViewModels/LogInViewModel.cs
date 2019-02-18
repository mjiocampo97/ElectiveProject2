using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.LogInService;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
    public class LogInViewModel : OcampoElective2ProjectViewModel
    {
    
        private string _username;
        private string _password;
        public string Username
        {
            get => _username;
            set { Set(ref _username, value); }
        }

        public string Password
        {
            get => _password;
            set { Set(ref _password, value); }
        }
        public ILogInService LogInService { get; set; }
        public LogInViewModel(INavigationService navigationService, ILogInService logInService)
        {
           
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            LogInService = logInService;

        }
        public ICommand LogInCommand => new RelayCommand(LoginProc);
        
        public void LoginProc()
        {
            var user = LogInService.Check(Username, Password);
            if (user != null)
            {
                NavigationService.NavigateTo(ViewModelLocator.HomePage, user, true);
                SettingsImplementation.User = JsonConvert.SerializeObject(user);
                Application.Current.MainPage.DisplayAlert("LogIn Succesfull","","Cancel");
                App.Locator.MenuViewModel.User = user;
                ((MasterDetailPage)App.Current.MainPage).IsGestureEnabled = true;
                SettingsImplementation.IsLoggedIn = true;
                
           }
            else
            {
                ////TODO Show error message   
                Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid entries. Username is 'username' and Password is 'password'", "Close");
                //NavigationService.NavigateTo(ViewModelLocator.TransportationPage);
                //Username = "";
                //Password = "";
            }

        }
        public ICommand RegisterCommand =>new RelayCommand(RegisterProc);

        public void RegisterProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.RegistrationPage);
        }
    }
}
