using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.IncomeService;
using OcampoElective2Project.Services.RegisterService;
using OcampoElective2Project.Services.UserAccountService;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
    public class RegistrationViewModel : OcampoElective2ProjectViewModel
    {
      
        public IRegisterService RegisterService { get; set; }
        public UserAccount UserAccountToAdd { get; set; }
        public RegistrationViewModel(INavigationService navigationService, IRegisterService registerService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
          UserAccountToAdd = new UserAccount();
          RegisterService = registerService;
       
        }

        public ICommand RegisterCommand => new RelayCommand(RegisterProc);

        private void RegisterProc()
        {
            var usernameTaken = RegisterService.GetAllUsers();
            var atay = RegisterService.Check(UserAccountToAdd.Username);
            
                if (atay == null)
                {
                    if (UserAccountToAdd.FirstName != null || UserAccountToAdd.LastName != null ||
                        UserAccountToAdd.Username != null || UserAccountToAdd.Password !=
                        null || UserAccountToAdd.EmailAddress != null || UserAccountToAdd.BirthDate != null)
                    {
                        RegisterService.AddUserAccount(UserAccountToAdd);
                        Application.Current.MainPage.DisplayAlert("Congratulations", "Registration Successful", "Close");
                    }
                    else
                    {
                    Application.Current.MainPage.DisplayAlert("Registration Failed", "Please Fill all requirements", "Close");
                     }
                   
                }
                else
                {
                Application.Current.MainPage.DisplayAlert("Registration Failed", "Username is Already Taken", "Close");
                 }

            //else
            //{
            //    Application.Current.MainPage.DisplayAlert("Registration Failed", "Username is Already Taken", "Close");
            //}
        }
    }
}
