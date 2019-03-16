using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.OthersService;
using OcampoElective2Project.Services.UserAccountService;

namespace OcampoElective2Project.ViewModels
{
    public class AddOthersViewModel : OcampoElective2ProjectViewModel
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
        public IOthersService OthersService { get; set; }
        public IUserAccountService UserAccountService { get; set; }
        public Others OthersToAdd { get; set; }
        public AddOthersViewModel(INavigationService navigationService, IOthersService othersService, IUserAccountService userAccountService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            OthersService = othersService;
            OthersToAdd = new Others();
            UserAccountService = userAccountService;
        }

        public ICommand SaveOthersCommand => new RelayCommand(SaveOthersProc);

        private void SaveOthersProc()
        {
            OthersToAdd.UserId = User.AccountId;
            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                User.Money += App.Locator.ExpenseViewModel.SelectedOthers.Price;
                User.Money -= OthersToAdd.Price;
                OthersToAdd.Id = App.Locator.ExpenseViewModel.SelectedOthers.Id;
                OthersService.UpdateOthers(App.Locator.ExpenseViewModel.SelectedOthers, OthersToAdd);
  
            }
            else
            {
               
                OthersService.AddOthers(OthersToAdd);
                User.Money -= OthersToAdd.Price;
               
            }
            NavigationService.GoBack();
            UserAccountService.UpdateUser(User,User);
            App.Locator.ExpenseViewModel.isUpdate = false;
        }

        //ClothesToAdd.UserId = User.AccountId;
        //if (App.Locator.ClothesViewModel.isUpdate == true)
        //{
        //    ClothesToAdd.Id = App.Locator.ClothesViewModel.SelectedClothes.Id;
        //    ClothesService.UpdateClothes(App.Locator.ClothesViewModel.SelectedClothes, ClothesToAdd);
        //    NavigationService.NavigateTo(ViewModelLocator.ClothesPage, User, true);
        //}
        //else
        //{

        //    ClothesService.AddClothes(ClothesToAdd);
        //    NavigationService.GoBack();
        //}

        //App.Locator.ClothesViewModel.isUpdate = false;
    }
}
