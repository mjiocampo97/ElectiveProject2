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
using OcampoElective2Project.Services.UserAccountService;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
    public class AddClothesViewModel : OcampoElective2ProjectViewModel
    {
      //  public ClothesViewModel UserClothesViewModel { get; set; }


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
        public IClothesService ClothesService { get; set; }
        public IUserAccountService UserAccountService { get; set; }
        public Clothes ClothesToAdd { get; set; }

        public AddClothesViewModel(INavigationService navigationService, IClothesService clothesService, IUserAccountService userAccountService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            ClothesService = clothesService;
            ClothesToAdd = new Clothes();
            UserAccountService = userAccountService;

        }
        
        public ICommand SaveClothesCommand => new RelayCommand(SaveClothesProc);

        private void SaveClothesProc()
        {
            ClothesToAdd.UserId = User.AccountId;
            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                User.Money += App.Locator.ExpenseViewModel.SelectedClothes.Price;
                User.Money -= ClothesToAdd.Price;
                ClothesToAdd.Id = App.Locator.ExpenseViewModel.SelectedClothes.Id;
                ClothesService.UpdateClothes(App.Locator.ExpenseViewModel.SelectedClothes, ClothesToAdd);
               
            }
            else
            {
               
                ClothesService.AddClothes(ClothesToAdd);
                User.Money -= ClothesToAdd.Price;
              
            }
           
            if (User != null)
            {
                NavigationService.GoBack();
                UserAccountService.UpdateUser(User, User);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please try again", "Cancel");
            }
            App.Locator.ExpenseViewModel.isUpdate = false;
        }

    }
}
