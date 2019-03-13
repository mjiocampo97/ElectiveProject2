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
using OcampoElective2Project.Services.FoodService;

namespace OcampoElective2Project.ViewModels
{
    public class AddFoodViewModel : OcampoElective2ProjectViewModel
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

        public IFoodService FoodService { get; set; }
        public Food FoodToAdd { get; set; }
        public AddFoodViewModel(INavigationService navigationService, IFoodService foodService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            FoodService = foodService;
            FoodToAdd = new Food();

        }

        public ICommand SaveFoodCommand => new RelayCommand(SaveFoodProc);
        private void SaveFoodProc()
        {
            FoodToAdd.UserId = User.AccountId;
            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                FoodToAdd.Id = App.Locator.ExpenseViewModel.SelectedFood.Id;
                FoodService.UpdateFood(App.Locator.ExpenseViewModel.SelectedFood, FoodToAdd);
               
            }
            else
            {
                
                FoodService.AddFood(FoodToAdd);
               
            }
            NavigationService.GoBack();
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
