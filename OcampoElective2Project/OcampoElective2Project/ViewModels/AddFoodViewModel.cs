using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.UserAccountService;
using Xamarin.Forms;

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
        public IUserAccountService UserAccountService { get; set; }
        public Food FoodToAdd { get; set; }
        public AddFoodViewModel(INavigationService navigationService, IFoodService foodService, IUserAccountService userAccountService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            FoodService = foodService;
            FoodToAdd = new Food();
            UserAccountService = userAccountService;
        }

        public ICommand SaveFoodCommand => new RelayCommand(SaveFoodProc);
        //public ICommand SaveFoodCommand => new RelayCommand(async () => await SaveFoodProc());
        private void SaveFoodProc()
        {
            FoodToAdd.UserId = User.AccountId;
            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                User.Money += App.Locator.ExpenseViewModel.SelectedFood.Price;
                User.Money -= FoodToAdd.Price;
                FoodToAdd.Id = App.Locator.ExpenseViewModel.SelectedFood.Id;
                FoodService.UpdateFood(App.Locator.ExpenseViewModel.SelectedFood, FoodToAdd);
               
            }
            else
            {
                
                FoodService.AddFood(FoodToAdd);
                User.Money -= FoodToAdd.Price;
                
            }
            if (User != null)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    UserAccountService.UpdateUser(User, User);
                    
                    NavigationService.GoBack();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
            }
            else
            {
              Application.Current.MainPage.DisplayAlert("Error", "Please try again", "Cancel");
            }
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
