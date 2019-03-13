using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.OthersService;
using OcampoElective2Project.Services.TransportationService;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
   public class ExpenseViewModel : OcampoElective2ProjectViewModel
    {
        private UserAccount _user;
        private Clothes _selectedClothes;
        private Food _selectedFood;

        public UserAccount User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }
        public ObservableCollection<Clothes> ClothesList { get; set; } = new ObservableCollection<Clothes>();
        public ObservableCollection<Food> FoodList { get; set; } = new ObservableCollection<Food>();
        public ObservableCollection<Others> OthersList { get; set; } = new ObservableCollection<Others>();
        public ObservableCollection<Transportation> TransportationList { get; set; } = new ObservableCollection<Transportation>();

        public Clothes SelectedClothes
        {
            get => _selectedClothes;
            set
            {
                _selectedClothes = value;
                RaisePropertyChanged(nameof(SelectedClothes));
            }
        }

        public IClothesService ClothesService { get; set; }
        public IFoodService FoodService { get; set; }
        public IOthersService OthersService { get; set; }
        public ITransportationService TransportationService { get; set; }
        public ExpenseViewModel(INavigationService navigationService, IClothesService clothesService, IFoodService foodService, IOthersService othersService, ITransportationService transportationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            ClothesService = clothesService;
            FoodService = foodService;
            OthersService = othersService;
            TransportationService = transportationService;

        }
        public void LoadClothes(UserAccount user)
        {
            ClothesList.Clear();
            foreach (var clothes in ClothesService.GetClothesUser(User))
            {
                ClothesList.Add(clothes);
            }
        }

        public ICommand DeleteClothesCommand => new RelayCommand(DeleteClothesProc);

        public void DeleteClothesProc()
        {
            if(SelectedClothes != null)
            { 
            ClothesService.DeleteClothes(SelectedClothes);
            Refresh();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please Select a clothe that you want to be deleted", "Cancel");
            }

        }

        public void Refresh()
        {
            ClothesList.Clear();
            foreach (var clothes in ClothesService.GetClothesUser(User))
            {
                ClothesList.Add(clothes);
            }
        }


        public ICommand AddClothesCommand => new RelayCommand(AddClothesProc);

        private void AddClothesProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddClothesPage, User, false);

        }

        public bool isUpdate { get; set; }
        public ICommand UpdateClothesCommand => new RelayCommand(UpdateClothesProc);

        private void UpdateClothesProc()
        {
            if (SelectedClothes != null)
            {
                isUpdate = true;
                NavigationService.NavigateTo(ViewModelLocator.AddClothesPage, User, false);

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please Select a clothe that you want to be updated", "Cancel");
            }

            return;

        }
        public Food SelectedFood
        {
            get => _selectedFood;
            set
            {
                _selectedFood = value;
                RaisePropertyChanged(nameof(SelectedFood));
            }
        }

      

        public void LoadFood(UserAccount user)
        {
            FoodList.Clear();
            foreach (var v in FoodService.GetFoodUser(User))
            {
                FoodList.Add(v);
            }
        }

        public ICommand AddFoodCommand => new RelayCommand(AddFoodProc);

        private void AddFoodProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddFoodPage, User, false);
        }
        public ICommand DeleteFoodCommand => new RelayCommand(DeleteFoodProc);
        public void DeleteFoodProc()
        {
            if (SelectedFood!= null)
            {
               FoodService.DeleteFood(SelectedFood);
               RefreshFood();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please Select a food that you want to be deleted", "Cancel");
            }

        }
        public void RefreshFood()
        {
            FoodList.Clear();
            foreach (var food in FoodService.GetFoodUser(User))
            {
                FoodList.Add(food);
            }
        }

        public ICommand UpdateFoodCommand => new RelayCommand(UpdateFoodProc);

        private void UpdateFoodProc()
        {
            if (SelectedFood != null)
            {
                isUpdate = true;
                NavigationService.NavigateTo(ViewModelLocator.AddFoodPage, User, false);

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please Select a food that you want to be updated", "Cancel");
            }

            return;

        }

        /////////////////////////////
        /// Others                         ///////////////////////////
        private Others _selectedOthers;
        public Others SelectedOthers
        {
            get => _selectedOthers;
            set
            {
                _selectedOthers = value;
                RaisePropertyChanged(nameof(SelectedOthers));
            }
        }

        public ICommand AddOthersCommand => new RelayCommand(AddOthersProc);

        private void AddOthersProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddOthersPage, User, false);

        }





    }
}


